using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Mapper
{
    public abstract class MapperBase<T>
    {
        //Creando el tipo que tendra T
        protected abstract T Map(IDataRecord registro);
        //Mapeando el objeto en una lista de tipo Collection
        public Collection<T> MapAll(IDataReader lector) {
            Collection<T> coleccion = new Collection<T>();

            //Validando cada propiedad del objeto
            while (lector.Read())
            {
                try
                {
                    //agregando el objeto a la conexion ya mapeado
                    coleccion.Add(Map(lector));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return coleccion;
        }
    }
}
