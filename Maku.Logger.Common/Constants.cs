namespace Maku.Logger.Common
{
    public class Constants
    {
        public const string Extension = ".txt";

        public struct LoggerSeverity
        {
            public const int Message = 1;
            public const int Warning = 2;
            public const int Error = 3;
        }

        public struct Procedures
        {
            public const string UspInsertLogger = "uspInsertLogger";
        }

        public struct LoggerBody
        {
            public const string LoggerCreatedBy = "CREATEDBY:               {0}";
            public const string LogType = "TYPE:                    {0}";
            public const string LoggerCreationDate = "CREATIONDATE:            {0}";
            public const string LoggerDescription = "DESCRIPTION:             {0}";
            public const string LoggerBegin = "------------------BEGIN------------------";
            public const string LoggerEnd = "-------------------END-------------------";
        }
    }
}
