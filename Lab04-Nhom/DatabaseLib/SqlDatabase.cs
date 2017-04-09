using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseLib
{
    public class SqlDatabase
    {
        public string ConnectionStringName { get; set; }
        public SqlDatabase(string conString = "data")
        {
            ConnectionStringName = conString;
        }
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }
        public DataTable GetDataTable(string cmdText, List<SqlParameter> param = null)
        {
            if (param == null)
            {
                param = new List<SqlParameter>();
            }
            CommandType cmdType = CommandType.Text;
            if (!cmdText.Contains(' '))
                cmdType = CommandType.StoredProcedure;
            var table = new DataTable();
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    //cmd.Connection
                    cmd.CommandText = cmdText;
                    cmd.CommandType = cmdType;
                    foreach (var item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                    var reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                }
                con.Close();
                con.Dispose();
            }
            return table;
        }
        public int ExecuteNonQuery(string cmdText, List<SqlParameter> param = null)
        {
                if (param == null)
                {
                    param = new List<SqlParameter>();
                }
                CommandType cmdType = CommandType.Text;
                if (!cmdText.Contains(' '))
                    cmdType = CommandType.StoredProcedure;
                int result;
                using (var con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        //cmd.Connection
                        cmd.CommandText = cmdText;
                        cmd.CommandType = cmdType;
                        foreach (var item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    con.Dispose();
                }
                return result;
        }
    }

    public static class DataExtensions
    {
        public static int Insert(this SqlDatabase db, object item, string pk = null)
        {
            return db.ExecuteNonQuery(item.ToSqlInsert(pk), item.ToSqlParameter());
        }
        public static int Update(this SqlDatabase db, object item, string id1 = null, string id2 = null)
        {
            return db.ExecuteNonQuery(item.ToSqlUpdate(id1, id2), item.ToSqlParameter());
        }
        public static int Delete(this SqlDatabase db, object item, string id1 = null, string id2 = null)
        {
            return db.ExecuteNonQuery(item.ToSqlDelete(id1, id2), item.ToSqlParameter());
        }
        public static List<T> GetList<T>(this SqlDatabase db, string cmdText, List<SqlParameter> param = null) where T : new()
        {
            var dtTable = db.GetDataTable(cmdText, param);
            if (dtTable.Rows.Count == 0)
                return new List<T>();
            return dtTable.To<T>();
        }
        public static T GetOne<T>(this SqlDatabase db, string cmdText, List<SqlParameter> param = null) where T : new()
        {
            return GetList<T>(db, cmdText, param).FirstOrDefault();
        }
        public static void SetFromRow(this object item, DataRow row)
        {
            if (row == null)
                return;
            foreach (DataColumn c in row.Table.Columns)
            {
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }
        public static T To<T>(this DataRow row) where T : new()
        {
            T item = new T();
            item.SetFromRow(row);
            return item;
        }
        public static List<T> To<T>(this DataTable tbl) where T : new()
        {
            List<T> listItems = new List<T>();
            foreach (DataRow r in tbl.Rows)
            {
                listItems.Add(r.To<T>());
            }
            return listItems;
        }
    }
}
