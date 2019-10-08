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
    public partial class CongNhanForm : Form
    {

        public CongNhanForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Refresh1()
        {
            string str1 = "select * from Nhom";
            ComboBoxTo.Refresh();
            ComboBoxTo.DataSource = getGroup(str1);
            ComboBoxTo.DisplayMember = "TenNhom";
            ComboBoxTo.ValueMember = "TenNhom";
            ComboBoxTo.SelectedItem = null;
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
            SqlCommand command = new SqlCommand(" select * from CongNhan ;", mydb.getConnection);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                DataGridView1.DataSource = bsource;
                DataGridViewImageColumn piccol = new DataGridViewImageColumn();
                piccol = (DataGridViewImageColumn)DataGridView1.Columns[10];
                piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool kiemtra(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CongNhan WHERE MaCN = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaCN)  FROM CongNhan WHERE MaCN = '" + ma + "' ";
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
            
            CongNhan congnhan = new CongNhan();
            if (verif())
            {
                string ma = txtMaCN.Text;
                int l = ma.Length;
                string hoten = txtTenCN.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string to = ComboBoxTo.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string bac = ComboBoxBac.Text;
                string gioitinh = "Nam";
                if (radioButtonFemale.Checked)
                    gioitinh = "Nu";
                MemoryStream hinhanh = new MemoryStream();
                int born_year = dateTimeNgaysinh.Value.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The CongNhan Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (l > 2 && (ma[0].ToString() == "C" && ma[1].ToString() == "N")&& kiemtra(ma))
                {
                    pictureBoxCongNhanImage.Image.Save(hinhanh, pictureBoxCongNhanImage.Image.RawFormat);
                    if (congnhan.insertCongNhan(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, bac, to, hinhanh))
                        MessageBox.Show("New Công Nhân Added", "Add Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Empty Fields", "Add Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            getdata();
        }
        bool verif()
        {
            if ((txtMaCN.Text.Trim() == "")
                || (txtTenCN.Text.Trim() == "")
                || (txtSDT.Text.Trim() == "")
                || (txtDCtamtru.Text.Trim() == "")
                || (ComboBoxChucVu.Text.Trim() == "")
                || (ComboBoxTo.Text.Trim() == "")
                || (ComboBoxBac.Text.Trim() == "")
                || (ComboBoxTrinhDo.Text.Trim()=="")
                || (pictureBoxCongNhanImage.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.ipg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
                pictureBoxCongNhanImage.Image = Image.FromFile(opf.FileName);
        }

        private void ButtonDownloadImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("CongNhan_" + txtMaCN.Text);
            if ((pictureBoxCongNhanImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxCongNhanImage.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMaCN.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenCN.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgaysinh.Value = (DateTime)DataGridView1.CurrentRow.Cells[2].Value;
            txtDCtamtru.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            ComboBoxTrinhDo.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            ComboBoxChucVu.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            ComboBoxBac.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
            ComboBoxTo.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();

            string gender = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            string gender1 = "Nu";
            int flag = 1;
            for (int i = 0; i < gender1.Length; i++)
            {
                if (gender[i] != gender1[i])
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                radioButtonFemale.Checked = true;
            }
            else
            {
                radioButtonMale.Checked = true;
            }


            if (DataGridView1.CurrentRow.Cells[10].Value == DBNull.Value)
            {
                pictureBoxCongNhanImage.Image = null;
            }
            else
            {
                byte[] pic;
                pic = (byte[])DataGridView1.CurrentRow.Cells[10].Value;
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxCongNhanImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxCongNhanImage.Image = Image.FromStream(picture);
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            CongNhan congnhan = new CongNhan();
            string ma = txtMaCN.Text;
            string hoten = txtTenCN.Text;
            DateTime ngaysinh = dateTimeNgaysinh.Value;
            string dienthoai = txtSDT.Text;
            string diachi = txtDCtamtru.Text;
            string chucvu = ComboBoxChucVu.Text;
            string to = ComboBoxTo.Text;
            string trinhdo = ComboBoxTrinhDo.Text;
            string bac = ComboBoxBac.Text;
            string gioitinh = "Nam";
            if (radioButtonFemale.Checked)
                gioitinh = "Nu";
            MemoryStream hinhanh = new MemoryStream();
            int born_year = dateTimeNgaysinh.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The CongNhan Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    ma = Convert.ToString(txtMaCN.Text);
                    pictureBoxCongNhanImage.Image.Save(hinhanh, pictureBoxCongNhanImage.Image.RawFormat);
                    if (congnhan.UpdateCongNhan(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, bac, to, hinhanh))
                    {
                        MessageBox.Show("CongNhan Information Update", "Edit CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            getdata();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            CongNhan congnhan = new CongNhan();
            try
            {
                string ma = Convert.ToString(txtMaCN.Text);
                if ((MessageBox.Show("Are You Sure You Want To Delete This CongNhan", "Delete CongNhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (congnhan.deleteCongNhan(ma))
                    {
                        MessageBox.Show("CongNhan Deleted", "Delete CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaCN.Text=null;
                        txtTenCN.Text = null;
                        txtSDT.Text = null;
                        txtDCtamtru.Text = null;
                        ComboBoxChucVu.Text = null;
                        ComboBoxTo.Text = null;
                        ComboBoxTrinhDo.Text = null;
                        ComboBoxBac.Text = null;
                        radioButtonMale.Checked = true;
                        dateTimeNgaysinh.Value = DateTime.Now;
                        pictureBoxCongNhanImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("CongNhan Enter A Valid ID", "Delete CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();
        }

        private void ButtonDatLai_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtMaCN.Clear();
            txtTenCN.Clear();
            txtSDT.Clear();
            txtDCtamtru.Clear();
            ComboBoxChucVu.SelectedIndex = -1;
            ComboBoxTo.SelectedIndex = -1;
            ComboBoxTrinhDo.SelectedIndex = -1;
            ComboBoxBac.SelectedIndex = -1;
            textBoxSearch.Clear();
            radioButtonMale.Checked = true;
            dateTimeNgaysinh.Value = DateTime.Now;
            pictureBoxCongNhanImage.Image = null;

        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM CongNhan WHERE CONCAT(HoTen,ChucVu,Nhom) LIKE N'%" + textBoxSearch.Text + "%'", mydb.getConnection);
            mydb.openConnection();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count > 0)
            {
                try
                {
                    BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                    bsource.DataSource = table;
                    DataGridView1.DataSource = bsource;
                    DataGridViewImageColumn piccol = new DataGridViewImageColumn();
                    piccol = (DataGridViewImageColumn)DataGridView1.Columns[10];
                    piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    ExcelCN ex = new ExcelCN();
                    ex.ExportExcel(table, "CongNhan", "Danh Sách Công Nhân Cần Tìm ");
                    // đếm nhân viên
                    //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                    mydb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void ButtonInFile_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM CongNhan ", mydb.getConnection);
            mydb.openConnection();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count > 0)
            {
                try
                {
                    BindingSource bsource = new BindingSource();   //dong nay xuat hien khi dua datasource vao
                    bsource.DataSource = table;
                    DataGridView1.DataSource = bsource;
                    DataGridViewImageColumn piccol = new DataGridViewImageColumn();
                    piccol = (DataGridViewImageColumn)DataGridView1.Columns[10];
                    piccol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    ExcelCN ex = new ExcelCN();
                    ex.ExportExcel(table, "CongNhan", "Danh Sách Công Nhân");
                    // đếm nhân viên
                    //   labelTotalNhanVien.Text = ("Tổng Nhân Viên trong danh sách: " + DataGridView1.RowCount);
                    mydb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }
    }
}
