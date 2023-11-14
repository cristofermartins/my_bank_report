using System;
using Processors;

namespace Reports.TextReports
{
    public interface TextReport
    {
        void Generate(in List<ProcessedBankData> processedBankDataList, in string outTextFileName);
    }
}