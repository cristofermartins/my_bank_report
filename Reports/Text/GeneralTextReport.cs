using System;
using System.IO;
using Processors;
using Reports.TextReports;

namespace Reports.TextReports
{
    public class GeneralTextReport : TextReport
    {
        public void Generate(in List<ProcessedBankData> processedBankDataList, in string outTextFileName)
        {
            using (StreamWriter streamWriter = File.CreateText(outTextFileName))
            {
                foreach (ProcessedBankData processedBankData in processedBankDataList)
                {
                    streamWriter.WriteLine(processedBankData.BankDataEntry.StringID);
                }
            }
        }
    }
}