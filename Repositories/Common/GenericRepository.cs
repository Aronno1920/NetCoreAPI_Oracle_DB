using DMSAPI.Interfaces.Common;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Reflection;

namespace DMSAPI.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDBManager _dbManager;

        public GenericRepository(IDBManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<T> GetByIdAsync(string query)
        {
            using (OracleConnection connection = _dbManager.GetConnection())
            {
                connection.Open();
                using (OracleCommand command = _dbManager.GetCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.BindByName = true;
                        command.CommandText = query;
                        //command.Parameters.Add(":id", idValue);

                        DbDataReader reader = await command.ExecuteReaderAsync();
                        if (await reader.ReadAsync())
                        {
                            T item = Activator.CreateInstance<T>();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader[prop.Name]);
                                }
                            }

                            return item;
                        }
                        reader.DisposeAsync();
                        return null; // No matching entity found
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        public async Task<List<T>> GetAllAsync(string query)
        {
            List<T> items = new List<T>();

            using (OracleConnection connection = _dbManager.GetConnection())
            {
                connection.Open();
                using (OracleCommand command = _dbManager.GetCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.BindByName = true;
                        command.CommandText = query;

                        DbDataReader reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            T item = Activator.CreateInstance<T>();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, reader[prop.Name]);
                                }
                            }

                            items.Add(item);
                        }
                        reader.DisposeAsync();
                        return items;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}