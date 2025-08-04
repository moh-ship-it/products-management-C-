using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PRODUCT_MANGMENT.BL
{
    class CLS_CUSTOMER
    {
        // const int V = 5;

        public DataTable GET_ALLL_CUSTOMERS()
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            
            Dt = DAL.SelectData("get_all_categories", null);
            DAL.Close();
            return Dt;

        }
        public DataTable SEARCH_CUSTOMER(string CRITERATION)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            SqlParameter []parm=new SqlParameter[1];
            parm[0] = new SqlParameter("@CRITERATION", SqlDbType.VarChar, 50);
            parm[0].Value = CRITERATION;
            Dt = DAL.SelectData("SEARCH_CUSTOMER", parm);
            DAL.Close();
            return Dt;

        }

        public void ADD_customur(string First_name, string Last_name, string Tel, string Email, byte[] picture)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();
           

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@First_name", SqlDbType.VarChar,25);
            param[0].Value = First_name; ;

            param[1] = new SqlParameter("@Last_name", SqlDbType.VarChar, 25);
            param[1].Value = Last_name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar,25);
            param[3].Value = Email;


            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = picture;


            DAL.ExecuteCommand("ADD_customur", param);
            DAL.Close();



        }

        public void EDITE_customur(string First_name, string Last_name, string Tel, string Email, byte[] picture,int ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();


            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@First_name", SqlDbType.VarChar, 25);
            param[0].Value = First_name; ;

            param[1] = new SqlParameter("@Last_name", SqlDbType.VarChar, 25);
            param[1].Value = Last_name;

            param[2] = new SqlParameter("@Tel", SqlDbType.NChar, 15);
            param[2].Value = Tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            param[3].Value = Email;


            param[4] = new SqlParameter("@Picture", SqlDbType.Image);
            param[4].Value = picture;

            param[5] = new SqlParameter("@ID", SqlDbType.Int);
            param[5].Value = ID;
             

            DAL.ExecuteCommand("EDITE_customur", param);
            DAL.Close();



        }
        public void DELETE_CUSTOMER(int ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();


            SqlParameter[] param = new SqlParameter[1];
        
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;


            DAL.ExecuteCommand("DELETE_CUSTOMER", param);
            DAL.Close();



        }
    }
}
