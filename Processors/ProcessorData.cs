using System;
using BankData;
using Processors.Taggers;
using Processors.SpentType;

namespace Processors
{
    public readonly record struct ProcessedBankData
    {
        public ProcessedBankData() {}
        public BankDataEntry BankDataEntry {get; init;}
        public TaggedBankEntry TaggedBankEntry {get; init;}
        public ESpentType ESpentType {get; init;} = ESpentType.None;
    }
}