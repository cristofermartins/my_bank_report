using System;
using BankData;

namespace Processors.SpentType
{
    public enum ESpentType
    {
        None,
        Income,
        Spent,

        TransferIn,
        TransferOut,
    }

    public class SpentTypeProcessor 
    {
        public ESpentType Process(in BankDataEntry bankDataEntry)
        {

            if (bankDataEntry.Value > 0)
            {   
                return ESpentType.Income;
            }
            
            if (bankDataEntry.Value < 0) {
                return ESpentType.Spent;
            }
            return ESpentType.None;
        }
    }
}