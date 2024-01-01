using System;
using Processors;

namespace Reports.TextReports
{
    public interface ITextReportBackend
    {
        public void WriteLine(in string newLine);
    }
}
