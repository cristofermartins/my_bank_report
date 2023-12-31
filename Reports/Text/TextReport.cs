using System;
using Processors;

namespace Reports.TextReports
{
    public interface ITextReport
    {
        void Generate(in List<ProcessedBankData> processedBankDataList, in ITextReportBackend iTextReportBackend);
    }

    public interface ITextReportBackend
    {
        public void WriteLine(in string newLine);
    }

    public class TextReportFileBackEnd : ITextReportBackend
    {
        public TextReportFileBackEnd(in string outTextFileName)
        {
            this.StreamWriter = File.CreateText(outTextFileName);
            this.StreamWriter.AutoFlush = true;
        }
        public void WriteLine(in string newLine)
        {
            StreamWriter.WriteLine(newLine);
        }

        private StreamWriter StreamWriter {get; init;}
    }

   public class TextReportConsoleBackEnd : ITextReportBackend
    {
        public void WriteLine(in string newLine)
        {
            Console.WriteLine(newLine);
        }
    }
}