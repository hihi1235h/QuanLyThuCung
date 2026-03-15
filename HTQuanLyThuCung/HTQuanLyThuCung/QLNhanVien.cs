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
    public partial class QLNhanVien : Form
    {
        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
                cbChucVu.Items.Add("Quản lý");
                cbChucVu.Items.Add("Nhân viên bán hàng");
                cbChucVu.Items.Add("Thu ngân");

                cbGioLam.Items.Add("Ca sáng");
                cbGioLam.Items.Add("Ca chiều");
                cbGioLam.Items.Add("Ca tối");

                dataGridView1.ColumnCount = 5;

                dataGridView1.Columns[0].Name = "Tên nhân viên";
                dataGridView1.Columns[1].Name = "Số điện thoại";
                dataGridView1.Columns[2].Name = "Email";
                dataGridView1.Columns[3].Name = "Chức vụ";
                dataGridView1.Columns[4].Name = "Giờ làm việc";
            }
        }
    }
