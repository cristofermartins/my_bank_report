using System;
using Processors;

namespace Reports.TextReports
{
   public class TextReportConsoleBackEnd : ITextReportBackend
    {
        public void WriteLine(in string newLine)
        {
            Console.WriteLine(newLine);
        }
    }
}
