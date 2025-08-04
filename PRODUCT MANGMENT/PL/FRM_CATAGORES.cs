using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PRODUCT_MANGMENT.PL
{
    public partial class FRM_CATAGORES : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Server=MYDEVICEE;Database=Prouduct_DB;integrated Security=true");
        SqlDataAdapter da;
        DataTable dt=new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;

        public FRM_CATAGORES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select Id_CAT as'المعرف',DESCRIPTION_CAT as 'الصنف' from CATEGORYES", sqlcon);
            da.Fill(dt);
            dglist.DataSource = dt;
            textID.DataBindings.Add("text", dt, "المعرف");
            textDES.DataBindings.Add("text", dt, "الصنف");
            bmb = this.BindingContext[dt];
            label1.Text = (bmb.Position + 1)+"/" + bmb.Count ;
            btnadd.Enabled = false;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;


        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnexportallpdf_Click(object sender, EventArgs e)
        {
            RPT1.rpt_sigle_catagores myreport = new RPT1.rpt_sigle_catagores();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions defexoption = new DiskFileDestinationOptions();
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            defexoption.DiskFileName = @"E:\CAtGORE_DETAILS.pdf";

            export = myreport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            export.ExportFormatOptions = pdfformat;
            export.ExportDestinationOptions = defexoption;
            //myreport.Refresh();
            myreport.SetParameterValue("@id", Convert.ToInt32(textID.Text));
            myreport.Export();
            MessageBox.Show("sucssuflu export CAtGORE_DETAILS", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnexporttopdf_Click(object sender, EventArgs e)
        {
            RPT1.rpt_all_catgores myreport = new RPT1.rpt_all_catgores();
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions defexoption = new DiskFileDestinationOptions();
            PdfFormatOptions pdfformat = new PdfFormatOptions();
            defexoption.DiskFileName = @"E:\CAtGOREESLIST.pdf";

            export = myreport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            export.ExportFormatOptions = pdfformat;
            export.ExportDestinationOptions = defexoption;
            myreport.Refresh();
            myreport.Export();
            MessageBox.Show("sucssuflu export LISTCATTGOReES", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnprintall_Click(object sender, EventArgs e)
        {
            RPT1.rpt_sigle_catagores rpt = new RPT1.rpt_sigle_catagores();
            RPT1.FRM_RPT_PROUDUCT frmp = new RPT1.FRM_RPT_PROUDUCT();
            rpt.SetParameterValue("@id", Convert.ToInt32(textID.Text));
            frmp.crystalReportViewer1.ReportSource = rpt;
            frmp.ShowDialog();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnadd.Enabled = true;
            btnnew.Enabled = false;
           
           int idd = (Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1);

          textID.Text = idd.ToString();
            
           textDES.Focus();
            
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            
            RPT1.rpt_all_catgores rpt = new RPT1.rpt_all_catgores();
            RPT1.FRM_RPT_PROUDUCT frmp = new RPT1.FRM_RPT_PROUDUCT();
            rpt.Refresh();
            frmp.crystalReportViewer1.ReportSource = rpt;
            frmp.ShowDialog();
        }

        private void btmedit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("add sucssus", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("delete sucssus", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
      
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("add sucssus", "ADD",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnadd.Enabled = false;
            btnnew.Enabled = true;
            label1.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }
    }
}
