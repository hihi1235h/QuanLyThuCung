using HTQuanLyThuCung.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HTQuanLyThuCung.frmDichVu;

namespace HTQuanLyThuCung
{
    public partial class frmDichVu : Form
    {
        int Id = -1;
        bool isLoading = true;

        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            isLoading = true; // Bắt đầu load; 
            SetupInterface();
            LoadServices();   // Load dữ liệu

            dgvDichVu.ClearSelection(); // Bỏ chọn dòng mặc định
            ClearForm();                // Đảm bảo TextBox trống

            isLoading = false; // Load xong, từ bây giờ click mới hiện dữ liệu
        }

        void SetupInterface()
        {
            // 1. Tắt style mặc định của Windows để tự chỉnh theo ý mình
            dgvDichVu.EnableHeadersVisualStyles = false;

            // 2. Chỉnh tiêu đề (ColumnHeaders)
            // Đặt màu nền và màu chọn (Selection) CÙNG MỘT MÀU để khi nhấp vào nó không đổi màu
            dgvDichVu.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // Hoặc Color.FromArgb(240, 240, 240) tùy bạn
            dgvDichVu.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White; // QUAN TRỌNG: Nhấp vào vẫn là màu trắng

            dgvDichVu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDichVu.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black; // Chữ vẫn đen khi nhấp

            dgvDichVu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvDichVu.ColumnHeadersHeight = 45;

            // 3. Chỉnh phần nội dung dòng bên dưới
            dgvDichVu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 229, 255); //khi chọn dòng
            dgvDichVu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDichVu.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // 4. Các thiết lập sạch sẽ khác
            dgvDichVu.RowHeadersVisible = false; // Ẩn cột số thứ tự bên trái cho đẹp
            dgvDichVu.BackgroundColor = Color.White;
            dgvDichVu.BorderStyle = BorderStyle.None;
            dgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        void LoadServices()
        {
            dgvDichVu.AutoGenerateColumns = true;
            string query = "SELECT * FROM Services";
            dgvDichVu.DataSource = DatabaseHelper.ExecuteQuery(query);

            // KHÓA SẮP XẾP: Để thứ tự không bị chạy lung tung khi nhấn vào tiêu đề
            foreach (DataGridViewColumn column in dgvDichVu.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Ép các dòng hiện tại to ra theo RowTemplate
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                row.Height = 40;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text == "" || txtGiaTien.Text == "")
            {
                MessageBox.Show("Please enter full information!");
                return;
            }

            string query = @"INSERT INTO Services(ServiceName, Price, Description)
                             VALUES (@Name, @Price, @Desc)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", txtTenDichVu.Text),
                new SqlParameter("@Price", decimal.Parse(txtGiaTien.Text)),
                new SqlParameter("@Desc", txtChiTiet.Text)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);

            MessageBox.Show("Add service successfully!");

            LoadServices();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Id == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtGiaTien.Text, out price))
            {
                MessageBox.Show("Giá tiền không hợp lệ!");
                return;
            }

            string query = @"UPDATE Services 
                     SET ServiceName=@Name, Price=@Price, Description=@Desc
                     WHERE Id=@Id";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Name", txtTenDichVu.Text),
        new SqlParameter("@Price", price),
        new SqlParameter("@Desc", txtChiTiet.Text),
        new SqlParameter("@Id", Id)
    };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật  thành công!");

                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Id == -1)
            {
                MessageBox.Show("Please select a service to delete!");
                return;
            }

            DialogResult rs = MessageBox.Show("Are you sure to delete?",
                                              "Confirm",
                                              MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                string query = "DELETE FROM Services WHERE ServiceId=@Id";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Id", Id)
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Delete successfully!");

                LoadServices();
                ClearForm();
            }
        }

        void ClearForm()
        {
            txtTenDichVu.Clear();
            txtGiaTien.Clear();
            txtChiTiet.Clear();
            Id = -1;
        }

        private void dgvDichVu_SelectionChanged(object sender, EventArgs e)
        {
            // Nếu đang load app HOẶC chưa chọn dòng nào thì thoát, không hiện lên TextBox
            if (isLoading || dgvDichVu.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvDichVu.SelectedRows[0];
            if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
            {
                Id = Convert.ToInt32(row.Cells[0].Value);
                txtTenDichVu.Text = row.Cells[1].Value?.ToString();
                txtGiaTien.Text = row.Cells[2].Value?.ToString();
                txtChiTiet.Text = row.Cells[3].Value?.ToString();
            }
        }
    }
}
