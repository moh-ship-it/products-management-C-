using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRODUCT_MANGMENT.PL
{
    public partial class FRM_LOGIN : Form

    {
        BL.CLS_LOGIN log=new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtuser.Text, txtpassword.Text);
            if (Dt.Rows.Count > 0)
            {
                //MessageBox.Show("LOGIN SUCCESS!");
               FRM_MAIN.getmainform.ADDPRODUCTToolStripMenuItem.Enabled = true;

                //FRM_MAIN.getmainform.ADDSANFToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.BACKUPToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.CREATEToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.CUSTOMERToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.MANAGEPRODUCTToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.MANAGSANFToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.PRODECTMToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.USERSToolStripMenuItem.Enabled = true;
                FRM_MAIN.getmainform.MANAGECUSTOMERToolStripMenuItem.Enabled = true;
                this.Close();


            }
            else { MessageBox.Show("LOGIN UNSUCCESS"); }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
