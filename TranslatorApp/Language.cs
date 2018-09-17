namespace TranslatorApp
{
    class Language
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Language(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Language(Language other)
        {
            Key = other.Key;
            Value = other.Value;
        }
    }
}