namespace ConquerDialogsTranslatorAPI
{
    public class Translation
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Translator.Language FromLang { get; set; }
        public Translator.Language ToLang { get; set; }
    }
}
