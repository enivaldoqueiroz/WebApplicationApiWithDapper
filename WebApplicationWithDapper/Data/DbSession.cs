using System.Data;
using System.Data.SqlClient;

namespace WebApplicationWithDapper.Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; set; }

        //public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration) 
        {
            Connection = new SqlConnection(
                configuration.GetConnectionString("DefaulConnection"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Close();
    }
}
