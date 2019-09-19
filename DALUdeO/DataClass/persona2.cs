using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALUdeO.Reader;
namespace DALUdeO.DataClass
{
    class persona2 : StoreProcedure
    {
        public bool Leer()
        {

            return LeerTabla("sp_mostrar22");
        }

        public bool Insertar()
        {
            return LeerTabla("sp_insertar");
        }
    }


}
