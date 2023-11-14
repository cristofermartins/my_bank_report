using System;
using System.Collections;
using BankData;

namespace Processors.Taggers
{
    using BankEntryList = List<BankDataEntry>; 
    using TaggedBankEntryList = List<TaggedBankEntry>;

    public readonly record struct TaggedBankEntry
    {
        public TaggedBankEntry(IReadOnlyCollection<Tag> tags)
        {
            _tags.AddRange(tags);
        }
        public IReadOnlyCollection<Tag> Tags {get { return _tags.AsReadOnly();} }

       private List<Tag> _tags {get;} = new List<Tag>();
    }
}