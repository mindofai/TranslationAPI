using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TranslationAPI
{
    public class TranslatePart
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public class TranslateModel
    {
        [JsonProperty("Data")]
        public List<TranslatePart> Data { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Translation
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class TranslationResult
    {
        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }
}
