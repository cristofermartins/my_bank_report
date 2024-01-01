using System;
using BankData.Parsers;

namespace BankData 
{
    public class ParsersManager
    {
        public ParsersManager()
        {
            _iBankParserList = new List<IBankParser>();
            _iBankParserList.Add(new TItauDebitoParser());
            _iBankParserList.Add(new TNuBankCreditParser());
        }

        public List<BankDataEntry> ParseFiles(in List<string> inputFiles) 
        {
            List<BankDataEntry> ret = new List<BankDataEntry>();
            foreach (IBankParser bankParser in _iBankParserList) 
            {
                ret.AddRange(bankParser.ParseFiles(inputFiles));
            }
            return ret;
        }

        private List<IBankParser> _iBankParserList;
    }
}