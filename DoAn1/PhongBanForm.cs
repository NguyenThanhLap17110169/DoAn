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
    public partial class PhongBanForm : Form
    {
        public PhongBanForm()
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
            string str1 = "select * from BoPhan";
            ComboBoxBoPhan.Refresh();
            ComboBoxBoPhan.DataSource = getGroup(str1);
            ComboBoxBoPhan.DisplayMember = "TenBoPhan";
            ComboBoxBoPhan.ValueMember = "TenBoPhan";
            ComboBoxBoPhan.SelectedItem = null;
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
            SqlCommand command = new SqlCommand(" select * from PhongBan ;", mydb.getConnection);
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
        bool kiemtraPhongBan(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PhongBan WHERE MaPhongBan = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaPhongBan)  FROM PhongBan WHERE MaPhongBan = '" + ma + "' ";
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
        private void PhongBanForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            PhongBan phongban = new PhongBan();
            string ma = txtMa.Text;
            string tenpb = txtTen.Text;
            string tenbp = ComboBoxBoPhan.Text;
            if (verif() && kiemtraPhongBan(ma))
            {
                if (phongban.insertPhongBan(ma, tenpb,tenbp))
                    MessageBox.Show("New Phòng Ban Added", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Empty Fields", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            getdata();
        }
        bool verif()
        {
            if ((txtMa.Text.Trim() == "")
                || (txtTen.Text.Trim() == "")
                ||(ComboBoxBoPhan.Text.Trim()==""))
            {
                return false;
            }
            else
                return true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            PhongBan phongban = new PhongBan();
            string ma = txtMa.Text;
            string tenpb = txtTen.Text;
            string tenbp = ComboBoxBoPhan.Text;
            if (verif())
            {
                try
                {
                    if (phongban.UpdatePhongBan(ma, tenpb,tenbp))
                    {
                        MessageBox.Show("PhongBan Information Update", "Edit PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();
      }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            PhongBan phongban = new PhongBan();
         
            try
            {
                string ma = Convert.ToString(txtMa.Text);
                if ((MessageBox.Show("Are You Sure You Want To Delete This PhongBan", "Delete PhongBan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (phongban.deletePhongBan(ma))
                    {
                        MessageBox.Show("PhongBan Deleted", "Delete PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMa.Text = null;
                        txtTen.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("PhongBan Enter A Valid ID", "Delete PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete PhongBan", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ComboBoxBoPhan.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();

        }
        void clear()
        {
            ComboBoxBoPhan.SelectedIndex = -1;
        }
    }
}
