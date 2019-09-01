using DALUdeO.Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Reader
{
    public abstract class ObjectReaderBase<T>
    {
        protected abstract IDbConnection GetConecction();
        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get; }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand commnad);
        protected abstract MapperBase<T> GetMapper();
        public Collection<T> Execute()
        {
            Collection<T> collection = new Collection<T>();
            using (IDbConnection connection = GetConecction())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = this.CommandText;
                command.CommandType = this.CommandType;

                foreach (IDbDataParameter parametro in this.GetParameters(command))
                {
                    command.Parameters.Add(parametro);
                }
                try
                {
                    connection.Open();
                    using (IDataReader lector = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            collection = mapper.MapAll(lector);
                            return collection;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            lector.Close();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }


    }
}
