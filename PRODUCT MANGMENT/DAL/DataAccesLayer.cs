using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PRODUCT_MANGMENT.DAL
{
    internal class DataAccesLayer
    {
        SqlConnection SqlConnection;
        //consructor to inistionalizy the connection object
        public DataAccesLayer()
        {
            SqlConnection = new SqlConnection(@"Server=.;Database=products_DB;integrated Security=true");
        }


        //method to open the connection

        public void Open()
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();

            }
        }

        public void Close() 
        { 
            if(SqlConnection.State == ConnectionState.Open)
            {  SqlConnection.Close(); }
        
        }
        //method to read data from database
        public DataTable SelectData(string stored_procdure,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType=CommandType.StoredProcedure;
            sqlcmd.CommandText=stored_procdure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }

            }
            SqlDataAdapter da=new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            return dt;

        }
        //method to insert ,update,and delete data form
        public void ExecuteCommand(string stored_procdure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();   
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procdure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();   
        }  
    }
}
