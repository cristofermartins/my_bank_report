using System;
using System.Text.Json;

namespace Processors.Taggers
{
    public class JsonTag
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
    }

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
    public class TaggerJson
    {
        public IList<JsonTag>? Tags {get; set;}
        public IList<JsonTagger>? Taggers {get; set;}
    };

    public class TaggersJsonLoader
    {
        public TaggerJson? loadJson(string taggersFileName)
        {
            string? jsonString = File.ReadAllText(taggersFileName);
            if (jsonString == null) 
            {
                return null;
            }

            return JsonSerializer.Deserialize<TaggerJson>(jsonString);
        }      
    }
}