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
    public partial class NguoiLaoDongForm : Form
    {
        public NguoiLaoDongForm()
        {
            InitializeComponent();
            DataGridView1.ReadOnly = true;
            DataGridView1.RowTemplate.Height = 50;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Refresh1()
        {
            string str1 = "select * from BoPhan";
            ComboBoxDVTT.Refresh();
            ComboBoxDVTT.DataSource = getGroup(str1);
            ComboBoxDVTT.DisplayMember = "TenBoPhan";
            ComboBoxDVTT.ValueMember = "TenBoPhan";
            ComboBoxDVTT.SelectedItem = null;
            ComboBoxChuyenMon.Refresh();
            ComboBoxChuyenMon.Items.Add("Kinh Tế");
            ComboBoxChuyenMon.Items.Add("CNTT");
            ComboBoxChuyenMon.Items.Add("Cơ Khí Chế Tạo Máy");
            ComboBoxChuyenMon.Items.Add("Quản Lý");
            ComboBoxChuyenMon.Items.Add("Ôtô");
            ComboBoxChuyenMon.Items.Add("Cơ Điện Tử");
            ComboBoxChucVu.Refresh();
            ComboBoxChucVu.Items.Add("Kỹ Sư");
            ComboBoxChucVu.Items.Add("Quản Lý");
        }

        public void Refresh2()
        {
            string str1 = "select * from PhongBan";
            ComboBoxDVTT.Refresh();
            ComboBoxDVTT.DataSource = getGroup(str1);
            ComboBoxDVTT.DisplayMember = "TenPhongBan";
            ComboBoxDVTT.ValueMember = "TenPhongBan";
            ComboBoxDVTT.SelectedItem = null;
            ComboBoxChuyenMon.Refresh();
            ComboBoxChuyenMon.Items.Add("Kiểm Tra Thu Chi");
            ComboBoxChuyenMon.Items.Add("Kế Hoạch Kinh Doanh");
            ComboBoxChuyenMon.Items.Add("Kế Toán");
            ComboBoxChuyenMon.Items.Add("Tuyển Nhận Sự");
            ComboBoxChuyenMon.Items.Add("Sửa Chữa - Bảo Trì");
            ComboBoxChuyenMon.Items.Add("Kiểm Tra Hệ Thống");
            ComboBoxChuyenMon.Items.Add("Kiểm Tra Chất Lượng Sản Phẩm");
            ComboBoxChuyenMon.Items.Add("Thiết Kế Sản Phẩm");
            ComboBoxChucVu.Refresh();
            ComboBoxChucVu.Items.Add("Nhân Viên");
        }
        public void Refresh3()
        {
            string str1 = "select * from Nhom";
            ComboBoxDVTT.Refresh();
            ComboBoxDVTT.DataSource = getGroup(str1);
            ComboBoxDVTT.DisplayMember = "TenNhom";
            ComboBoxDVTT.ValueMember = "TenNhom";
            ComboBoxDVTT.SelectedItem = null;
            ComboBoxChuyenMon.Refresh();
            ComboBoxChuyenMon.Items.Add("1");
            ComboBoxChuyenMon.Items.Add("2");
            ComboBoxChuyenMon.Items.Add("3");
            ComboBoxChucVu.Refresh();
            ComboBoxChucVu.Items.Add("Công Nhân");
            ComboBoxChucVu.Items.Add("Tổ Phó");
            ComboBoxChucVu.Items.Add("Tổ Trưởng");
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
            SqlCommand command = new SqlCommand(" select * from NguoiLaoDong ;", mydb.getConnection);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiLaoDong WHERE MaNLD = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaNLD)  FROM NguoiLaoDong WHERE MaNLD = '" + ma + "' ";
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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            getdata();
            labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            ComboBoxChuyenMon.Items.Clear();
            ComboBoxChucVu.Items.Clear();
            Refresh1();
            clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            getdata();
            labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            ComboBoxChuyenMon.Items.Clear();
            ComboBoxChucVu.Items.Clear();
            Refresh2();
            clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            getdata();
            labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            ComboBoxChuyenMon.Items.Clear();
            ComboBoxChucVu.Items.Clear();
            Refresh3();
            clear();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            NguoiLaoDong nguoilaodong = new NguoiLaoDong();
            string ma = txtMa.Text;
            
            if (radioButton1.Checked == true)
            {
                if (verif() && kiemtra(ma))
                {
                    int l = ma.Length;
                    string hoten = txtTen.Text;
                    DateTime ngaysinh = dateTimeNgaysinh.Value;
                    string dienthoai = txtSDT.Text;
                    string diachi = txtDCtamtru.Text;
                    string chucvu = ComboBoxChucVu.Text;
                    string chuyenmon = ComboBoxChuyenMon.Text;
                    string donvitructhuoc = ComboBoxDVTT.Text;
                    string trinhdo = ComboBoxTrinhDo.Text;
                    string gioitinh = "Nam";
                    if (radioButtonFemale.Checked)
                        gioitinh = "Nữ";
                    MemoryStream hinhanh = new MemoryStream();
                    int born_year = dateTimeNgaysinh.Value.Year;
                    int this_year = DateTime.Now.Year;
                    if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                    {
                        MessageBox.Show("The KySu Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (l > 2 && ((ma[0].ToString() == "K" && ma[1].ToString() == "S") || (ma[0].ToString() == "Q" && ma[1].ToString() == "L") && kiemtra(ma)))
                    {
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);

                        if (nguoilaodong.insertNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
                            MessageBox.Show("New Kỹ Sư Added", "Add Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error", "Add Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Empty Fields", "Add Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Empty Fields", "Add Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                getdata();
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton2.Checked == true)
            {
                MyDB mydb = new MyDB();
                mydb.openConnection();
                PhongBan pb = new PhongBan();
                if (verif() && kiemtra(ma))
                {
                    int l = ma.Length;
                    string hoten = txtTen.Text;
                    DateTime ngaysinh = dateTimeNgaysinh.Value;
                    string dienthoai = txtSDT.Text;
                    string diachi = txtDCtamtru.Text;
                    string chucvu = ComboBoxChucVu.Text;
                    string chuyenmon = ComboBoxChuyenMon.Text;
                    string donvitructhuoc = ComboBoxDVTT.Text;
                    string trinhdo = ComboBoxTrinhDo.Text;
                    string gioitinh = "Nam";
                    if (radioButtonFemale.Checked)
                        gioitinh = "Nữ";
                    MemoryStream hinhanh = new MemoryStream();
                    int born_year = dateTimeNgaysinh.Value.Year;
                    int this_year = DateTime.Now.Year;
                    if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                    {
                        MessageBox.Show("The KySu Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (l > 2 && ((ma[0].ToString() == "N" && ma[1].ToString() == "V") && kiemtra(ma)))
                    {
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);

                        if (nguoilaodong.insertNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
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
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton3.Checked == true)
            {
                if (verif() && kiemtra(ma))
                {
                    int l = ma.Length;
                    string hoten = txtTen.Text;
                    DateTime ngaysinh = dateTimeNgaysinh.Value;
                    string dienthoai = txtSDT.Text;
                    string diachi = txtDCtamtru.Text;
                    string chucvu = ComboBoxChucVu.Text;
                    string chuyenmon = ComboBoxChuyenMon.Text;
                    string donvitructhuoc = ComboBoxDVTT.Text;
                    string trinhdo = ComboBoxTrinhDo.Text;
                    string gioitinh = "Nam";
                    if (radioButtonFemale.Checked)
                        gioitinh = "Nữ";
                    MemoryStream hinhanh = new MemoryStream();
                    int born_year = dateTimeNgaysinh.Value.Year;
                    int this_year = DateTime.Now.Year;
                    if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                    {
                        MessageBox.Show("The KySu Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (l > 2 && ((ma[0].ToString() == "C" && ma[1].ToString() == "N") && kiemtra(ma)))
                    {
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);

                        if (nguoilaodong.insertNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
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
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }

        }
        bool verif()
        {
            if ((txtMa.Text.Trim() == "")
                || (txtTen.Text.Trim() == "")
                || (txtSDT.Text.Trim() == "")
                || (txtDCtamtru.Text.Trim() == "")
                || (ComboBoxChucVu.Text.Trim() == "")
                || (ComboBoxDVTT.Text.Trim() == "")
                || (ComboBoxTrinhDo.Text.Trim() == "")
                || (ComboBoxChuyenMon.Text.Trim() == "")
                || (pictureBoxImage.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            NguoiLaoDong nguoilaodong = new NguoiLaoDong();
            if (radioButton1.Checked == true)
            {
                string ma;
                string hoten = txtTen.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string donvitructhuoc = ComboBoxDVTT.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string chuyenmon = ComboBoxChuyenMon.Text;
                string gioitinh = "Nam";
                if (radioButtonFemale.Checked)
                    gioitinh = "Nữ";
                MemoryStream hinhanh = new MemoryStream();
                int born_year = dateTimeNgaysinh.Value.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The KySu Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    try
                    {
                        ma = Convert.ToString(txtMa.Text);
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);
                        if (nguoilaodong.UpdateNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
                        {
                            MessageBox.Show("KySu Information Update", "Edit Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                getdata();
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton2.Checked == true)
            {
                string ma;
                string hoten = txtTen.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string donvitructhuoc = ComboBoxDVTT.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string chuyenmon = ComboBoxChuyenMon.Text;
                string gioitinh = "Nam";
                if (radioButtonFemale.Checked)
                    gioitinh = "Nữ";
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
                        ma = Convert.ToString(txtMa.Text);
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);
                        if (nguoilaodong.UpdateNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
                        {
                            MessageBox.Show("NhanVien Information Update", "Edit Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                getdata();
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton3.Checked == true)
            {
                string ma;
                string hoten = txtTen.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string donvitructhuoc = ComboBoxDVTT.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string chuyenmon = ComboBoxChuyenMon.Text;
                string gioitinh = "Nam";
                if (radioButtonFemale.Checked)
                    gioitinh = "Nữ";
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
                        ma = Convert.ToString(txtMa.Text);
                        pictureBoxImage.Image.Save(hinhanh, pictureBoxImage.Image.RawFormat);
                        if (nguoilaodong.UpdateNguoiLaoDong(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, chuyenmon, donvitructhuoc, hinhanh))
                        {
                            MessageBox.Show("CongNhan Information Update", "Edit Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Công Nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                getdata();
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            NguoiLaoDong nguoilaodong = new NguoiLaoDong();
            if (radioButton1.Checked == true)
            {
                DangKi dk = new DangKi();
                try
                {
                    string ma = Convert.ToString(txtMa.Text);
                    dk.deleteTaiKhoan(ma);
                    if ((MessageBox.Show("Are You Sure You Want To Delete This KySu", "Delete KySu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (nguoilaodong.deleteNguoiLaoDong(ma))
                        {
                            MessageBox.Show("KySu Deleted", "Delete KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMa.Text = null;
                            txtTen.Text = null;
                            txtSDT.Text = null;
                            txtDCtamtru.Text = null;
                            ComboBoxChucVu.Text = null;
                            ComboBoxDVTT.Text = null;
                            ComboBoxTrinhDo.Text = null;
                            ComboBoxChuyenMon.Text = null;
                            radioButtonMale.Checked = true;
                            dateTimeNgaysinh.Value = DateTime.Now;
                            pictureBoxImage.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("KySu Enter A Valid ID", "Delete KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter A Valid ID", "Delete KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                getdata();
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    string ma = Convert.ToString(txtMa.Text);
                    if ((MessageBox.Show("Are You Sure You Want To Delete This NhanVien", "Delete NhanVien", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (nguoilaodong.deleteNguoiLaoDong(ma))
                        {
                            MessageBox.Show("NhanVien Deleted", "Delete NhanVien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMa.Text = null;
                            txtTen.Text = null;
                            txtSDT.Text = null;
                            txtDCtamtru.Text = null;
                            ComboBoxChucVu.Text = null;
                            ComboBoxDVTT.Text = null;
                            ComboBoxTrinhDo.Text = null;
                            ComboBoxChuyenMon.Text = null;
                            radioButtonMale.Checked = true;
                            dateTimeNgaysinh.Value = DateTime.Now;
                            pictureBoxImage.Image = null;
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
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
            if (radioButton3.Checked == true)
            {
                try
                {
                    string ma = Convert.ToString(txtMa.Text);
                    if ((MessageBox.Show("Are You Sure You Want To Delete This CongNhan", "Delete CongNhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (nguoilaodong.deleteNguoiLaoDong(ma))
                        {
                            MessageBox.Show("CongNhan Deleted", "Delete CongNhan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMa.Text = null;
                            txtTen.Text = null;
                            txtSDT.Text = null;
                            txtDCtamtru.Text = null;
                            ComboBoxChucVu.Text = null;
                            ComboBoxDVTT.Text = null;
                            ComboBoxTrinhDo.Text = null;
                            ComboBoxChuyenMon.Text = null;
                            radioButtonMale.Checked = true;
                            dateTimeNgaysinh.Value = DateTime.Now;
                            pictureBoxImage.Image = null;
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
                labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
            }
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.ipg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
                pictureBoxImage.Image = Image.FromFile(opf.FileName);
        }

        private void buttonDownloadImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("NguoiLaoDong_" + txtMa.Text);
            if ((pictureBoxImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxImage.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void buttonDatLai_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDCtamtru.Clear();
            ComboBoxChucVu.SelectedIndex = -1;
            ComboBoxDVTT.SelectedIndex = -1;
            ComboBoxTrinhDo.SelectedIndex = -1;
            ComboBoxChuyenMon.SelectedIndex = -1;
            textBoxSearch.Clear();
            radioButtonMale.Checked = true;
            dateTimeNgaysinh.Value = DateTime.Now;
            pictureBoxImage.Image = null;

        }

        private void buttonInFile_Click_1(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM NguoiLaoDong", mydb.getConnection);
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
                    ExcelNguoiLaoDong ex = new ExcelNguoiLaoDong();
                    ex.ExportExcel(table, "Người Lao Động", "Danh sách Người Lao Động");

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

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            clear();
            txtMa.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgaysinh.Value = (DateTime)DataGridView1.CurrentRow.Cells[2].Value;
            txtDCtamtru.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            ComboBoxTrinhDo.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            ComboBoxChucVu.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            ComboBoxChuyenMon.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
            ComboBoxDVTT.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();

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
                pictureBoxImage.Image = null;
            }
            else
            {
                byte[] pic;
                pic = (byte[])DataGridView1.CurrentRow.Cells[10].Value;
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxImage.Image = Image.FromStream(picture);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM NguoiLaoDong WHERE CONCAT(HoTen,ChucVu,DonViTrucThuoc) LIKE N'%" + textBoxSearch.Text + "%'", mydb.getConnection);
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
                    ExcelNguoiLaoDong ex = new ExcelNguoiLaoDong();
                    ex.ExportExcel(table, "Người Lao Động", "Danh sách Người Lao Động cần tìm");
                   
                    labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
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

        private void labelNguoiLaoDong_Click(object sender, EventArgs e)
        {
            labelNguoiLaoDong.Text = ("Tổng Người Lao Động trong danh sách: " + DataGridView1.RowCount);
        }
    }
}
