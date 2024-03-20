using System;
using System.Text.Json;

namespace Processors.Taggers
{
    public class JsonTest
    {
        public string? Name {get; set;}
        public string? TextSub {get; set;}
    }

    public class JsonTagger
    {
        public string? Name {get; set;}
        public int? Weight {get; set;}
        public IList<string>? Tags {get; set;}
        public IList<JsonTest>? Tests {get; set;}
    }

    public class TaggersJsonLoader
    {
        public IList<JsonTagger>? loadJson(string taggersFileName)
        {
            string? jsonString = File.ReadAllText(taggersFileName);
            if (jsonString == null) 
            {
                return null;
            }

            return JsonSerializer.Deserialize<IList<JsonTagger>?>(jsonString);
        }      
    }
}