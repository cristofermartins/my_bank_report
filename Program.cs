using System;
using BankData;
using Processors;
using Processors.Tags;
using Processors.Taggers;
using Reports.TextReports;

namespace Program 
{
    public static class Program 
    {
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

            TagsManager tagsManager = new TagsManager();
            tagsManager.LoadFromJson(commandLineParams.TagsFileName);

            TaggersManager taggersManager = new TaggersManager(tagsManager);
            taggersManager.LoadFromJson(commandLineParams.TaggerFileName);            

            ProcessorsManager processorsManager = new ProcessorsManager();

            List<ProcessedBankData> processedBankDataList = processorsManager.Process(bankEntryList, taggersManager);

            if (bankEntryList.Count == 0) 
            {
                Console.WriteLine("Após o processamento, não há lançamentos.");
                return 0;
            }

            TextReportFileBackEnd textReportFileBackEnd = new TextReportFileBackEnd("test.txt");
            ITextReportBackend textReportConsoleBackEnd = new TextReportConsoleBackEnd();

            ITextReport textReport = new GeneralTextReport();
            //textReport.Generate(processedBankDataList, textReportFileBackEnd);
            textReport.Generate(processedBankDataList, textReportConsoleBackEnd);
    
            return 0;
        }
    }
}

