using System;
using BankData;
using Processors.Tags;

namespace Processors.Taggers
{
    using BankEntryList = List<BankDataEntry>; 
    public class TaggersManager 
    {

        public TaggersManager(TagsManager tagsManager)
        {
            _tagsManager = tagsManager;
        }
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

        public void LoadFromJson(string jsonFileName) 
        {
            TaggersJsonLoader jsonLoader = new TaggersJsonLoader();
            IList<JsonTagger>? JsonTaggersList = jsonLoader.loadJson(jsonFileName);
            if (JsonTaggersList != null)
            {
                foreach (JsonTagger jsonTagger in JsonTaggersList)
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
                                Tag? tag = _tagsManager.GetTagByName(tagName);
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

        private List<Tagger> TaggersList = new List<Tagger>();
        private readonly TagsManager _tagsManager;
    }
}