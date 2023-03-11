using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList() ;
            }
        }

        public Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            return Task.Run(() =>
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(sql, parameters);
                }
            });
        }
    }
}
