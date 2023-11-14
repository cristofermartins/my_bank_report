using System;

namespace BankData 
{
    public enum BankType 
    {
        None,
        Credit,
        Debit,
        Manual
    }

    public enum FinancialInstituition
    {
        None,
        Itau,
        NuBank
    }

    public readonly record struct BankDataEntry 
    {
        public BankDataEntry() {}
        public double Value {get; init;}
        public string StringID {get; init;} = "";
        public DateTime Date {get; init;}
        public BankType BankType {get; init;}
        public FinancialInstituition FinancialInstituition {get; init;}
    }

    public struct BankData
    {
        public BankData() {}

        public  List<BankDataEntry> Entries = new List<BankDataEntry>();
    }
}