using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConquerDialogsTranslatorAPI
{
    public static class Translator
    {
        public enum Language
        {
            ES,
            EN,
            CA,
            PT,
        }

        public static string GetTranslatedString(string _Text, Language FromLanguage, Language? _ToLanguage)
        {
            string lang = Language.EN.ToString().ToLower();
            if (_ToLanguage != null)
            {
                lang = _ToLanguage.ToString().ToLower();
            }

            string url = @"https://translate.googleapis.com/translate_a/single?client=gtx&sl=es&tl=" + lang + "&dt=t&q=" + WebUtility.UrlEncode(_Text);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            string jsonResponse = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonResponse = reader.ReadToEnd();
            }

            string TextParsed = _Text;
            JArray objResult = JsonConvert.DeserializeObject<JArray>(jsonResponse);
            if (objResult.First() != null)
            {
                TextParsed = "";
            }
            foreach(var item in objResult.First().Children())
            {
                TextParsed += item.First().ToString();
            }
            return TextParsed;
        }
    }
}
