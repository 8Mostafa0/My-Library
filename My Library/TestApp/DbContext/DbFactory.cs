using Dapper;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace My_Library.DbContext
{
    public class DbFactory
    {
        #region Dependencies
        private readonly string _masterConnectionStrin;
        private readonly string _desiredDbName;
        #endregion

        #region Contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="dbName"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public DbFactory(string server, string dbName, string user, string password)
        {
            _desiredDbName = dbName;
            _masterConnectionStrin = $"Server={server};Database=master;User Id={user},Password={password};TrustServerCertificate=True;";
        }
        #endregion


        #region Methods
        /// <summary>
        /// check database exist or not
        /// </summary>
        public async Task CreateDatabaseAsync()
        {
            using var Connection = new SqlConnection(_masterConnectionStrin);
            try
            {
                Connection.Open();
                string sql = @$"SELECT 1 FROM sys.databases WHERE name = @DbName;";

                bool DatabaseExists = await Connection.ExecuteScalarAsync<bool>(sql, new { DbName = _desiredDbName });
                MessageBox.Show(DatabaseExists ? "database Created" : $"Database Not Created {DatabaseExists}");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            Connection?.Close();
        }
        #endregion
    }
}
