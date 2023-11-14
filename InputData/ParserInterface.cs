namespace BankData 
{
    public interface IBankParser
    {
        List<BankDataEntry> ParseFiles(in List<string> inputFiles);
    }
}