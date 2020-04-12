using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ConquerDialogsTranslatorAPI
{
    public static class Translator
    {
        // Global Variables
        private static string CONFIG_DIR_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConquerDialogsTranslatorAPI"); // AppData folder
        private static string CONFIG_FILE_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConquerDialogsTranslatorAPI", "Cache.json"); // AppData folder

        public static List<Translation> Translations = new List<Translation>();

        public enum Language
        {
            ES,
            EN,
            CA,
            PT,
        }

        public static string GetTranslatedString(string _Text, Language _FromLanguage, Language _ToLanguage)
        {
            LoadCache();
            string Text = GetStringFromCache(new Translation() { Key = _Text, FromLang = _FromLanguage, ToLang = _ToLanguage });
            return Text;
        }

        private static void LoadCache()
        {
            //Check if have available in json cache saved
            if (!Directory.Exists(CONFIG_DIR_PATH))
            {
                Directory.CreateDirectory(CONFIG_DIR_PATH);
            }
            if (!File.Exists(CONFIG_FILE_PATH))
            {
                File.WriteAllText(CONFIG_FILE_PATH, JsonConvert.SerializeObject(Translations));
            }
            // Loading current cache
            Translations = JsonConvert.DeserializeObject<List<Translation>>(File.ReadAllText(CONFIG_FILE_PATH));
        }

        private static void SaveCache()
        {
            if (File.Exists(CONFIG_FILE_PATH))
            {
                File.WriteAllText(CONFIG_FILE_PATH, JsonConvert.SerializeObject(Translations));
            }
        }

        private static string GetStringFromCache(Translation translation)
        {
            Translation t = Translations.Where(x => x.Key == translation.Key && x.FromLang == translation.FromLang && x.ToLang == translation.ToLang).FirstOrDefault();
            if (t != null)
            {
                return t.Value;
            } else
            {
                // Process to get the string from google api
                string url = @"https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + translation.FromLang.ToString() + "&tl=" + translation.ToLang.ToString() + "&dt=t&q=" + WebUtility.UrlEncode(translation.Key);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                string jsonResponse = "";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonResponse = reader.ReadToEnd();
                }

                string TextParsed = translation.Key;
                JArray objResult = JsonConvert.DeserializeObject<JArray>(jsonResponse);
                if (objResult.First() != null)
                {
                    TextParsed = "";
                }
                foreach (var item in objResult.First().Children())
                {
                    TextParsed += item.First().ToString();
                }
                translation.Value = TextParsed;
                Translations.Add(translation);
                SaveCache();

                return translation.Value;
            }
        }

        public static void ClearCache()
        {
            Translations.Clear();
            File.WriteAllText(CONFIG_FILE_PATH, JsonConvert.SerializeObject(Translations));
        }
    }
}
