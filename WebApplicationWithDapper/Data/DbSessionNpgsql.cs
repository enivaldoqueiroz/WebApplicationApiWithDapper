using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace WebApplicationWithDapper.Data
{
    public class DbSessionNpgsql : IDisposable
    {
        public IDbConnection Connection { get; set; }

        //public IDbTransaction Transaction { get; set; }

        public DbSessionNpgsql(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(
                configuration.GetConnectionString("DefaulConnection"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Close();
    }
}
