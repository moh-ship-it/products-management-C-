using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRODUCT_MANGMENT.PL
{
    public partial class FRM_ADD_PRODUCT : Form
    {
        public string state = "add";
        BL.CLS_ADD_PRODUCT pp = new BL.CLS_ADD_PRODUCT();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();
            CMBCATGORES.DataSource = pp.CREATE_ALL_CATEGORES();
            CMBCATGORES.DisplayMember= "DESCRIPTION_CAT";
            CMBCATGORES.ValueMember = "Id_CAT";
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " الصور|*.PNG;*.GIF;*.JPG;";
            if (ofd.ShowDialog() == DialogResult.OK) 
            {
            pb.Image=Image.FromFile(ofd.FileName);
            }
        }

        private void FRM_ADD_PRODUCT_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, pb.Image.RawFormat);
                byte[] byteimage = ms.ToArray();

                pp.AD_Product(Convert.ToInt32(CMBCATGORES.SelectedValue), txtDesc.Text, txtref.Text, Convert.ToInt32(txtcont.Text), Convert.ToInt32(txtprice.Text), byteimage);
                MessageBox.Show("sucsess", "corect inser", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtref.Clear();
                //txtcont.Clear();
                //txtprice.Clear();
                //txtDesc.Clear();
                //pb.Image = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pb.Image.Save(ms, pb.Image.RawFormat);
                byte[] byteimage = ms.ToArray();

                pp.AD_ProdUPDATE_PROUDUCTuct(Convert.ToInt32(CMBCATGORES.SelectedValue), txtDesc.Text, txtref.Text, Convert.ToInt32(txtcont.Text), Convert.ToInt32(txtprice.Text), byteimage);
                MessageBox.Show("تم التعديل بنجاح", " تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            FRM_prouduct.getmainform.bunifuDataGridView1.DataSource = pp.CREATE_ALL_PROUDUCT();
        }


        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtref_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable dt = new DataTable();
                dt = pp.verifeproudct(txtref.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هاذة المعرف مةجود من قبل", "التحقق من المعرف", MessageBoxButtons.OK);
                    txtref.Focus();
                    txtref.SelectionStart = 0;
                    txtref.SelectionLength = txtref.TextLength;


                }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcont_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
