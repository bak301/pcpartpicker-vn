using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PcPartPickerBackendAPI.Repository
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection Connection {
            get {
                return new SqlConnection(ConnectionString);
            }
        }

        public string ConnectionString { get; }

        public BaseRepository(IConfiguration configuration)
        {
            this.ConnectionString = configuration["ConnectionStrings:PcPartPickerDb"];
        }

        public void Dispose()
        {
        }     
    }
}
