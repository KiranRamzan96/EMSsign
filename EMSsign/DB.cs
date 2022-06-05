using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EMSsign
{
    class DB
    {
        private string conStr = @"Data Source=DESKTOP-MA08TPP; Initial Catalog=Employee; Integrated Security=true";
        public SqlConnection con { get; set; }

          public DB()
          {
               con = new SqlConnection(conStr);
          }

          public DataTable GetTable(string sql)
          {
               DataTable dt2 = new DataTable();
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               dt2.Load(cmd.ExecuteReader());
               con.Close();
               return dt2;
          }

          public void ExeSQL(string sql)
          {
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               cmd.ExecuteNonQuery();
               con.Close();
          }

          public string ExeSQLResult(string sql)
          {
               string str = null;
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               str = cmd.ExecuteScalar().ToString();
               con.Close();
               return str;
          }
     }

   
}