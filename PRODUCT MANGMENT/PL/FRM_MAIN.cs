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
    public partial class FRM_MAIN : Form

    {
      
        private static FRM_MAIN frm;
        static void frm_frormclosed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_MAIN getmainform
        {
            get{
                if (frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_frormclosed);
                }
                return frm;


            }
        }
        public FRM_MAIN()
        {
            if (frm == null) 
                frm=this;
            InitializeComponent();
            this.CREATEToolStripMenuItem.Enabled = false;
            this.BACKUPToolStripMenuItem.Enabled = false;
            this.CUSTOMERToolStripMenuItem.Enabled = false;
            this.MANAGECUSTOMERToolStripMenuItem.Enabled = false;  
            this.MANAGEPRODUCTToolStripMenuItem.Enabled = false;
            this.MANAGEUSERToolStripMenuItem.Enabled = false;
            this.MANAGSALToolStripMenuItem.Enabled = false; 
            this.MANAGSANFToolStripMenuItem.Enabled = false;
            this.PRODECTMToolStripMenuItem.Enabled = false;
            this.USERSToolStripMenuItem.Enabled = false;

        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void SIGINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm=new FRM_LOGIN();
            //frm.MdiParent = this;
            frm.ShowDialog();

        }

        private void ADDPRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm=new FRM_ADD_PRODUCT();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void MANAGEPRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_prouduct frm=new FRM_prouduct();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MANAGSANFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATAGORES frm = new FRM_CATAGORES();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void ADDCUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER frmc = new FRM_CUSTOMER();
            //frmc.MdiParent = this;
            frmc.ShowDialog();

        }

        private void MANAGECUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER frmc = new FRM_CUSTOMER();
            //frmc.MdiParent = this;
            frmc.ShowDialog();
        }
    }
}
