namespace HTQuanLyThuCung
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblNoteUser;
        private System.Windows.Forms.Label lblNotePass;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel linkDangKy;
        private System.Windows.Forms.LinkLabel linklblQuenMatKhau;
        private System.Windows.Forms.Label lblChuaCoTK;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblNoteUser = new System.Windows.Forms.Label();
            this.lblNotePass = new System.Windows.Forms.Label();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.linkDangKy = new System.Windows.Forms.LinkLabel();
            this.linklblQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.lblChuaCoTK = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🐾 Z618 Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(70, 90);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(70, 16);
            this.lblTaiKhoan.TabIndex = 1;
            this.lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(70, 155);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(64, 16);
            this.lblMatKhau.TabIndex = 4;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(70, 110);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(280, 22);
            this.txtTaiKhoan.TabIndex = 2;
            this.txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(70, 175);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(280, 22);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // lblNoteUser
            // 
            this.lblNoteUser.AutoSize = true;
            this.lblNoteUser.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNoteUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoteUser.Location = new System.Drawing.Point(70, 135);
            this.lblNoteUser.Name = "lblNoteUser";
            this.lblNoteUser.Size = new System.Drawing.Size(188, 19);
            this.lblNoteUser.TabIndex = 3;
            this.lblNoteUser.Text = "Nhập tên đăng nhập của bạn";
            // 
            // lblNotePass
            // 
            this.lblNotePass.AutoSize = true;
            this.lblNotePass.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNotePass.ForeColor = System.Drawing.Color.DimGray;
            this.lblNotePass.Location = new System.Drawing.Point(70, 200);
            this.lblNotePass.Name = "lblNotePass";
            this.lblNotePass.Size = new System.Drawing.Size(214, 19);
            this.lblNotePass.TabIndex = 6;
            this.lblNotePass.Text = "Nhập mật khẩu (tối thiểu 6 ký tự)";
            // 
            // chkGhiNho
            // 
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Location = new System.Drawing.Point(70, 225);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(141, 20);
            this.chkGhiNho.TabIndex = 7;
            this.chkGhiNho.Text = "Ghi nhớ đăng nhập";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.LightCoral;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Location = new System.Drawing.Point(70, 250);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(280, 35);
            this.btnDangNhap.TabIndex = 8;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // linkDangKy
            // 
            this.linkDangKy.AutoSize = true;
            this.linkDangKy.Location = new System.Drawing.Point(190, 300);
            this.linkDangKy.Name = "linkDangKy";
            this.linkDangKy.Size = new System.Drawing.Size(56, 16);
            this.linkDangKy.TabIndex = 10;
            this.linkDangKy.TabStop = true;
            this.linkDangKy.Text = "Đăng ký";
            this.linkDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangKy_LinkClicked);
            // 
            // linklblQuenMatKhau
            // 
            this.linklblQuenMatKhau.AutoSize = true;
            this.linklblQuenMatKhau.Location = new System.Drawing.Point(70, 320);
            this.linklblQuenMatKhau.Name = "linklblQuenMatKhau";
            this.linklblQuenMatKhau.Size = new System.Drawing.Size(103, 16);
            this.linklblQuenMatKhau.TabIndex = 11;
            this.linklblQuenMatKhau.TabStop = true;
            this.linklblQuenMatKhau.Text = "Quên mật khẩu?";
            this.linklblQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblQuenMatKhau_LinkClicked);
            // 
            // lblChuaCoTK
            // 
            this.lblChuaCoTK.AutoSize = true;
            this.lblChuaCoTK.Location = new System.Drawing.Point(70, 300);
            this.lblChuaCoTK.Name = "lblChuaCoTK";
            this.lblChuaCoTK.Size = new System.Drawing.Size(120, 16);
            this.lblChuaCoTK.TabIndex = 9;
            this.lblChuaCoTK.Text = "Chưa có tài khoản?";
            // 
            // frmDangNhap
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(420, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.lblNoteUser);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblNotePass);
            this.Controls.Add(this.chkGhiNho);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lblChuaCoTK);
            this.Controls.Add(this.linkDangKy);
            this.Controls.Add(this.linklblQuenMatKhau);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý thú cưng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
