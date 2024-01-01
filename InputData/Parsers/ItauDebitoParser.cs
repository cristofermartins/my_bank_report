namespace BankData.Parsers
{
    public class TItauDebitoParser : IBankParser
    {
        public List<BankDataEntry> ParseFiles(in List<string> inputFiles)
        {
            List<BankDataEntry> ret = new List<BankDataEntry>();
            foreach (string inputFile in inputFiles) 
            {
                string extension = Path.GetExtension(inputFile);
                if (extension == ".txt")
                {
                    using (TextReader reader = File.OpenText(inputFile)) 
                    {
                        string? readedLine;
                        do {
                            readedLine = reader.ReadLine();
                            if (readedLine != null)
                            {
                                string[] splitedLine = readedLine.Split(";");
                                if (splitedLine.Length == 3)
                                {
                                    string stringId = splitedLine[1];
                                    double value = Convert.ToDouble(splitedLine[2]);
                                    string[] timeSplitedData = splitedLine[0].Split("/");

                                    BankDataEntry bankDataEntry = new BankDataEntry
                                    {
                                        StringID = stringId,
                                        Value = value,
                                        Date = new DateTime(Convert.ToInt32(timeSplitedData[2]), Convert.ToInt32(timeSplitedData[1]), Convert.ToInt32(timeSplitedData[0]))
                                    };
                                    ret.Add(bankDataEntry);
                                }
                            }
                        
                        } while (readedLine != null);
                    }
                }
            }
 
            return ret;
        }
    }
}