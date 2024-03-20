using System;

namespace Processors.Tags
{
    public class TagsManager 
    {
        public void LoadFromJson(string jsonFileName)
        {
            TagsJsonLoader jsonLoader = new TagsJsonLoader();
            IList<JsonTag>? jsonTags = jsonLoader.loadJson(jsonFileName);
            if (jsonTags != null)
            {
                foreach (JsonTag jsonTag in jsonTags)
                {
                    string? name = jsonTag.Name;
                    string? description = jsonTag.Description;
                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(description))
                    {
                        TagsList.Add(new Tag (name, description));
                    }
                }
            }
        }

        public Tag? GetTagByName(string Name) 
        {
            foreach (Tag tag in TagsList)
            {
                if (tag.Name == Name)
                {
                    return tag;
                }
            }

            return null;
        }
        private List<Tag> TagsList = new List<Tag>();
    }
}