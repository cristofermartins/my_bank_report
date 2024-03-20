using System;
using BankData;
using Processors.Tags;

namespace Processors.Taggers
{
    using BankEntryList = List<BankDataEntry>; 
    using TaggedBankEntryList = List<TaggedBankEntry>;

    public class Tagger 
    {
        public string Name {get; set;} = "";
        public int Weight {get; set;} = 0;

        public List<Tag> TagsList {get; set;}
        public List<TaggerTest> TestsList {get; set;}

        public Tagger(List<Tag> tagsList, List<TaggerTest> testsList) {
            TagsList = tagsList;
            TestsList = testsList;
        }
        public IReadOnlyCollection<Tag>? TagBankEntryList(BankDataEntry bankDataEntry) {
            foreach (TaggerTest tagTest in TestsList)
            {
                if (tagTest.Test(bankDataEntry.StringID))
                {
                    return TagsList.AsReadOnly();
                }
            }
            return null;
        }
    }
}