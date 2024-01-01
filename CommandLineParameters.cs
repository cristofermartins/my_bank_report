using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Program 
{
    public enum BuildCommandLineParamsErrorEnum
    {
        NO_ERROR = 0,
        NO_INPUT_FILES = 1,
        INVALID_INPUT_FILE = 2,
        NO_TAGGERS_FILE = 3,
    }

    public readonly record struct BuildCommandLineParamsResult
    {
        public BuildCommandLineParamsResult(BuildCommandLineParamsErrorEnum errorCode, CommandLineParams? value, string extraErrorMessage) 
        {
            if ((errorCode == BuildCommandLineParamsErrorEnum.NO_ERROR) && (value == null)) {
                throw new Exception("Error code é ok mas não tem instancia.");
            }
            this.ErrorCode = errorCode;
            this.Value = value;
            this.ExtraErrorMessage = extraErrorMessage;
        }

        private CommandLineParams? Value {get; init;}
        public BuildCommandLineParamsErrorEnum ErrorCode {get; init;}

        private string ExtraErrorMessage {get; init;}

        public CommandLineParams GetValue()
        {
            if (Value == null) 
            {
                throw new Exception("GetValue foi chamado sendo que o Value está nulo, alguém está usando isso daqui errado.");
            }

            return Value;
        }

        public bool HasError()
        {
            return (ErrorCode != BuildCommandLineParamsErrorEnum.NO_ERROR);
        }

        public string GetErrorDescription()
        {
            switch (ErrorCode)
            {
                case BuildCommandLineParamsErrorEnum.NO_INPUT_FILES: 
                    return "Não há arquivos para serem lidos na linha de comando.";

                case BuildCommandLineParamsErrorEnum.INVALID_INPUT_FILE:
                    return $"O arquivo {ExtraErrorMessage} não existe.";

                case BuildCommandLineParamsErrorEnum.NO_TAGGERS_FILE:
                    return $"Arquivo {ExtraErrorMessage} com a configuração do sistema de tag não encontrado.";

                default:
                    return "DEFAULT ERROR CODE - WIP";
            }
        }
    }

    public record class CommandLineParams
    {
        public List<string> InputFiles {get; init;} = new List<string>();
        public string TaggerFileName {get; init;} = "";
        public static BuildCommandLineParamsResult BuildCommandLineParamsFromArgs(string[] args)
        {
            const int PROCESSING_INPUT_FILES = 1;
            const int PROCESSING_TAGGER_FILE = 2;

            int processingState = 0;

            List<string> inputFiles = new List<string>();
            string taggerFileName = "taggers.json";

            for (int i = 0; i < args.Length; i++)
            {
                string possibleCommand = args[i].Trim();
                switch (possibleCommand)
                {
                    case "-a":
                        processingState = PROCESSING_INPUT_FILES;
                        break;
                    case "-t":
                        processingState = PROCESSING_TAGGER_FILE;
                        break;
                    default: 
                        switch (processingState)
                        {
                            case PROCESSING_INPUT_FILES:
                                string possibleFile = possibleCommand;
                                if (!File.Exists(possibleFile))
                                {
                                    return new BuildCommandLineParamsResult(BuildCommandLineParamsErrorEnum.INVALID_INPUT_FILE, null, possibleFile);
                                }
                                inputFiles.Add(possibleFile);
                                break;

                            case PROCESSING_TAGGER_FILE:
                                taggerFileName = possibleCommand;   
                                break;

                            default:
                                break;
                        }
                    break;
                }                 
                
            }

            if (!File.Exists(taggerFileName))
            {
                return new BuildCommandLineParamsResult(BuildCommandLineParamsErrorEnum.NO_TAGGERS_FILE, null, taggerFileName);
            }  

            if (inputFiles.Count() == 0)
            {
                return new BuildCommandLineParamsResult(BuildCommandLineParamsErrorEnum.NO_INPUT_FILES, null, "");
            }
        
            return new BuildCommandLineParamsResult
            (
                BuildCommandLineParamsErrorEnum.NO_ERROR,
                new CommandLineParams
                {
                    InputFiles = inputFiles,
                    TaggerFileName = taggerFileName
                },
                ""
            );
        }
    }
}