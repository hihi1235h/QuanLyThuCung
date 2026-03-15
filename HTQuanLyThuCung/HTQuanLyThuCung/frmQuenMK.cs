using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HTQuanLyThuCung.DataAccess;
using HTQuanLyThuCung.Helpers;

namespace HTQuanLyThuCung
{
    public partial class frmQuenMK : Form
    {
        private const int DAT_LAI_MAT_KHAU_THANH_CONG = 1;
        private const int KHONG_TIM_THAY_USER = -1;
        private const int TAI_KHOAN_BI_VO_HIEU_HOA = -2;

        public frmQuenMK()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            ThucHienDatLaiMatKhau();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void ThucHienDatLaiMatKhau()
        {
            try
            {
                if (!KiemTraDuLieu())
                    return;

                string usernameOrEmail = txtUsernameOrEmail.Text.Trim();
                string newPassword = txtMatKhauMoi.Text;

                int ketQua = DatLaiMatKhauTrongDatabase(usernameOrEmail, newPassword);

                XuLyKetQuaDatLaiMatKhau(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi đặt lại mật khẩu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtUsernameOrEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập hoặc email!");
                txtUsernameOrEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return false;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                txtXacNhanMatKhau.Focus();
                return false;
            }

            return true;
        }

        private int DatLaiMatKhauTrongDatabase(string usernameOrEmail, string newPassword)
        {
            string passwordHash = PasswordHelper.HashPassword(newPassword);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UsernameOrEmail", usernameOrEmail),
                new SqlParameter("@NewPassword", passwordHash),
                new SqlParameter("@Result", SqlDbType.Int){Direction = ParameterDirection.Output}
            };

            DatabaseHelper.ExecuteStoredProcedureNonQuery("sp_ResetPassword", parameters);

            return Convert.ToInt32(parameters[2].Value);
        }

        private void XuLyKetQuaDatLaiMatKhau(int ketQua)
        {
            switch (ketQua)
            {
                case DAT_LAI_MAT_KHAU_THANH_CONG:
                    MessageBox.Show(
                        "Đặt lại mật khẩu thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    this.Close();
                    break;

                case KHONG_TIM_THAY_USER:
                    MessageBox.Show(
                        "Không tìm thấy tài khoản!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    break;

                case TAI_KHOAN_BI_VO_HIEU_HOA:
                    MessageBox.Show(
                        "Tài khoản đã bị khóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    break;

                default:
                    MessageBox.Show(
                        "Có lỗi xảy ra!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;
            }
        }
    }
}