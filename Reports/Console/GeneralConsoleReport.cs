using System;
using Processors;

namespace Reports.ConsoleReports
{
    public class GeneralConsoleReport : ConsoleReport
    {
        public void Print(in List<ProcessedBankData> processedBankDataList)
        {
            Dictionary<string, List<ProcessedBankData>> tagsDict = ReportsLib.BuildTagNameToProcessedBankDataList(processedBankDataList);
            
            tagsDict["Outros"] = ReportsLib.BuildNoTagProcessedBankDataList(processedBankDataList);



            foreach (var entry in tagsDict)
            {
                double totalSpent = 0D;
                foreach (var data in entry.Value)
                {
                    totalSpent += data.BankDataEntry.Value;
                }

                Console.WriteLine("{0} total gasto: {1}", entry.Key, totalSpent);
            }

            foreach (var entry in tagsDict["Outros"])
            {
                Console.WriteLine("{0}, {1}", entry.BankDataEntry.StringID, entry.BankDataEntry.Value);
            }
        }
    }
}