using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HTQuanLyThuCung.DataAccess;
using HTQuanLyThuCung.Helpers;

namespace HTQuanLyThuCung
{
    // Form đăng ký tài khoản mới cho hệ thống Quản lý Thú Cưng
    public partial class frmDangKy : Form
    {
        public string TenDangNhapDaDangKy { get; private set; }

    private string _matKhauHopLeCuoi = "";
        private string _xacNhanMatKhauHopLeCuoi = "";
        private bool _dangKiemTra = false;

        public frmDangKy()
        {
            InitializeComponent();
            DangKySuKienKiemTraThoiGianThuc();
        }

        private void DangKySuKienKiemTraThoiGianThuc()
        {
            txtTaiKhoan.KeyPress += txtTaiKhoan_KeyPress;
            txtMatKhau.TextChanged += txtMatKhau_TextChanged;
            txtXacNhanMatKhau.TextChanged += txtXacNhanMatKhau_TextChanged;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            ThucHienDangKy();
        }

        private void linklblDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ThucHienDangKy()
        {
            try
            {
                if (!KiemTraDuLieu())
                    return;

                DuLieuDangKy duLieu = LayDuLieuDangKy();

                int maNguoiDung = DangKyNguoiDungVaoDatabase(duLieu);

                XuLyKetQuaDangKy(maNguoiDung, duLieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi đăng ký!\n\nChi tiết: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private DuLieuDangKy LayDuLieuDangKy()
        {
            return new DuLieuDangKy
            {
                TenDangNhap = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                HoTen = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

        private int DangKyNguoiDungVaoDatabase(DuLieuDangKy duLieu)
        {
            SqlParameter outUserId = new SqlParameter("@UserId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            string passwordHash = PasswordHelper.HashPassword(duLieu.MatKhau);

            SqlParameter[] parameters =
            {
            new SqlParameter("@Username", duLieu.TenDangNhap),
            new SqlParameter("@Password", passwordHash),
            new SqlParameter("@FullName", duLieu.HoTen),
            new SqlParameter("@Email", duLieu.Email),
            outUserId
        };

            DatabaseHelper.ExecuteStoredProcedureNonQuery("sp_UserRegister", parameters);

            if (outUserId.Value != DBNull.Value)
                return Convert.ToInt32(outUserId.Value);

            return 0;
        }

        private void XuLyKetQuaDangKy(int maNguoiDung, DuLieuDangKy duLieu)
        {
            int loiUser = SystemSettings.ErrorUsernameExists;
            int loiEmail = SystemSettings.ErrorEmailExists;

            if (maNguoiDung > 0)
            {
                TenDangNhapDaDangKy = duLieu.TenDangNhap;

                MessageBox.Show(
                    $"Đăng ký thành công!\n\nTài khoản: {duLieu.TenDangNhap}\nHọ tên: {duLieu.HoTen}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (maNguoiDung == loiUser)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
            }
            else if (maNguoiDung == loiEmail)
            {
                MessageBox.Show("Email đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTaiKhoan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }

            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                txtXacNhanMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }

            if (!EmailHopLe(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!");
                txtEmail.Focus();
                return false;
            }

            if (!chkDongYDieuKhoan.Checked)
            {
                MessageBox.Show("Bạn phải đồng ý điều khoản!");
                return false;
            }

            return true;
        }

        private bool EmailHopLe(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ cho phép chữ, số và _");
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (_dangKiemTra) return;

            if (PasswordHelper.ContainsDangerousCharacters(txtMatKhau.Text))
            {
                _dangKiemTra = true;
                txtMatKhau.Text = _matKhauHopLeCuoi;
                _dangKiemTra = false;

                MessageBox.Show("Mật khẩu chứa ký tự nguy hiểm!");
            }
            else
            {
                _matKhauHopLeCuoi = txtMatKhau.Text;
            }
        }

        private void txtXacNhanMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (_dangKiemTra) return;

            if (PasswordHelper.ContainsDangerousCharacters(txtXacNhanMatKhau.Text))
            {
                _dangKiemTra = true;
                txtXacNhanMatKhau.Text = _xacNhanMatKhauHopLeCuoi;
                _dangKiemTra = false;

                MessageBox.Show("Mật khẩu chứa ký tự nguy hiểm!");
            }
            else
            {
                _xacNhanMatKhauHopLeCuoi = txtXacNhanMatKhau.Text;
            }
        }

        private class DuLieuDangKy
        {
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string HoTen { get; set; }
            public string Email { get; set; }
        }
    }
}
