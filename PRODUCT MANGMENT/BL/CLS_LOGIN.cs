using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace PRODUCT_MANGMENT.BL
{
    internal class CLS_LOGIN
    {
        public DataTable LOGIN(string ID,string PWD)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 20);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 20);
            param[1].Value = PWD;

            DAL.Open();
            DataTable Dt = new DataTable();
            Dt=DAL.SelectData("SP_LOGIN",param);
            DAL.Close();
            return Dt;
             
        }

    }
}
