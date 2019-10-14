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
    public partial class NhanVienForm : Form
    {
        public NhanVienForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Refresh1()
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
            SqlCommand command = new SqlCommand(" select * from NhanVien ;", mydb.getConnection);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien WHERE MaNV = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaNV)  FROM NhanVien WHERE MaNV = '"+ma+"' ";
            SqlCommand cmd1 = new SqlCommand(str, mydb.getConnection);

            mydb.openConnection();
            int n=(int) cmd1.ExecuteScalar();
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
            NhanVien nhanvien = new NhanVien();
            if (verif())
            {
                string ma = txtMaNV.Text;
                int l = ma.Length;
                string hoten = txtTenNV.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string phongban = ComboBoxPhongBan.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string congviec = ComboBoxCongViec.Text;
                string gioitinh = "Nam";
                if (radioButtonFemale.Checked)
                    gioitinh = "Nữ";
                MemoryStream hinhanh = new MemoryStream();
                int born_year = dateTimeNgaysinh.Value.Year;
                int this_year = DateTime.Now.Year;

                if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The NhanVien Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (l > 2 && (ma[0].ToString() == "N" && ma[1].ToString() == "V")&& kiemtra(ma))
                {
                    pictureBoxNhanVienImage.Image.Save(hinhanh, pictureBoxNhanVienImage.Image.RawFormat);
                    if (nhanvien.insertNhanVien(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, congviec, phongban, hinhanh))
                        MessageBox.Show("New Nhân Viên Added", "Add Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Empty Fields", "Add Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            getdata();
        }
        bool verif()
        {
            if ((txtMaNV.Text.Trim() == "")
                || (txtTenNV.Text.Trim() == "")
                || (txtSDT.Text.Trim() == "")
                || (txtDCtamtru.Text.Trim() == "")
                || (ComboBoxChucVu.Text.Trim() == "")
                || (ComboBoxPhongBan.Text.Trim() == "")
                || (ComboBoxTrinhDo.Text.Trim() == "")
                || (ComboBoxCongViec.Text.Trim() == "")
                || (pictureBoxNhanVienImage.Image == null))
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
                pictureBoxNhanVienImage.Image = Image.FromFile(opf.FileName);
        }

        private void ButtonDownloadImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("NhanVien_" + txtMaNV.Text);
            if ((pictureBoxNhanVienImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxNhanVienImage.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = new NhanVien();
            string ma;
            string hoten = txtTenNV.Text;
            DateTime ngaysinh = dateTimeNgaysinh.Value;
            string dienthoai = txtSDT.Text;
            string diachi = txtDCtamtru.Text;
            string chucvu = ComboBoxChucVu.Text;
            string phongban = ComboBoxPhongBan.Text;
            string trinhdo = ComboBoxTrinhDo.Text;
            string congviec = ComboBoxCongViec.Text;
            string gioitinh = "Nam";
            if (radioButtonFemale.Checked)
                gioitinh = "Nữ";
            MemoryStream hinhanh = new MemoryStream();
            int born_year = dateTimeNgaysinh.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The NhanVien Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    ma = Convert.ToString(txtMaNV.Text);
                    pictureBoxNhanVienImage.Image.Save(hinhanh, pictureBoxNhanVienImage.Image.RawFormat);
                    if (nhanvien.UpdateNhanVien(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, congviec, phongban, hinhanh))
                    {
                        MessageBox.Show("NhanVien Information Update", "Edit NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            getdata();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = new NhanVien();
            try
            {
                string ma = Convert.ToString(txtMaNV.Text);
                if ((MessageBox.Show("Are You Sure You Want To Delete This NhanVien", "Delete NhanVien", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (nhanvien.deleteNhanVien(ma))
                    {
                        MessageBox.Show("NhanVien Deleted", "Delete NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaNV.Text = null;
                        txtTenNV.Text = null;
                        txtSDT.Text = null;
                        txtDCtamtru.Text = null;
                        ComboBoxChucVu.Text = null;
                        ComboBoxPhongBan.Text = null;
                        ComboBoxTrinhDo.Text = null;
                        ComboBoxCongViec.Text = null;
                        radioButtonMale.Checked = true;
                        dateTimeNgaysinh.Value = DateTime.Now;
                        pictureBoxNhanVienImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("NhanVien Enter A Valid ID", "Delete NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            getdata();
        }

        private void ButtonLamMoi_Click(object sender, EventArgs e)
        {
            getdata();
            labelNhanVien.Text = ("Tổng nhân viên trong danh sách: " + DataGridView1.RowCount);
        }

        private void ButtonDatLai_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDCtamtru.Clear();
            ComboBoxChucVu.SelectedIndex = -1;
            ComboBoxPhongBan.SelectedIndex = -1;
            ComboBoxTrinhDo.SelectedIndex = -1;
            ComboBoxCongViec.SelectedIndex = -1;
            textBoxSearch.Clear();
            radioButtonMale.Checked = true;
            dateTimeNgaysinh.Value = DateTime.Now;
            pictureBoxNhanVienImage.Image = null;

        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE CONCAT(HoTen,ChucVu,PhongBan) LIKE N'%" + textBoxSearch.Text + "%'", mydb.getConnection);
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
                    ExcelNV exnv = new ExcelNV();
                    exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên cần tìm");
                    // đếm nhân viên
                    labelNhanVien.Text = ("Tổng nhân viên trong danh sách: " + DataGridView1.RowCount);
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

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMaNV.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgaysinh.Value = (DateTime)DataGridView1.CurrentRow.Cells[2].Value;
            txtDCtamtru.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            ComboBoxTrinhDo.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            ComboBoxChucVu.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            ComboBoxCongViec.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
            ComboBoxPhongBan.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();

            string gender = DataGridView1.CurrentRow.Cells[3].Value.ToString();
            string gender1 = "Nữ";
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
                pictureBoxNhanVienImage.Image = null;
            }
            else
            {
                byte[] pic;
                pic = (byte[])DataGridView1.CurrentRow.Cells[10].Value;
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxNhanVienImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxNhanVienImage.Image = Image.FromStream(picture);
            }
        }

        private void ButtonInFile_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien ", mydb.getConnection);
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
                    ExcelNV exnv = new ExcelNV();
                    exnv.ExportExcel(table, "Nhân Viên", "Danh sách nhân viên");
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

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            labelNhanVien.Text = ("Tổng nhân viên trong danh sách: " + DataGridView1.RowCount);
        }
    }
}
