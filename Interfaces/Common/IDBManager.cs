using Oracle.ManagedDataAccess.Client;

namespace DMSAPI.Interfaces.Common
{
    public interface IDBManager
    {
        OracleConnection GetConnection();

        OracleCommand GetCommand();
    }
}
