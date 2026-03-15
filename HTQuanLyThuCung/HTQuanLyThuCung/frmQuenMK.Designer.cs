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

            // FORM
            this.ClientSize = new System.Drawing.Size(420, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.BackColor = System.Drawing.Color.MistyRose;

            // TITLE
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitle.Text = "Đặt lại mật khẩu";
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Size = new System.Drawing.Size(420, 40);

            // USERNAME / EMAIL
            this.lblUsernameOrEmail.AutoSize = true;
            this.lblUsernameOrEmail.Text = "Tên đăng nhập hoặc Email:";
            this.lblUsernameOrEmail.Location = new System.Drawing.Point(60, 90);

            this.txtUsernameOrEmail.Location = new System.Drawing.Point(60, 110);
            this.txtUsernameOrEmail.Size = new System.Drawing.Size(300, 23);

            // PASSWORD
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            this.lblMatKhauMoi.Location = new System.Drawing.Point(60, 145);

            this.txtMatKhauMoi.Location = new System.Drawing.Point(60, 165);
            this.txtMatKhauMoi.Size = new System.Drawing.Size(300, 23);
            this.txtMatKhauMoi.PasswordChar = '*';

            // CONFIRM PASSWORD
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Text = "Xác nhận mật khẩu:";
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(60, 200);

            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(60, 220);
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(300, 23);
            this.txtXacNhanMatKhau.PasswordChar = '*';

            // BUTTON CONFIRM
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Location = new System.Drawing.Point(60, 260);
            this.btnXacNhan.Size = new System.Drawing.Size(140, 35);
            this.btnXacNhan.BackColor = System.Drawing.Color.LightCoral;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // BUTTON CANCEL
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Location = new System.Drawing.Point(220, 260);
            this.btnHuy.Size = new System.Drawing.Size(140, 35);
            this.btnHuy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // HINT
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Text = "Nhớ mật khẩu?";
            this.lblHint.Location = new System.Drawing.Point(120, 310);

            // LINK LOGIN
            this.linklblDangNhap.AutoSize = true;
            this.linklblDangNhap.Text = "Đăng nhập";
            this.linklblDangNhap.Location = new System.Drawing.Point(220, 310);
            this.linklblDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDangNhap_LinkClicked);

            // ADD CONTROLS
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsernameOrEmail);
            this.Controls.Add(this.txtUsernameOrEmail);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblXacNhanMatKhau);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.linklblDangNhap);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }

}
