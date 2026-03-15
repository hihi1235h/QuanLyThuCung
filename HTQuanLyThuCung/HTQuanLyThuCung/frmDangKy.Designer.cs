namespace HTQuanLyThuCung
{
    partial class frmDangKy
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaw;

        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblXacNhan;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblEmail;

        private System.Windows.Forms.Label hintUser;
        private System.Windows.Forms.Label hintPass;
        private System.Windows.Forms.Label hintConfirm;
        private System.Windows.Forms.Label hintEmail;

        private System.Windows.Forms.CheckBox chkDongYDieuKhoan;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.LinkLabel linklblDangNhap;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPaw = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.hintUser = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.hintPass = new System.Windows.Forms.Label();
            this.lblXacNhan = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.hintConfirm = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.hintEmail = new System.Windows.Forms.Label();
            this.chkDongYDieuKhoan = new System.Windows.Forms.CheckBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linklblDangNhap = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblPaw
            // 
            this.lblPaw.AutoSize = true;
            this.lblPaw.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblPaw.Location = new System.Drawing.Point(66, 20);
            this.lblPaw.Name = "lblPaw";
            this.lblPaw.Size = new System.Drawing.Size(67, 46);
            this.lblPaw.TabIndex = 1;
            this.lblPaw.Text = "🐾";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Location = new System.Drawing.Point(118, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Z618 Register";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Location = new System.Drawing.Point(60, 90);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(100, 23);
            this.lblTaiKhoan.TabIndex = 2;
            this.lblTaiKhoan.Text = "Tài khoản:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(160, 88);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(220, 22);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // hintUser
            // 
            this.hintUser.AutoSize = true;
            this.hintUser.ForeColor = System.Drawing.Color.Gray;
            this.hintUser.Location = new System.Drawing.Point(160, 112);
            this.hintUser.Name = "hintUser";
            this.hintUser.Size = new System.Drawing.Size(204, 16);
            this.hintUser.TabIndex = 4;
            this.hintUser.Text = "3-50 ký tự, không có khoảng trống";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(60, 140);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(100, 23);
            this.lblMatKhau.TabIndex = 5;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(160, 138);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(220, 22);
            this.txtMatKhau.TabIndex = 6;
            // 
            // hintPass
            // 
            this.hintPass.AutoSize = true;
            this.hintPass.ForeColor = System.Drawing.Color.Gray;
            this.hintPass.Location = new System.Drawing.Point(160, 162);
            this.hintPass.Name = "hintPass";
            this.hintPass.Size = new System.Drawing.Size(191, 16);
            this.hintPass.TabIndex = 7;
            this.hintPass.Text = "Tối thiểu 6 ký tự, tối đa 100 ký tự";
            // 
            // lblXacNhan
            // 
            this.lblXacNhan.Location = new System.Drawing.Point(60, 190);
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Size = new System.Drawing.Size(100, 23);
            this.lblXacNhan.TabIndex = 8;
            this.lblXacNhan.Text = "Xác nhận:";
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(160, 188);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(220, 22);
            this.txtXacNhanMatKhau.TabIndex = 9;
            // 
            // hintConfirm
            // 
            this.hintConfirm.AutoSize = true;
            this.hintConfirm.ForeColor = System.Drawing.Color.Gray;
            this.hintConfirm.Location = new System.Drawing.Point(160, 212);
            this.hintConfirm.Name = "hintConfirm";
            this.hintConfirm.Size = new System.Drawing.Size(189, 16);
            this.hintConfirm.TabIndex = 10;
            this.hintConfirm.Text = "Nhập lại mật khẩu để xác nhận";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(60, 240);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 23);
            this.lblHoTen.TabIndex = 11;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(160, 238);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 22);
            this.txtHoTen.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(60, 280);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(160, 278);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 22);
            this.txtEmail.TabIndex = 14;
            // 
            // hintEmail
            // 
            this.hintEmail.AutoSize = true;
            this.hintEmail.ForeColor = System.Drawing.Color.Gray;
            this.hintEmail.Location = new System.Drawing.Point(160, 302);
            this.hintEmail.Name = "hintEmail";
            this.hintEmail.Size = new System.Drawing.Size(171, 16);
            this.hintEmail.TabIndex = 15;
            this.hintEmail.Text = "Ví dụ: example@email.com";
            // 
            // chkDongYDieuKhoan
            // 
            this.chkDongYDieuKhoan.AutoSize = true;
            this.chkDongYDieuKhoan.Location = new System.Drawing.Point(120, 330);
            this.chkDongYDieuKhoan.Name = "chkDongYDieuKhoan";
            this.chkDongYDieuKhoan.Size = new System.Drawing.Size(258, 20);
            this.chkDongYDieuKhoan.TabIndex = 16;
            this.chkDongYDieuKhoan.Text = "Tôi đồng ý với các điều khoản sử dụng";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.LightCoral;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Location = new System.Drawing.Point(120, 360);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(200, 40);
            this.btnXacNhan.TabIndex = 17;
            this.btnXacNhan.Text = "Đăng ký";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Đã có tài khoản?";
            // 
            // linklblDangNhap
            // 
            this.linklblDangNhap.AutoSize = true;
            this.linklblDangNhap.Location = new System.Drawing.Point(250, 415);
            this.linklblDangNhap.Name = "linklblDangNhap";
            this.linklblDangNhap.Size = new System.Drawing.Size(72, 16);
            this.linklblDangNhap.TabIndex = 19;
            this.linklblDangNhap.TabStop = true;
            this.linklblDangNhap.Text = "Đăng nhập";
            this.linklblDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDangNhap_LinkClicked);
            // 
            // frmDangKy
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(450, 470);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPaw);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.hintUser);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.hintPass);
            this.Controls.Add(this.lblXacNhan);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.hintConfirm);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.hintEmail);
            this.Controls.Add(this.chkDongYDieuKhoan);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linklblDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký - Quản lý thú cưng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
