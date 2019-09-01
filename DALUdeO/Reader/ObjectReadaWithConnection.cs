using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Reader
{
    public abstract class ObjectReadaWithConnection<T> : ObjectReaderBase<T>
    {
        private static string ConnectionString = @"Server=localhost;Database=UdeoDAL;Uid=root;";
        protected override IDbConnection GetConecction()
        {
            IDbConnection connection = new MySqlConnection(ConnectionString);
            return connection;
        }
    }
}
