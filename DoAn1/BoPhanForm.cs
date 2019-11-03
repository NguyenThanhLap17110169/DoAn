using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class BoPhanForm : Form
    {
        public BoPhanForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            getdata();
        }
        public void getdata()
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand(" select * from BoPhan ;", mydb.getConnection);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                DataGridView1.DataSource = bsource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool kiemtraBoPhan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BoPhan WHERE MaBoPhan = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaBoPhan)  FROM BoPhan WHERE MaBoPhan = '" + ma + "' ";
            SqlCommand cmd1 = new SqlCommand(str, mydb.getConnection);

            mydb.openConnection();
            int n = (int)cmd1.ExecuteScalar();
            mydb.closeConnection();
            if (n >= 1)
            {
                return false;
            }
            else
                return true;
        }
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            BoPhan bophan = new BoPhan();
            string ma = txtMa.Text;
            string ten = txtTen.Text;
           
                if (verif()&&kiemtraBoPhan(ma))
                {
                    if (bophan.insertBoPhan(ma, ten))
                        MessageBox.Show("New Bộ Phận Added", "Add Bộ Phận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add Bộ Phận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Bộ Phận", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                getdata();
     
        }
        bool verif()
        {
            if ((txtMa.Text.Trim() == "")
                || (txtTen.Text.Trim() == ""))
            {
                return false;
            }
            else
                return true;
        }
        private void ButtonSua_Click(object sender, EventArgs e)
        {
            BoPhan bophan = new BoPhan();
            string ma = txtMa.Text;
            string ten = txtTen.Text;
           
                if (verif())
                {
                    try
                    {
                        if (bophan.UpdateBoPhan(ma, ten) )
                        {
                            MessageBox.Show("BoPhan Information Update", "Edit BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                getdata();
         
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            BoPhan bophan = new BoPhan();
            PhongBan phongban = new PhongBan();
            Nhom nhom = new Nhom();
           
                try
                {
                    string ma = Convert.ToString(txtMa.Text);
                    if ((MessageBox.Show("Are You Sure You Want To Delete This BoPhan", "Delete BoPhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (bophan.deleteBoPhan(ma))
                        {
                            MessageBox.Show("BoPhan Deleted", "Delete BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMa.Text = null;
                            txtTen.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("BoPhan Enter A Valid ID", "Delete BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter A Valid ID", "Delete BoPhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                getdata();
        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMa.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
 
    }
}
