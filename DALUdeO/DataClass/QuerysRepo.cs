using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.DataClass
{
    public static class QuerysRepo
    {
        public const string SelectAll = "SELECT * FROM TABLA";
        public const string SelectByID = "SELECT * FROM TABLA WHERE COLUMNAID = ID";
        public const string SelectAllByFilters = "SELECT * FROM TABLA ";
        public const string SelectByIDByFilters = "SELECT * FROM TABLA WHERE COLUMNAID = ID";
        public const string AddRow = "INSERT INTO TABLA VALUES(VALORES)";
        public const string UpdateRow = "UPDATE TABLA SET VALORES WHERE FILTRO";

        public enum TipoQuery { Todos, PorId, TodosConFiltros, PorIdConFiltro, AddRow, UpdateRow }
    }
}
