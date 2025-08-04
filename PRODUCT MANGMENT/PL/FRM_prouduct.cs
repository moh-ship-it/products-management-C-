using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace PRODUCT_MANGMENT.PL
{
    public partial class FRM_prouduct : Form

    {
        private static FRM_prouduct frm;
        static void frm_frormclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_prouduct getmainform
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_prouduct();
                    frm.FormClosed += new FormClosedEventHandler(frm_frormclosed);
                }
                return frm;


            }
        }
        BL.CLS_ADD_PRODUCT prd=new BL.CLS_ADD_PRODUCT();
        public FRM_prouduct()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.bunifuDataGridView1.DataSource = prd.CREATE_ALL_PROUDUCT();
        }

        private void FRM_prouduct_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.searchprouduct(textsearch.Text);
            this.bunifuDataGridView1.DataSource= Dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد فعلا حذف المنتج", "الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                prd.Deleteproduct(this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show(" "," ",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bunifuDataGridView1.DataSource = prd.CREATE_ALL_PROUDUCT();
            }
            else
            {
                MessageBox.Show("الغاء الحذف","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm=new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT fRM=new FRM_ADD_PRODUCT();
            //fRM.state = "update";
            fRM.txtref.Text = this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            fRM.txtDesc.Text = this.bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            fRM.txtcont.Text = this.bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            fRM.txtprice.Text = this.bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            fRM.CMBCATGORES.Text = this.bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
            fRM.Text="تحديث" + this.bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            fRM.bunifuButton2.Text = "تحديث";
            fRM.state = "update";
            fRM.txtref.ReadOnly = true;
            byte[] IMAGE = (byte[])prd.GET_IMG_PROUDUCT(this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(IMAGE);
            fRM.pb.Image = Image.FromStream(ms);
            fRM.ShowDialog();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            //FRM_REVIEW fRM = new FRM_REVIEW();
            //byte[] IMAGE = (byte[])prd.GET_IMG_PROUDUCT(this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            //MemoryStream ms = new MemoryStream(IMAGE);
            //fRM.pb.Image = Image.FromStream(ms);
            FRM_REVIEW fRM = new FRM_REVIEW();
            byte[] IMAGE = (byte[])prd.GET_IMG_PROUDUCT(this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(IMAGE);
            fRM.pictureBox1.Image = Image.FromStream(ms);
            fRM.ShowDialog();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            RPT1.rpt_single myreport = new RPT1.rpt_single();
            myreport.SetParameterValue("@ID", this.bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT1.FRM_RPT_PROUDUCT myform = new RPT1.FRM_RPT_PROUDUCT();
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

            // RPT1.CrystalReport1 mm = new RPT1.CrystalReport1();
            RPT1.rpt_all_product myreport = new RPT1.rpt_all_product();
            RPT1.FRM_RPT_PROUDUCT myform = new RPT1.FRM_RPT_PROUDUCT();
            myform.crystalReportViewer1.ReportSource = myreport;
            myform.ShowDialog();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            RPT1.rpt_all_product myreport = new RPT1.rpt_all_product();
            //create export opton
            ExportOptions export = new ExportOptions();
            DiskFileDestinationOptions defexoption = new DiskFileDestinationOptions();
            ExcelFormatOptions excelformat = new ExcelFormatOptions();
            defexoption.DiskFileName = @"E:\prouductslist.xls";
            
            export = myreport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatType = ExportFormatType.Excel;
            export.ExportFormatOptions = excelformat;
            export.ExportDestinationOptions = defexoption;
            myreport.Export();
            MessageBox.Show("sucssuflu export", "export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
