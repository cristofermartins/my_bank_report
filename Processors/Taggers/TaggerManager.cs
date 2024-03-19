using System;
using System.Text.Json;
using BankData;

namespace Processors.Taggers
{
    using BankEntryList = List<BankDataEntry>; 
    public class TaggersManager 
    {
        public TaggedBankEntry Process(in BankDataEntry bankDataEntry)
        {
            List<Tag> tagList = new List<Tag>();
            foreach (Tagger tagger in TaggersList)
            {
                IReadOnlyCollection<Tag>? c = tagger.TagBankEntryList(bankDataEntry);
                if (c != null) {
                    tagList.AddRange(c);
                }
            }

            return new TaggedBankEntry(tagList);
        }

        public void Load(string taggersFileName) 
        {
                TaggersJsonLoader jsonLoader = new TaggersJsonLoader();
                TaggerJson? taggerJson = jsonLoader.loadJson(taggersFileName);
                if (taggerJson != null)
                {
                    if ( taggerJson.Tags != null)
                    {
                        foreach (JsonTag jsonTag in taggerJson.Tags)
                        {
                            string? name = jsonTag.Name;
                            string? description = jsonTag.Description;
                            if (!String.IsNullOrEmpty(name) && (description != null))
                            {
                                TagsList.Add(new Tag (name, description));
                            }
                        }
                    }

                    if (taggerJson.Taggers != null)
                    {
                        foreach (JsonTagger jsonTagger in taggerJson.Taggers)
                        {
                            string? Name = jsonTagger.Name;
                            int? Weight = jsonTagger.Weight;

                            if (Name != null && Weight != null)
                            {
                                List<TaggerTest> testsList = new List<TaggerTest>();
                                List<Tag> tagsList = new List<Tag>();

                                if (jsonTagger.Tags != null)
                                {
                                    foreach (string tagName in jsonTagger.Tags)
                                    {
                                        Tag? tag = GetTagByName(tagName);
                                        if (tag != null)
                                        {
                                            tagsList.Add(tag.Value);
                                        }
                                    }
                                }

                                if (jsonTagger.Tests != null)
                                {
                                    foreach (JsonTest jsonTest in jsonTagger.Tests)
                                    {
                                        string? testName = jsonTest.Name;
                                        string? testTextSub = jsonTest.TextSub;
                                        if (testName != null && testTextSub != null)
                                        {
                                            TaggerTest iTagTest = new TaggerTest
                                            {
                                                Name = testName,
                                                TextSub = testTextSub
                                            };

                                            testsList.Add(iTagTest);
                                        }
                                    }
                                }

                                Tagger tagger = new Tagger (tagsList, testsList)
                                {
                                    Name = Name,
                                    Weight = Weight.Value
                                };

                                TaggersList.Add(tagger);
                            }
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
        private List<Tagger> TaggersList = new List<Tagger>();
    }
}