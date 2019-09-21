namespace DoAn1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnhethong = new System.Windows.Forms.Button();
            this.btncongnhan = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnnhanvien = new System.Windows.Forms.Button();
            this.btnluong = new System.Windows.Forms.Button();
            this.btnkysu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnhethong);
            this.groupBox1.Controls.Add(this.btncongnhan);
            this.groupBox1.Controls.Add(this.btnthoat);
            this.groupBox1.Controls.Add(this.btnnhanvien);
            this.groupBox1.Controls.Add(this.btnluong);
            this.groupBox1.Controls.Add(this.btnkysu);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(46, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 331);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // btnhethong
            // 
            this.btnhethong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnhethong.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhethong.ForeColor = System.Drawing.Color.Black;
            this.btnhethong.Location = new System.Drawing.Point(42, 168);
            this.btnhethong.Name = "btnhethong";
            this.btnhethong.Size = new System.Drawing.Size(147, 30);
            this.btnhethong.TabIndex = 4;
            this.btnhethong.Text = "Hệ Thống Sản Xuất";
            this.btnhethong.UseVisualStyleBackColor = false;
            this.btnhethong.Click += new System.EventHandler(this.Btnhethong_Click);
            // 
            // btncongnhan
            // 
            this.btncongnhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btncongnhan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncongnhan.ForeColor = System.Drawing.Color.Black;
            this.btncongnhan.Location = new System.Drawing.Point(42, 121);
            this.btncongnhan.Name = "btncongnhan";
            this.btncongnhan.Size = new System.Drawing.Size(147, 30);
            this.btncongnhan.TabIndex = 3;
            this.btncongnhan.Text = "Công Nhân";
            this.btncongnhan.UseVisualStyleBackColor = false;
            this.btncongnhan.Click += new System.EventHandler(this.Btncongnhan_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnthoat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.ForeColor = System.Drawing.Color.Black;
            this.btnthoat.Location = new System.Drawing.Point(42, 267);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(147, 30);
            this.btnthoat.TabIndex = 4;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            // 
            // btnnhanvien
            // 
            this.btnnhanvien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnnhanvien.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhanvien.ForeColor = System.Drawing.Color.Black;
            this.btnnhanvien.Location = new System.Drawing.Point(42, 74);
            this.btnnhanvien.Name = "btnnhanvien";
            this.btnnhanvien.Size = new System.Drawing.Size(147, 30);
            this.btnnhanvien.TabIndex = 2;
            this.btnnhanvien.Text = "Nhân Viên";
            this.btnnhanvien.UseVisualStyleBackColor = false;
            this.btnnhanvien.Click += new System.EventHandler(this.Btnnhanvien_Click);
            // 
            // btnluong
            // 
            this.btnluong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnluong.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluong.ForeColor = System.Drawing.Color.Black;
            this.btnluong.Location = new System.Drawing.Point(42, 216);
            this.btnluong.Name = "btnluong";
            this.btnluong.Size = new System.Drawing.Size(147, 30);
            this.btnluong.TabIndex = 3;
            this.btnluong.Text = "Lương";
            this.btnluong.UseVisualStyleBackColor = false;
            this.btnluong.Click += new System.EventHandler(this.Btnluong_Click);
            // 
            // btnkysu
            // 
            this.btnkysu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnkysu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkysu.ForeColor = System.Drawing.Color.Black;
            this.btnkysu.Location = new System.Drawing.Point(42, 29);
            this.btnkysu.Name = "btnkysu";
            this.btnkysu.Size = new System.Drawing.Size(147, 30);
            this.btnkysu.TabIndex = 1;
            this.btnkysu.Text = "Kỹ Sư";
            this.btnkysu.UseVisualStyleBackColor = false;
            this.btnkysu.Click += new System.EventHandler(this.Btnkysu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(276, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(687, 331);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(304, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 31);
            this.label1.TabIndex = 38;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ NHÂN SỰ ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnhethong;
        private System.Windows.Forms.Button btncongnhan;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnnhanvien;
        private System.Windows.Forms.Button btnluong;
        private System.Windows.Forms.Button btnkysu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}