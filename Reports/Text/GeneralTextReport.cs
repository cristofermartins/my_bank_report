using System;
using System.IO;
using Processors;
using Reports.TextReports;

namespace Reports.TextReports
{
    public class GeneralTextReport : ITextReport
    {
        public void Generate(in List<ProcessedBankData> processedBankDataList, in ITextReportBackend iTextReportBackend)
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

                iTextReportBackend.WriteLine($"{entry.Key} total gasto: {totalSpent}");
            }

            foreach (var entry in tagsDict["Outros"])
            {
                iTextReportBackend.WriteLine($"{entry.BankDataEntry.StringID}, {entry.BankDataEntry.Value}");
            }
        }
    }
}