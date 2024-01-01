using System;
using Processors;

namespace Reports.TextReports
{
    public interface ITextReport
    {
        void Generate(in List<ProcessedBankData> processedBankDataList, in ITextReportBackend iTextReportBackend);
    }
}
