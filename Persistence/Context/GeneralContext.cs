using Microsoft.Data.SqlClient;
using System.Data;

namespace Persistence.Context
{
    public class GeneralContext
    {
        private readonly string _connectionString;

        public GeneralContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
