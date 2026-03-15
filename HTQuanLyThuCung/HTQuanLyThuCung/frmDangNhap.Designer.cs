namespace HTQuanLyThuCung
{
    partial class frmDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel linkDangKy;
        private System.Windows.Forms.LinkLabel linklblQuenMatKhau;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.linkDangKy = new System.Windows.Forms.LinkLabel();
            this.linklblQuenMatKhau = new System.Windows.Forms.LinkLabel();

            this.SuspendLayout();

            // TITLE
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(100, 20);
            this.labelTitle.Text = "Z618 STORE LOGIN";

            // USER LABEL
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(60, 90);
            this.lblTaiKhoan.Text = "Tài khoản";

            // USER TEXTBOX
            this.txtTaiKhoan.Location = new System.Drawing.Point(60, 110);
            this.txtTaiKhoan.Size = new System.Drawing.Size(280, 22);
            this.txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);

            // PASS LABEL
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(60, 150);
            this.lblMatKhau.Text = "Mật khẩu";

            // PASS TEXTBOX
            this.txtMatKhau.Location = new System.Drawing.Point(60, 170);
            this.txtMatKhau.Size = new System.Drawing.Size(280, 22);
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);

            // CHECKBOX
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Location = new System.Drawing.Point(60, 210);
            this.chkGhiNho.Text = "Ghi nhớ đăng nhập";

            // LOGIN BUTTON
            this.btnDangNhap.Location = new System.Drawing.Point(60, 240);
            this.btnDangNhap.Size = new System.Drawing.Size(280, 35);
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);

            // LINK QUÊN MẬT KHẨU
            this.linklblQuenMatKhau.AutoSize = true;
            this.linklblQuenMatKhau.Location = new System.Drawing.Point(60, 290);
            this.linklblQuenMatKhau.Text = "Quên mật khẩu";
            this.linklblQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblQuenMatKhau_LinkClicked);

            // LINK ĐĂNG KÝ
            this.linkDangKy.AutoSize = true;
            this.linkDangKy.Location = new System.Drawing.Point(250, 290);
            this.linkDangKy.Text = "Đăng ký";
            this.linkDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangKy_LinkClicked);

            // FORM
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.chkGhiNho);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.linklblQuenMatKhau);
            this.Controls.Add(this.linkDangKy);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý thú cưng";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}