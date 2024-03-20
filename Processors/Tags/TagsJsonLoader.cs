using System;
using System.Text.Json;

namespace Processors.Tags
{
    public class JsonTag
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
    }

    public class TagsJsonLoader
    {
        public IList<JsonTag>? loadJson(string taggersFileName)
        {
            string? jsonString = File.ReadAllText(taggersFileName);
            if (jsonString == null) 
            {
                return null;
            }
            
            return JsonSerializer.Deserialize<IList<JsonTag>?>(jsonString);
        }      
    }
}