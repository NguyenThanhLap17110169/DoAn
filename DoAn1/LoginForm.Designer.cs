namespace DoAn1
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.AccountLogin = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.buttonLOGIN = new System.Windows.Forms.Button();
            this.buttonCANCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(19, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 36;
            this.label2.Text = "Đăng Kí";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(29, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tài khoản:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(165, 99);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(196, 26);
            this.txtTaiKhoan.TabIndex = 34;
            // 
            // AccountLogin
            // 
            this.AccountLogin.AutoSize = true;
            this.AccountLogin.BackColor = System.Drawing.Color.Transparent;
            this.AccountLogin.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountLogin.ForeColor = System.Drawing.Color.MediumPurple;
            this.AccountLogin.Location = new System.Drawing.Point(115, 24);
            this.AccountLogin.Name = "AccountLogin";
            this.AccountLogin.Size = new System.Drawing.Size(162, 36);
            this.AccountLogin.TabIndex = 29;
            this.AccountLogin.Text = "Đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(165, 144);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 26);
            this.txtPassword.TabIndex = 28;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.BackColor = System.Drawing.Color.Transparent;
            this.Password.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Blue;
            this.Password.Location = new System.Drawing.Point(29, 145);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(95, 22);
            this.Password.TabIndex = 27;
            this.Password.Text = "Mật khẩu:";
            // 
            // buttonLOGIN
            // 
            this.buttonLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(201)))), ((int)(((byte)(64)))));
            this.buttonLOGIN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLOGIN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLOGIN.Location = new System.Drawing.Point(230, 188);
            this.buttonLOGIN.Name = "buttonLOGIN";
            this.buttonLOGIN.Size = new System.Drawing.Size(107, 40);
            this.buttonLOGIN.TabIndex = 26;
            this.buttonLOGIN.Text = "Đăng nhập";
            this.buttonLOGIN.UseVisualStyleBackColor = false;
            this.buttonLOGIN.Click += new System.EventHandler(this.ButtonLOGIN_Click);
            // 
            // buttonCANCEL
            // 
            this.buttonCANCEL.BackColor = System.Drawing.Color.Red;
            this.buttonCANCEL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCANCEL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCANCEL.Location = new System.Drawing.Point(82, 188);
            this.buttonCANCEL.Name = "buttonCANCEL";
            this.buttonCANCEL.Size = new System.Drawing.Size(107, 40);
            this.buttonCANCEL.TabIndex = 25;
            this.buttonCANCEL.Text = "Thoát";
            this.buttonCANCEL.UseVisualStyleBackColor = false;
            this.buttonCANCEL.Click += new System.EventHandler(this.ButtonCANCEL_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn1.Properties.Resources.watercolor_5_rounded_hexagon_wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 289);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.AccountLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.buttonLOGIN);
            this.Controls.Add(this.buttonCANCEL);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label AccountLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button buttonLOGIN;
        private System.Windows.Forms.Button buttonCANCEL;
    }
}

