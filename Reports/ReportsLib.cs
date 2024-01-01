using System;

using Processors;
using Reports;

namespace Reports
{
    public static class ReportsLib
    {
        public static Dictionary<string, List<ProcessedBankData>> BuildTagNameToProcessedBankDataList(in List<ProcessedBankData> processedBankDataList)
        {
            Dictionary<string, List<ProcessedBankData>> tagsDict = new Dictionary<string, List<ProcessedBankData>>();
            
            foreach (ProcessedBankData processedBankData in processedBankDataList)
            {
                foreach (var tag in processedBankData.TaggedBankEntry.Tags)
                {
                    string tagName = tag.Name;
                    if (!tagsDict.ContainsKey(tagName))
                    {
                        tagsDict[tagName] = new List<ProcessedBankData>();
                    }
                    tagsDict[tagName].Add(processedBankData);
                }
            }

            return tagsDict;
        }   

        public static List<ProcessedBankData> BuildNoTagProcessedBankDataList(in List<ProcessedBankData> processedBankDataList)
        {
            List<ProcessedBankData> ret = new List<ProcessedBankData>();

            foreach (ProcessedBankData processedBankData in processedBankDataList)
            {
                if (processedBankData.TaggedBankEntry.Tags.Count == 0)
                {
                    ret.Add(processedBankData);
                }
            }
            
            return ret;
        }   
    }
}