using Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Utils
{
    public static class QueryProcessor
    {
        public static string QueryByID(string query, string NombreTabla, string NombreColumna, string IdCampo)
        {
            return query.Replace("TABLA", NombreTabla).Replace("COLUMNAID", NombreColumna).Replace("ID", IdCampo.ToString());
        }

        public static string QueryAll(string query, string NombreTabla)
        {
            return query.Replace("TABLA", NombreTabla);
        }
        public static string QueryByID(string query, string NombreTabla, string NombreColumna, int IdCampo, object DataModel)
        {
            return query.Replace("TABLA", NombreTabla).Replace("COLUMNAID", NombreColumna).Replace("ID", IdCampo.ToString()) + " WHERE " + ProcessDataModel(DataModel);
        }

        public static string QueryAll(string query, string NombreTabla, object DataModel)
        {
            return query.Replace("TABLA", NombreTabla) + " WHERE " + ProcessDataModel(DataModel);
        }
        private static string ProcessDataModel(object DataModel)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var propertyInfo in DataModel.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(DataModel) != null)
                {
                    sb.Append(propertyInfo.Name + " = " + " '" + propertyInfo.GetValue(DataModel).ToString() + "' AND ");
                }
            }


            return sb.ToString().Substring(0, sb.ToString().Length - 4);
        }
        public static string UpdateRow(string query, string NombreTabla, object DataModel)
        {
            var strWhere = GetWhereByPrimaryKey(DataModel);
            return query.Replace("TABLA", NombreTabla).Replace("VALORES", ProcessDataModelUpdate(DataModel)).Replace("FILTRO", strWhere);
        }

        private static string GetWhereByPrimaryKey(object DataModel)
        {
            StringBuilder sb = new StringBuilder();
            var PrimaryKeyProperty = DataModel.GetType().GetProperties();
            PropertyInfo pk = PrimaryKeyProperty[0];
            sb.Append(pk.Name + "= '" + pk.GetValue(DataModel).ToString() + "'");

            return sb.ToString();
        }

        public static string AddRow(string query, string NombreTabla, object DataModel)
        {
            return query.Replace("TABLA", NombreTabla).Replace("VALORES", ProcessDataModelInsert(DataModel));
        }
        private static string ProcessDataModelInsert(object DataModel)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var propertyInfo in DataModel.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(DataModel) != null)
                {
                    if (propertyInfo.PropertyType.Name == "DateTime")
                    {
                        if (propertyInfo.GetValue(DataModel).ToString() != "1/01/0001 00:00:00")
                        {
                            DateTime date = Convert.ToDateTime(propertyInfo.GetValue(DataModel));
                            sb.Append("'" + date.ToString("yyyy-MM-dd") + "' , ");
                        }
                        else
                        {
                            DateTime date = Convert.ToDateTime(propertyInfo.GetValue(DataModel));
                            sb.Append("null" + " ,");
                        }
                    }
                    else
                    {
                        sb.Append("'" + propertyInfo.GetValue(DataModel).ToString() + "' , ");
                    }

                }
            }


            return sb.ToString().Substring(0, sb.ToString().Length - 2);
        }
        private static string ProcessDataModelUpdate(object DataModel)
        {
            StringBuilder sb = new StringBuilder();
            var counter = 0;
            foreach (var propertyInfo in DataModel.GetType().GetProperties())
            {
                counter++;
                if (propertyInfo.GetValue(DataModel) != null && counter > 1)
                {
                    sb.Append(propertyInfo.Name + " = " + "'" + propertyInfo.GetValue(DataModel).ToString() + "' , ");
                }
            }


            return sb.ToString().Substring(0, sb.ToString().Length - 2);
        }
    }
}
