﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void HệThốngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            getImageandUsername();
        }
        public void getImageandUsername()
        {

            MyDB mydb = new MyDB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("Select * FROM NguoiLaoDong where MaNLD=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = StaticValue.ID;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["HinhAnh"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
                labelInformation.Text = ("Welcome " + table.Rows[0]["HoTen"]);
                label2.Text = ("Chuc vu: " + table.Rows[0]["ChucVu"]);
            }

        }

 
        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoPhanForm bp = new BoPhanForm();
            bp.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBanForm pb = new PhongBanForm();
            pb.ShowDialog();
        }

        private void nhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhomForm n = new NhomForm();
            n.ShowDialog();
        }

        private void kỹSưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NguoiLaoDongForm ks = new NguoiLaoDongForm();
            ks.ShowDialog();
        }
    }
}
