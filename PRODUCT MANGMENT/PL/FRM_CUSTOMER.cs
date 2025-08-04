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

namespace PRODUCT_MANGMENT.PL
{
    public partial class FRM_CUSTOMER : Form
    {

        int ID,position;
        BL.CLS_CUSTOMER cust = new BL.CLS_CUSTOMER();
        public FRM_CUSTOMER()
        {
            InitializeComponent();
            this.dgview.DataSource = cust.GET_ALLL_CUSTOMERS();
            dgview.Columns[0].Visible = false;
            dgview.Columns[5].Visible = false;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

            string imagePath = @"D:\PRODUCT MANGMENT\Resources\8666693_search_icon";
            if (System.IO.File.Exists(imagePath))
            {
                imagecustm.Image = Image.FromFile(imagePath);
            }
            txtfirst.Clear();
            txtlast.Clear();
            txtEmail.Clear();
            txtTel.Clear();
        
            txtfirst.Focus();
        }

        private void FRM_CUSTOMER_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfirst.Text==""&&txtlast.Text==""&&txtTel.Text==""&&txtEmail.Text=="")
                {
                    MessageBox.Show("يجب ملاء جميع الحقول");
                    return;

                }


                MemoryStream ms = new MemoryStream();
                imagecustm.Image.Save(ms, imagecustm.Image.RawFormat);
                byte[] picture = ms.ToArray();

                cust.ADD_customur(txtfirst.Text, txtlast.Text, txtTel.Text, txtEmail.Text, picture);
                MessageBox.Show("Sucsuull add Customer", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgview.DataSource = cust.GET_ALLL_CUSTOMERS();

            }
            catch
            {
                return;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("لايوجد");
                return;
            
            }
            if(MessageBox.Show("هل انت متاكد انك تريد الحذف", "الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);
                MessageBox.Show("تم الحذف بنجاح", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgview.DataSource = cust.GET_ALLL_CUSTOMERS();

            }
        }

        private void btmedit_Click(object sender, EventArgs e)
        {
            try
            {

                if (ID == 0)
                {
                    MessageBox.Show("لايوجد");
                    return;

                }


                MemoryStream ms = new MemoryStream();
                imagecustm.Image.Save(ms, imagecustm.Image.RawFormat);
                byte[] picture = ms.ToArray();
               

                cust.EDITE_customur(txtfirst.Text, txtlast.Text, txtTel.Text, txtEmail.Text, picture,ID);
                MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgview.DataSource = cust.GET_ALLL_CUSTOMERS();

            }
            catch
            {
                return;
            }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (position == cust.GET_ALLL_CUSTOMERS().Rows.Count - 1)
            {
                return;
            }
            position += 1;
            Navigate(position);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void imagecustm_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " الصور|*.PNG;*.GIF;*.JPG;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagecustm.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void txtfirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtlast.Focus();
            }
        }

        private void txtlast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }

        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.Focus();
            }
        }

        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgview_DoubleClick(object sender, EventArgs e)
        {
            try
                
            {
                imagecustm.Image = null;
                ID=Convert.ToInt32( dgview.CurrentRow.Cells[0].Value);
                this.txtfirst.Text = dgview.CurrentRow.Cells[1].Value.ToString();
                this.txtlast.Text = dgview.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dgview.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dgview.CurrentRow.Cells[4].Value.ToString();
                byte[] picture = (byte[])dgview.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                imagecustm.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dgview.DataSource=cust.SEARCH_CUSTOMER(txtsearch.Text);
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            dgview.DataSource = cust.SEARCH_CUSTOMER(txtsearch.Text);
            }

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            position = cust.GET_ALLL_CUSTOMERS().Rows.Count - 1;
            Navigate(position);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (position == 0)
            {
                return;
            }
            position -= 1;
            Navigate(position);
        }

        void Navigate(int index)
        {
            imagecustm.Image = null;
            DataTable Dt = cust.GET_ALLL_CUSTOMERS();

            txtfirst.Text = Dt.Rows[index][1].ToString();
            txtlast.Text = Dt.Rows[index][2].ToString();
            txtTel.Text = Dt.Rows[index][3].ToString();
            txtEmail.Text = Dt.Rows[index][4].ToString();
            byte[] picture = (byte[])Dt.Rows[index][5];
            MemoryStream ms = new MemoryStream(picture);
            imagecustm.Image = Image.FromStream(ms);


        }
    }
}
