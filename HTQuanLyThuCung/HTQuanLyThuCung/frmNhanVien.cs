using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // Thiết lập các cột hiển thị
            dgvNhanVien.Columns.Clear();
            dgvNhanVien.Columns.Add("id", "#");
            dgvNhanVien.Columns.Add("ten", "Tên nhân viên");
            dgvNhanVien.Columns.Add("sdt", "Số điện thoại");
            dgvNhanVien.Columns.Add("dc", "Địa chỉ");
            dgvNhanVien.Columns.Add("em", "Email");
            dgvNhanVien.Columns.Add("cc", "CCCD");
            dgvNhanVien.Columns.Add("ca", "Ca làm");

            dgvNhanVien.Columns["id"].FillWeight = 30; // Cột số thứ tự nhỏ lại cho cân đối

            // Mới chạy ô Ca làm việc sẽ trống
            cboCaLam.SelectedIndex = -1;

            LoadData();
        }

        void LoadData()
        {
            dgvNhanVien.Rows.Clear();
            // Nạp dữ liệu 15 nhân viên TP.HCM
            dgvNhanVien.Rows.Add("1", "Nguyễn Văn An", "0901234567", "Quận 1, TP HCM", "an.nguyen@gmail.com", "079090001234", "Ca Sáng");
            dgvNhanVien.Rows.Add("2", "Lê Thị Bình", "0912345678", "Quận 3, TP HCM", "binh.le@gmail.com", "079091005678", "Ca Chiều");
            dgvNhanVien.Rows.Add("3", "Trần Minh Cường", "0923456789", "Quận Bình Thạnh, TP HCM", "cuong.tran@gmail.com", "079092009012", "Ca Tối");
            dgvNhanVien.Rows.Add("4", "Phạm Thanh Dung", "0934567890", "Quận Tân Bình, TP HCM", "dung.pham@gmail.com", "079093003456", "Ca Sáng");
            dgvNhanVien.Rows.Add("5", "Hoàng Anh Tuấn", "0945678901", "Quận Gò Vấp, TP HCM", "tuan.hoang@gmail.com", "079094007890", "Ca Chiều");
            dgvNhanVien.Rows.Add("6", "Vũ Mỹ Hạnh", "0956789012", "Quận Phú Nhuận, TP HCM", "hanh.vu@gmail.com", "079095001234", "Ca Tối");
            dgvNhanVien.Rows.Add("7", "Đặng Hữu Phước", "0967890123", "Quận 7, TP HCM", "phuoc.dang@gmail.com", "079096005678", "Ca Sáng");
            dgvNhanVien.Rows.Add("8", "Bùi Minh Tâm", "0978901234", "Quận 10, TP HCM", "tam.bui@gmail.com", "079097009012", "Ca Chiều");
            dgvNhanVien.Rows.Add("9", "Đỗ Kim Liên", "0989012345", "Quận 12, TP HCM", "lien.do@gmail.com", "079098003456", "Ca Tối");

            dgvNhanVien.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text) || cboCaLam.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            int id = dgvNhanVien.Rows.Count + 1;
            dgvNhanVien.Rows.Add(id.ToString(), txtTen.Text, txtSdt.Text, txtDiaChi.Text, txtEmail.Text, txtCccd.Text, cboCaLam.Text);

            // Clear và reset combo
            txtTen.Clear(); txtSdt.Clear(); txtDiaChi.Clear(); txtEmail.Clear(); txtCccd.Clear();
            cboCaLam.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                dgvNhanVien.Rows.RemoveAt(dgvNhanVien.SelectedRows[0].Index);
            }
        }
    }
}