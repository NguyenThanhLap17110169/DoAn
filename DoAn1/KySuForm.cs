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
    public partial class KySuForm : Form
    {
        public KySuForm()
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
            SqlCommand command = new SqlCommand(" select * from KySu ;", mydb.getConnection);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM KySu WHERE MaKS = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            string str = "SELECT  count (MaKS)  FROM KySu WHERE MaKS = '" + ma + "' ";
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
            KySu kysu = new KySu();
            if (verif() )
            {
                string ma = txtMaKS.Text;
                int l = ma.Length;
                string hoten = txtTenKS.Text;
                DateTime ngaysinh = dateTimeNgaysinh.Value;
                string dienthoai = txtSDT.Text;
                string diachi = txtDCtamtru.Text;
                string chucvu = ComboBoxChucVu.Text;
                string bophan = ComboBoxBoPhan.Text;
                string trinhdo = ComboBoxTrinhDo.Text;
                string nganhdaotao = ComboBoxNganhDaoTao.Text;
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
                else if (l > 2 && ((ma[0].ToString() == "K" && ma[1].ToString() == "S") || (ma[0].ToString() == "Q" && ma[1].ToString() == "L")))
                {
                    pictureBoxKySuImage.Image.Save(hinhanh, pictureBoxKySuImage.Image.RawFormat);
                    if (kysu.insertKySu(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, nganhdaotao, bophan, hinhanh))
                        MessageBox.Show("New kỹ Sư Added", "Add kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error", "Add kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Empty Fields", "Add kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Empty Fields", "Add kỹ Sư", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            getdata();
        }
        bool verif()
        {
            if ((txtMaKS.Text.Trim() == "")
                || (txtTenKS.Text.Trim() == "")
                || (txtSDT.Text.Trim() == "")
                || (txtDCtamtru.Text.Trim() == "")
                || (ComboBoxChucVu.Text.Trim() == "")
                || (ComboBoxBoPhan.Text.Trim() == "")
                || (ComboBoxTrinhDo.Text.Trim() == "")
                || (ComboBoxNganhDaoTao.Text.Trim() == "")
                || (pictureBoxKySuImage.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            KySu kysu = new KySu();
            string ma;
            string hoten = txtTenKS.Text;
            DateTime ngaysinh = dateTimeNgaysinh.Value;
            string dienthoai = txtSDT.Text;
            string diachi = txtDCtamtru.Text;
            string chucvu = ComboBoxChucVu.Text;
            string bophan = ComboBoxBoPhan.Text;
            string trinhdo = ComboBoxTrinhDo.Text;
            string nganhdaotao = ComboBoxNganhDaoTao.Text;
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
                    ma = Convert.ToString(txtMaKS.Text);
                    pictureBoxKySuImage.Image.Save(hinhanh, pictureBoxKySuImage.Image.RawFormat);
                    if (kysu.UpdateKySu(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, trinhdo, chucvu, nganhdaotao, bophan, hinhanh))
                    {
                        MessageBox.Show("KySu Information Update", "Edit KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            getdata();
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.ipg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
                pictureBoxKySuImage.Image = Image.FromFile(opf.FileName);
        }

        private void ButtonDownloadImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("KySu_" + txtMaKS.Text);
            if ((pictureBoxKySuImage.Image == null))
            {
                MessageBox.Show("No Image In The PictureBox");
            }
            else if ((svf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxKySuImage.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            KySu kysu = new KySu();
            try
            {
                string ma = Convert.ToString(txtMaKS.Text);
                if ((MessageBox.Show("Are You Sure You Want To Delete This KySu", "Delete KySu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (kysu.deleteKySu(ma))
                    {
                        MessageBox.Show("KySu Deleted", "Delete KySu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaKS.Text = null;
                        txtTenKS.Text = null;
                        txtSDT.Text = null;
                        txtDCtamtru.Text = null;
                        ComboBoxChucVu.Text = null;
                        ComboBoxBoPhan.Text = null;
                        ComboBoxTrinhDo.Text = null;
                        ComboBoxNganhDaoTao.Text = null;
                        radioButtonMale.Checked = true;
                        dateTimeNgaysinh.Value = DateTime.Now;
                        pictureBoxKySuImage.Image = null;
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
        }

        private void ButtonLamMoi_Click(object sender, EventArgs e)
        {
            getdata();
            labelKySu.Text = ("Tổng kỹ sư trong danh sách: " + DataGridView1.RowCount);
        }

        private void ButtonDatLai_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtMaKS.Clear();
            txtTenKS.Clear();
            txtSDT.Clear();
            txtDCtamtru.Clear();
            ComboBoxChucVu.SelectedIndex = -1;
            ComboBoxBoPhan.SelectedIndex = -1;
            ComboBoxTrinhDo.SelectedIndex = -1;
            ComboBoxNganhDaoTao.SelectedIndex = -1;
            textBoxSearch.Clear();
            radioButtonMale.Checked = true;
            dateTimeNgaysinh.Value = DateTime.Now;
            pictureBoxKySuImage.Image = null;

        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtMaKS.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenKS.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimeNgaysinh.Value = (DateTime)DataGridView1.CurrentRow.Cells[2].Value;
            txtDCtamtru.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            ComboBoxTrinhDo.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            ComboBoxChucVu.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            ComboBoxNganhDaoTao.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
            ComboBoxBoPhan.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();

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
                pictureBoxKySuImage.Image = null;
            }
            else
            {
                byte[] pic;
                pic = (byte[])DataGridView1.CurrentRow.Cells[10].Value;
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxKySuImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKySuImage.Image = Image.FromStream(picture);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("SELECT * FROM KySu WHERE CONCAT(HoTen,ChucVu,BoPhan) LIKE N'%" + textBoxSearch.Text + "%'", mydb.getConnection);
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
                    ExcelKySu exks = new ExcelKySu();
                    exks.ExportExcel(table, "Kỹ sư", "Danh sách kỹ sư cần tìm");
                    // đếm kỹ sư
                    labelKySu.Text = ("Tổng kỹ sư trong danh sách: " + DataGridView1.RowCount);
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
            SqlCommand command = new SqlCommand("SELECT * FROM KySu", mydb.getConnection);
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
                    ExcelKySu exks = new ExcelKySu();
                    exks.ExportExcel(table, "Kỹ sư", "Danh sách kỹ sư");
           
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

        private void KySuForm_Load(object sender, EventArgs e)
        {
            labelKySu.Text = ("Tổng kỹ sư trong danh sách: " + DataGridView1.RowCount);
        }
    }
}
