using System;
using BankData;
using Processors.Taggers;
using Processors.SpentType;

namespace Processors
{
    public class ProcessorsManager
    {
        public ProcessorsManager() {}

        public List<ProcessedBankData> Process(in List<BankDataEntry> bankDataEntryList, string taggersFileName)
        {
            List<ProcessedBankData> ret = new List<ProcessedBankData>();

            TaggersManager taggersManager = new TaggersManager();

            taggersManager.Load(taggersFileName);

            SpentTypeProcessor spentTypeProcessor = new SpentTypeProcessor();

            foreach (BankDataEntry bankDataEntry in bankDataEntryList)
            {
                TaggedBankEntry taggedBankEntry = taggersManager.Process(bankDataEntry);

                ESpentType eSpentType = spentTypeProcessor.Process(bankDataEntry);
                
                ret.Add(new ProcessedBankData
                {
                    BankDataEntry = bankDataEntry,
                    TaggedBankEntry = taggedBankEntry,
                    ESpentType = eSpentType
                });
            }
            
            return ret;
        }
    }
}