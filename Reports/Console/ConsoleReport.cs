using System;

using Processors;

namespace Reports.ConsoleReports
{
    public interface ConsoleReport
    {
        void Print(in List<ProcessedBankData> processedBankDataList);
    }
}