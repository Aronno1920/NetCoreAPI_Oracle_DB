using DMSAPI.Interfaces.Common;
using Oracle.ManagedDataAccess.Client;

namespace DMSAPI.Repositories.Common
{
    public class DBManager : IDBManager
    {
        private IConfiguration _config;
        private string _connectionString;

        public DBManager(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public OracleConnection GetConnection()
        {
            OracleConnection connection = new OracleConnection(_connectionString);
            return connection;
        }

        public OracleCommand GetCommand()
        {
            OracleConnection connection = GetConnection();
            OracleCommand cmd = connection.CreateCommand();
            return cmd;
        }
    }
}
