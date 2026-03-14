using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HTQuanLyThuCung.DataAccess;
using HTQuanLyThuCung.Helpers;

namespace HTQuanLyThuCung
{
    public partial class frmDangNhap : Form
    {
        private const int KHONG_CO_LOI = 0;
        private const int TAI_KHOAN_BI_KHOA = 2;

        private int _soLanDangNhapSai = 0;
        private DateTime? _thoiGianKhoaDen = null;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ThucHienDangNhap();
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chức năng đăng ký đang phát triển");
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chức năng quên mật khẩu đang phát triển");
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienDangNhap();
            }
        }

        private void ThucHienDangNhap()
        {
            try
            {
                if (TaiKhoanBiKhoa())
                    return;

                if (!KiemTraDuLieuDangNhap())
                    return;

                DataTable ketQua = XacThucNguoiDung();
                XuLyKetQuaDangNhap(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private bool TaiKhoanBiKhoa()
        {
            if (_thoiGianKhoaDen.HasValue && DateTime.Now < _thoiGianKhoaDen.Value)
            {
                int soPhut = (int)(_thoiGianKhoaDen.Value - DateTime.Now).TotalMinutes;
                MessageBox.Show($"Tài khoản bị khóa. Thử lại sau {soPhut} phút.");
                return true;
            }
            return false;
        }

        private bool KiemTraDuLieuDangNhap()
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                txtTaiKhoan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtMatKhau.Focus();
                return false;
            }

            return true;
        }

        private DataTable XacThucNguoiDung()
        {
            string user = txtTaiKhoan.Text.Trim();
            string pass = txtMatKhau.Text;

            SqlParameter[] pr =
            {
                new SqlParameter("@Username",user),
                new SqlParameter("@Password",pass)
            };

            return DatabaseHelper.ExecuteStoredProcedure("sp_UserLogin", pr);
        }

        private void XuLyKetQuaDangNhap(DataTable kq)
        {
            if (kq == null || kq.Rows.Count == 0)
            {
                DangNhapThatBai();
                return;
            }

            DataRow row = kq.Rows[0];

            int id = Convert.ToInt32(row["Id"]);
            string ten = row["FullName"].ToString();

            CurrentUser.SetCurrentUser(id, txtTaiKhoan.Text, ten);

            MessageBox.Show("Đăng nhập thành công");

            this.Hide();

            frmMain f = new frmMain();
            f.ShowDialog();

            this.Close();
        }

        private void DangNhapThatBai()
        {
            _soLanDangNhapSai++;

            MessageBox.Show("Sai tài khoản hoặc mật khẩu");

            if (_soLanDangNhapSai >= 5)
            {
                _thoiGianKhoaDen = DateTime.Now.AddMinutes(5);
                MessageBox.Show("Bạn đã nhập sai quá nhiều lần. Tài khoản bị khóa 5 phút.");
            }

            txtMatKhau.Clear();
            txtMatKhau.Focus();
        }
    }
}