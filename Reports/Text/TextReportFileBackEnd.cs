using System;
using Processors;

namespace Reports.TextReports
{
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
}
