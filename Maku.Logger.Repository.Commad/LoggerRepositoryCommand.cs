using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Maku.Logger.Repository.Interfaces.Commad;
using Maku.Logger.CommandModel;
using Maku.Logger.Common;
using Maku.Logger.Repository.Native;

namespace Maku.Logger.Repository.Commad
{
    public class LoggerRepositoryCommand : DbConnex, ILoggerRepositoryCommand
    {
        public void LogToDatabase(Message message)
        {
            using (var command = Database.CreateConnection().CreateCommand())
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "Insert Into LoggerTest (messageType, createdBy, description, creationDate) values (@messageType, @createdBy, @description, @creationDate)";
                command.Parameters.Add(new SqlParameter { ParameterName = "@messageType", SqlDbType = SqlDbType.Int,  Value = message.LoggerSeverity });
                command.Parameters.Add(new SqlParameter { ParameterName = "@createdBy", SqlDbType = SqlDbType.VarChar,  Value = message.CreatedBy });
                command.Parameters.Add(new SqlParameter { ParameterName = "@description", SqlDbType = SqlDbType.VarChar,  Value = message.Description });
                command.Parameters.Add(new SqlParameter { ParameterName = "@creationDate", SqlDbType = SqlDbType.DateTime,  Value = message.CreationDate });

                command.ExecuteNonQuery();
            }
            
            //using (DbCommand command = Database.GetStoredProcCommand(Constants.Procedures.UspInsertLogger))
            //{
            //    Database.AddInParameter(command, "@messageType", SqlDbType.VarChar, message.LoggerSeverity);
            //    Database.AddInParameter(command, "@createdBy", SqlDbType.VarChar, message.CreatedBy);
            //    Database.AddInParameter(command, "@description", SqlDbType.VarChar, message.Description);
            //    Database.AddInParameter(command, "@creationDate", SqlDbType.DateTime, message.CreationDate);
            //    Database.ExecuteNonQuery(command);
            //}
        }

        public void LogToFile(Message message)
        {
            // https://quickio.net/
            //https://designingefficientsoftware.wordpress.com/2011/03/03/efficient-file-io-from-csharp/

            var filePath = ConfigurationManager.AppSettings["LogFileDirectory"];
            var fullPath = string.Concat(filePath, message.CreatedBy, Constants.Extension);
            Directory.CreateDirectory(filePath);
            
            var messageTypeName = Util.GetLogTypeName(message.LoggerSeverity);
            if (!File.Exists(fullPath))
            {
                using (var sw = File.CreateText(fullPath))
                {
                    sw.WriteLine(Constants.LoggerBody.LoggerBegin);
                    sw.WriteLine(Constants.LoggerBody.LoggerCreatedBy, message.CreatedBy);
                    sw.WriteLine(Constants.LoggerBody.LogType, messageTypeName);
                    sw.WriteLine(Constants.LoggerBody.LoggerCreationDate, message.CreationDate);
                    sw.WriteLine(Constants.LoggerBody.LoggerDescription, message.Description);
                    sw.WriteLine(Constants.LoggerBody.LoggerEnd);
                }
            }
            else {

                using (var sw = File.AppendText(fullPath))
                {
                    sw.WriteLine(Constants.LoggerBody.LoggerBegin);
                    sw.WriteLine(Constants.LoggerBody.LoggerCreatedBy, message.CreatedBy);
                    sw.WriteLine(Constants.LoggerBody.LogType, messageTypeName);
                    sw.WriteLine(Constants.LoggerBody.LoggerCreationDate, message.CreationDate);
                    sw.WriteLine(Constants.LoggerBody.LoggerDescription, message.Description);
                    sw.WriteLine(Constants.LoggerBody.LoggerEnd);
                }
            }
        }

        public void LogToConsole(Message message)
        {
            var messageTypeName = Util.GetLogTypeName(message.LoggerSeverity);
            var sb = new StringBuilder();
            sb.AppendLine(Constants.LoggerBody.LoggerBegin);
            sb.AppendLine(string.Format(Constants.LoggerBody.LoggerCreatedBy, message.CreatedBy));
            sb.AppendLine(string.Format(Constants.LoggerBody.LogType, messageTypeName));
            sb.AppendLine(string.Format(Constants.LoggerBody.LoggerCreationDate, message.CreationDate));
            sb.AppendLine(string.Format(Constants.LoggerBody.LoggerDescription, message.Description));
            sb.AppendLine(Constants.LoggerBody.LoggerEnd);

            switch (message.LoggerSeverity) {
                case 3: Console.ForegroundColor = ConsoleColor.Red; break;
                case 2: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 1: Console.ForegroundColor = ConsoleColor.White; break;
            }

            Console.WriteLine(sb);
        }
    }
}
