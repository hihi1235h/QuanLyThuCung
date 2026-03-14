using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuThuCung;
        private System.Windows.Forms.ToolStripMenuItem mnuBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnuHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnuDichVu;
        private System.Windows.Forms.ToolStripMenuItem mnuKhuyenMai;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();

            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem("Quản lý nhân viên");
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem("Quản lý khách hàng");
            this.mnuThuCung = new System.Windows.Forms.ToolStripMenuItem("Quản lý thú cưng");
            this.mnuBanHang = new System.Windows.Forms.ToolStripMenuItem("Quản lý bán hàng");
            this.mnuHangHoa = new System.Windows.Forms.ToolStripMenuItem("Quản lý hàng hóa");
            this.mnuDichVu = new System.Windows.Forms.ToolStripMenuItem("Quản lý dịch vụ");
            this.mnuKhuyenMai = new System.Windows.Forms.ToolStripMenuItem("Quản lý khuyến mãi");
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem("Thống kê báo cáo");

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                mnuNhanVien,
                mnuKhachHang,
                mnuThuCung,
                mnuBanHang,
                mnuHangHoa,
                mnuDichVu,
                mnuKhuyenMai,
                mnuThongKe
            });

            this.Controls.Add(menuStrip1);

            this.MainMenuStrip = menuStrip1;

            this.Text = "Hệ thống Quản lý Cửa hàng Thú Cưng";
            this.WindowState = FormWindowState.Maximized;
        }
    }
}