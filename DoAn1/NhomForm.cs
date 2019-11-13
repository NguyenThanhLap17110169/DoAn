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
    public partial class NhomForm : Form
    {
        public NhomForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            getdata();
            Refresh();
        }
        public void Refresh()
        {
            string str1 = "select * from PhongBan";
            ComboBoxPhongBan.Refresh();
            ComboBoxPhongBan.DataSource = getGroup(str1);
            ComboBoxPhongBan.DisplayMember = "TenPhongBan";
            ComboBoxPhongBan.ValueMember = "TenPhongBan";
            ComboBoxPhongBan.SelectedItem = null;
        }
        public DataTable getGroup(string str)
        {
            try
            {
                MyDB mydb = new MyDB();
                DataTable table = new DataTable();
                mydb.openConnection();
                SqlCommand cmd = new SqlCommand(str, mydb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                adapter.Dispose();
                cmd.Dispose();
                mydb.closeConnection();
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable table1 = new DataTable();
                return table1;
            }
        }
        public void getdata()
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand(" select * from Nhom ;", mydb.getConnection);
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
        bool kiemtraNhom(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Nhom WHERE MaNhom = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaNhom)  FROM Nhom WHERE MaNhom = '" + ma + "' ";
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
        private void NhomForm_Load(object sender, EventArgs e)
        {

        }
        bool kiemtraBoPhan1(string ten)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Nhom WHERE TenNhom = @ten", mydb.getConnection);
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            string str = "SELECT  count (TenNhom)  FROM Nhom WHERE TenNhom = N'" + ten + "' ";
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
        private void buttonThem_Click(object sender, EventArgs e)
        {
            Nhom nhom = new Nhom();
            string ma = txtMa.Text;
            string tenn = txtTen.Text;
            string tenpb = ComboBoxPhongBan.Text;
            if (verif() && kiemtraNhom(ma) && kiemtraBoPhan1(tenn))
            {
                if (nhom.insertNhom(ma, tenn,tenpb))
                    MessageBox.Show("New Nhóm Added", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Empty Fields", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            getdata();
        }
        bool verif()
        {
            if ((txtMa.Text.Trim() == "")
                || (txtTen.Text.Trim() == "")
                || (ComboBoxPhongBan.Text.Trim() == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            Nhom nhom = new Nhom();
            string ma = txtMa.Text;
            string tenn = txtTen.Text;
            string tenpb = ComboBoxPhongBan.Text;
            if (verif())
            {
                try
                {
                    if (nhom.UpdateNhom(ma, tenn,tenpb))
                    {
                        MessageBox.Show("Nhom Information Update", "Edit Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            Nhom nhom = new Nhom();
            try
            {
                string ma = Convert.ToString(txtMa.Text);
                if ((MessageBox.Show("Are You Sure You Want To Delete This Nhom", "Delete Nhom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (nhom.deleteNhom(ma))
                    {
                        MessageBox.Show("Nhom Deleted", "Delete Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMa.Text = null;
                        txtTen.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Nhom Enter A Valid ID", "Delete Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Nhom", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();
            clear();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMa.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            ComboBoxPhongBan.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
        void clear()
        {
            ComboBoxPhongBan.SelectedIndex = -1;
        }
    }
}
