namespace HTQuanLyThuCung
{
    partial class frmQuenMK
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsernameOrEmail = new System.Windows.Forms.Label();
            this.txtUsernameOrEmail = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.linklblDangNhap = new System.Windows.Forms.LinkLabel();
            this.lblHint = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(110, 20);
            this.lblTitle.Text = "Đặt lại mật khẩu";

            // Username / Email
            this.lblUsernameOrEmail.AutoSize = true;
            this.lblUsernameOrEmail.Location = new System.Drawing.Point(20, 80);
            this.lblUsernameOrEmail.Text = "Tên đăng nhập hoặc Email";

            this.txtUsernameOrEmail.Location = new System.Drawing.Point(220, 78);
            this.txtUsernameOrEmail.Size = new System.Drawing.Size(220, 22);

            // Password
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Location = new System.Drawing.Point(20, 120);
            this.lblMatKhauMoi.Text = "Mật khẩu mới";

            this.txtMatKhauMoi.Location = new System.Drawing.Point(220, 118);
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(220, 22);

            // Confirm
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(20, 160);
            this.lblXacNhanMatKhau.Text = "Xác nhận mật khẩu";

            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(220, 158);
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(220, 22);

            // Button Confirm
            this.btnXacNhan.Location = new System.Drawing.Point(200, 210);
            this.btnXacNhan.Size = new System.Drawing.Size(110, 35);
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // Button Cancel
            this.btnHuy.Location = new System.Drawing.Point(330, 210);
            this.btnHuy.Size = new System.Drawing.Size(110, 35);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // Link login
            this.linklblDangNhap.AutoSize = true;
            this.linklblDangNhap.Location = new System.Drawing.Point(345, 260);
            this.linklblDangNhap.Text = "Đăng nhập";
            this.linklblDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDangNhap_LinkClicked);

            // Hint
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(190, 260);
            this.lblHint.Text = "Nhớ mật khẩu? Quay lại";

            // Form
            this.ClientSize = new System.Drawing.Size(480, 290);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsernameOrEmail);
            this.Controls.Add(this.txtUsernameOrEmail);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblXacNhanMatKhau);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.linklblDangNhap);
            this.Controls.Add(this.lblHint);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsernameOrEmail;
        private System.Windows.Forms.TextBox txtUsernameOrEmail;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.LinkLabel linklblDangNhap;
        private System.Windows.Forms.Label lblHint;
    }
}