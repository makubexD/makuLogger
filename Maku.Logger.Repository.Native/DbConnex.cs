using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Maku.Logger.Repository.Native
{
    public class DbConnex //: IDisposable
    {
        public DbConnex()
        {
            Database = CreateDatabase();
        }

        public SqlDatabase Database { get; set; }

        private SqlDatabase CreateDatabase()
        {
            var databaseFactory = new DatabaseProviderFactory();
            return databaseFactory.Create("LoggerConex") as SqlDatabase;
        }


        //public SqlConnection Connection { get; set; }

        //public DbConnex()
        //{
        //    var conex = ConfigurationManager.ConnectionStrings["Conex"];
        //    if (Connection != null)
        //        Connection = new SqlConnection(conex.ConnectionString);
        //}

        //public DbConnex(string conexString)
        //{
        //    Connection = new SqlConnection(conexString);
        //}

        //public DbConnex(SqlConnection conex)
        //{
        //    Connection = conex;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);

        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposing) return;
        //    if (Connection == null) return;
        //    Connection.Close();
        //    Connection.Dispose();
        //}  


    }
}
