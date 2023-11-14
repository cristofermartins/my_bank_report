using System;
using BankData;
using Processors;
using Reports.PdfReports;
using Reports.TextReports;
using Reports.ConsoleReports;

namespace Program {
    public static class Program {
        public static int Main(string[] args)
        {   
            BuildCommandLineParamsResult buildCommandLineParamsResult = CommandLineParams.BuildCommandLineParamsFromArgs(args);
            if (buildCommandLineParamsResult.HasError())
            {
                Console.WriteLine(buildCommandLineParamsResult.GetErrorDescription());
                return 0;
            }

            CommandLineParams commandLineParams = buildCommandLineParamsResult.GetValue();
        
            ParsersManager parsersManager = new ParsersManager();

            List<BankDataEntry> bankEntryList = parsersManager.ParseFiles(commandLineParams.InputFiles);

            if (bankEntryList.Count == 0) 
            {
                Console.WriteLine("Não foi detectado nenhum lançamento nos arquivos passados pela linha de comando.");
                return 0;
            }

            ProcessorsManager processorsManager = new ProcessorsManager();

            List<ProcessedBankData> processedBankDataList = processorsManager.Process(bankEntryList, commandLineParams.TaggerFileName);

            if (bankEntryList.Count == 0) 
            {
                Console.WriteLine("Após o processamento, não há lançamentos.");
                return 0;
            }
        
            PdfReport pdfReport = new GeneralPdfReport();
            pdfReport.Generate(processedBankDataList, "out.pdf");

            TextReport textReport = new GeneralTextReport();
            textReport.Generate(processedBankDataList, "out.txt");

            ConsoleReport consoleReport = new GeneralConsoleReport();
            consoleReport.Print(processedBankDataList);
    
            return 0;
        }
    }
}

