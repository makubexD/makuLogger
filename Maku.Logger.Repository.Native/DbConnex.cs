using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Maku.Logger.Repository.Native
{
    public class DbConnex
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
    }
}
