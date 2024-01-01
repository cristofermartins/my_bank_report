using System;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

using Microcharts;
using SkiaSharp;

using Processors;

namespace Reports.PdfReports
{
    public interface PdfReport 
    {
        void Generate(in List<ProcessedBankData> processedBankDataList, in string outPdfFileName);
    }
}