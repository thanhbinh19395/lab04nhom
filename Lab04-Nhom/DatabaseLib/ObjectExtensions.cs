using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
    public static class ObjectExtensions
    {
        public static string ToSqlInsert(this object obj, string tableName = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                tableName = obj.GetType().Name;
            var props = obj.GetType().GetProperties();
            var listPropertyName = props.Select(x => x.Name).ToList();
            var cols = string.Join(",", listPropertyName.Select(x => "[" + x + "]"));
            var param = string.Join(",", listPropertyName.Select(x => "@" + x));
            return string.Format("insert into {0}({1}) values ({2})", tableName, cols, param);

        }
        public static string ToSqlUpdate(this object obj, string idColumn1 = null, string idColumn2 =null, string tableName = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                tableName = obj.GetType().Name;
            if (string.IsNullOrWhiteSpace(idColumn1))
                idColumn1 = obj.GetType().GetProperties().FirstOrDefault().Name;
            var props = obj.GetType().GetProperties();
            var listPropertyName = props.Select(x => x.Name).ToList();
            var set = string.Join(",", listPropertyName.Select(x => "[" + x + "] = @" + x));
            var condition = "[" + idColumn1 + "] = @" + idColumn1;
            if (idColumn2!=null)
                condition += " and [" + idColumn2 + "] = @" + idColumn2;
            return string.Format("update {0} set {1} where {2}", tableName, set, condition);
        }
        public static string ToSqlDelete(this object obj, string idColumn1 = null, string idColumn2 = null, string tableName = null)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                tableName = obj.GetType().Name;
            if (string.IsNullOrWhiteSpace(idColumn1))
                idColumn1 = obj.GetType().GetProperties().FirstOrDefault().Name;
            var condition = "[" + idColumn1 + "] = @" + idColumn1;
            if (idColumn2 != null)
                condition += " and [" + idColumn2 + "] = @" + idColumn2;
            return string.Format("delete from {0} where {1}", tableName, condition);
        }
        public static List<SqlParameter> ToSqlParameter(this object obj)
        {
            var props = obj.GetType().GetProperties();
            var param = new List<SqlParameter>();
            foreach (var item in props)
            {
                param.Add(new SqlParameter
                {
                    ParameterName = item.Name,
                    Value = item.GetValue(obj) ?? DBNull.Value
                });
            }
            return param;
        }
    }
}
