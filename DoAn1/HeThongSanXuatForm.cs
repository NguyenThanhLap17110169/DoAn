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
    public partial class HeThongSanXuatForm : Form
    {
        public HeThongSanXuatForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        public void getdata1()
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
        public void getdata2()
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
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            BoPhan bophan = new BoPhan();
            PhongBan phongban = new PhongBan();
            Nhom nhom = new Nhom();
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            if (radioButton1.Checked == true)
            {
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
            else if(radioButton2.Checked == true)
            {
                if (verif()&& kiemtraPhongBan(ma))
                {
                    if (phongban.insertPhongBan(ma, ten))
                        MessageBox.Show("New Phòng Ban Added", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Phòng Ban", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                getdata1();
            }
            else if(radioButton3.Checked == true)
            {
                if (verif()&&kiemtraNhom(ma))
                {
                    if (nhom.insertNhom(ma, ten))
                        MessageBox.Show("New Nhóm Added", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Nhóm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                getdata2();
            }

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
            PhongBan phongban = new PhongBan();
            Nhom nhom = new Nhom();
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            if(radioButton1.Checked == true)
            {
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
            if(radioButton2.Checked == true)
            {
                if (verif())
                {
                    try
                    {
                        if (phongban.UpdatePhongBan(ma, ten))
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
                getdata1();
            }
            if(radioButton3.Checked == true)
            {
                if (verif())
                {
                    try
                    {
                        if (nhom.UpdateNhom(ma, ten))
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
                getdata2();
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            BoPhan bophan = new BoPhan();
            PhongBan phongban = new PhongBan();
            Nhom nhom = new Nhom();
            if (radioButton1.Checked == true)
            {
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
            else if(radioButton2.Checked == true)
            {
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
                getdata1();
            }
          else if(radioButton3.Checked == true)
            {
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
                getdata2();
            }
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
        void clear()
        {
            txtMa.Clear();
            txtTen.Clear();
        }
            private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            getdata();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            getdata1();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            getdata2();
        }
    }
}
