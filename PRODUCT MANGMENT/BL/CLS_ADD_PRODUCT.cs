using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace PRODUCT_MANGMENT.BL
{
    internal class CLS_ADD_PRODUCT
    {
        public DataTable CREATE_ALL_CATEGORES()
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("CREATE_ALL_CATEGORES", null); 
            DAL.Close();
            return Dt;

        }
        public void AD_Product (int ID_cat,string LAPLE_PROUD,string ID_PROUD,int QTE,int PRICE,byte[] IMG)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_cat;

            parm[1] = new SqlParameter("@ID_PROUD", SqlDbType.VarChar,30);
            parm[1].Value = ID_PROUD;

            parm[2] = new SqlParameter("@LAPLE", SqlDbType.VarChar,30);
            parm[2].Value = LAPLE_PROUD;

            parm[3] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[3].Value = QTE;

            parm[4] = new SqlParameter("@PRICE ", SqlDbType.Int);
            parm[4].Value = PRICE;

            parm[5] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[5].Value = IMG;


            DAL.ExecuteCommand("ADD_PROUDUCT", parm);
            DAL.Close();



        }



        public void AD_ProdUPDATE_PROUDUCTuct(int ID_cat, string LAPLE_PROUD, string ID_PROUD, int QTE, int PRICE, byte[] IMG)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_cat;

            parm[1] = new SqlParameter("@ID_PROUD", SqlDbType.VarChar, 30);
            parm[1].Value = ID_PROUD;

            parm[2] = new SqlParameter("@LAPLE", SqlDbType.VarChar, 30);
            parm[2].Value = LAPLE_PROUD;

            parm[3] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[3].Value = QTE;

            parm[4] = new SqlParameter("@PRICE ", SqlDbType.Int);
            parm[4].Value = PRICE;

            parm[5] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[5].Value = IMG;


            DAL.ExecuteCommand("UPDATE_PROUDUCT", parm);
            DAL.Close();



        }
        public DataTable verifeproudct(string ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] parm=new SqlParameter[1];
            parm[0]=new SqlParameter("@ID", SqlDbType.VarChar,50);
            parm[0].Value = ID;
            Dt = DAL.SelectData("verifeproudct", parm);
            DAL.Close();
            return Dt;

        }
        public DataTable CREATE_ALL_PROUDUCT()
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("CREATE_ALL_PROUDUCT", null);//ترجع الكويري بتمرير اسمه
            DAL.Close();
            return Dt;

        }
        public DataTable searchprouduct(string ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            Dt = DAL.SelectData("searchprouduct", parm);
            DAL.Close();
            return Dt;

        }
        public DataTable GET_IMG_PROUDUCT(string ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            Dt = DAL.SelectData("GET_IMG_PROUDUCT", parm);
            DAL.Close();
            return Dt;

        }
        public void Deleteproduct(string ID)
        {
            DAL.DataAccesLayer DAL = new DAL.DataAccesLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar,50);
            parm[0].Value = ID;

            DAL.ExecuteCommand("Deleteproduct", parm);
            DAL.Close();



        }



    }
}
