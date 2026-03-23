using HTQuanLyThuCung.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static QuanLyThuCung.frmKhachHang;

namespace QuanLyThuCung
{
    public partial class frmKhachHang_ChiTiet : Form
    {
        private Customer customer;
        private List<Pet> customerPets;
        private frmKhachHang parentForm;
        private bool isEditMode = false;

        public frmKhachHang_ChiTiet(Customer customer, List<PurchaseHistory> histories,
            List<Pet> pets, frmKhachHang parent)
        {
            InitializeComponent();
            this.customer = customer;
            this.customerPets = pets;
            this.parentForm = parent;
            LoadData();
            LoadPetList();
            LoadPurchaseHistoryFromDB(); // ✅ Load từ DB thật
        }

        private void LoadData()
        {
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtOtherInfo.Text = customer.OtherInfo;
            SetReadOnlyMode(true);
        }

        private void LoadPurchaseHistoryFromDB()
        {
            try
            {
                dgvPurchaseHistory.Rows.Clear();

                DataTable dt = DatabaseHelper.ExecuteStoredProcedure(
                    "sp_GetHoaDonByCustomer",
                    new SqlParameter("@CustomerId", customer.Id));

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvPurchaseHistory.Rows.Add();
                    dgvPurchaseHistory.Rows[rowIndex].Cells["colInvoiceId"].Value =
                        row["MaHD"].ToString();
                    dgvPurchaseHistory.Rows[rowIndex].Cells["colDate"].Value =
                        Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy HH:mm");
                    dgvPurchaseHistory.Rows[rowIndex].Cells["colTotal"].Value =
                        Convert.ToDecimal(row["TongTien"]).ToString("N0") + " đ";
                    dgvPurchaseHistory.Rows[rowIndex].Cells["colEmployee"].Value =
                        row["NhanVien"].ToString();

                    // Lưu HoaDonId vào Tag để sau này xem chi tiết
                    dgvPurchaseHistory.Rows[rowIndex].Tag =
                        Convert.ToInt32(row["MaHD"]);
                }

                dgvPurchaseHistory.EnableHeadersVisualStyles = false;
                dgvPurchaseHistory.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.FromArgb(41, 128, 185);
                dgvPurchaseHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvPurchaseHistory.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Segoe UI", 9f, FontStyle.Bold);
                dgvPurchaseHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
                dgvPurchaseHistory.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(245, 245, 245);
                dgvPurchaseHistory.RowHeadersVisible = false;
                dgvPurchaseHistory.BorderStyle = BorderStyle.None;
            }
            catch (Exception ex)
            {
                // Nếu bảng HoaDon chưa tạo thì bỏ qua lỗi
                if (ex.Message.Contains("HoaDon") || ex.Message.Contains("sp_GetHoaDonByCustomer"))
                    return;
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPetList()
        {
            dgvPets.Rows.Clear();
            foreach (var pet in customerPets)
            {
                int rowIndex = dgvPets.Rows.Add();
                dgvPets.Rows[rowIndex].Cells["colPetId"].Value = pet.Id;
                dgvPets.Rows[rowIndex].Cells["colPetName"].Value = pet.Name;
                dgvPets.Rows[rowIndex].Cells["colPetType"].Value = pet.Type;
                dgvPets.Rows[rowIndex].Cells["colPetBreed"].Value = pet.Breed;
                dgvPets.Rows[rowIndex].Cells["colPetAge"].Value = pet.Age;
                dgvPets.Rows[rowIndex].Cells["colPetEdit"].Value = "✏️";
                dgvPets.Rows[rowIndex].Cells["colPetDelete"].Value = "🗑";
            }
        }

        private void SetReadOnlyMode(bool readOnly)
        {
            txtName.ReadOnly = readOnly;
            txtPhone.ReadOnly = readOnly;
            txtAddress.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtOtherInfo.ReadOnly = readOnly;

            Color bg = readOnly ? Color.FromArgb(220, 220, 220) : Color.White;
            txtName.BackColor = bg;
            txtPhone.BackColor = bg;
            txtAddress.BackColor = bg;
            txtEmail.BackColor = bg;
            txtOtherInfo.BackColor = bg;

            btnEdit.Text = readOnly ? "Sửa" : "Lưu";
            btnEdit.BackColor = readOnly
                ? Color.FromArgb(76, 175, 80)
                : Color.FromArgb(33, 150, 243);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                customer.Name = txtName.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.OtherInfo = txtOtherInfo.Text.Trim();

                try
                {
                    DatabaseHelper.ExecuteNonQuery(
                        @"UPDATE Customers SET
                          CustomerName = @Name,
                          Phone        = @Phone,
                          Address      = @Address,
                          Email        = @Email,
                          OtherInfo    = @OtherInfo
                          WHERE Id = @Id",
                        new SqlParameter("@Name", customer.Name),
                        new SqlParameter("@Phone", customer.Phone),
                        new SqlParameter("@Address", customer.Address),
                        new SqlParameter("@Email", customer.Email ?? ""),
                        new SqlParameter("@OtherInfo", customer.OtherInfo ?? ""),
                        new SqlParameter("@Id", customer.Id));

                    MessageBox.Show("✅ Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isEditMode = false;
                SetReadOnlyMode(true);
            }
            else
            {
                isEditMode = true;
                SetReadOnlyMode(false);
                txtName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            frmPetForm petForm = new frmPetForm(null, true);
            if (petForm.ShowDialog() == DialogResult.OK)
            {
                Pet newPet = petForm.GetPetData();
                newPet.CustomerId = customer.Id;

                try
                {
                    DatabaseHelper.ExecuteStoredProcedure("sp_AddPet",
                        new SqlParameter("@PetName", newPet.Name),
                        new SqlParameter("@Species", newPet.Type),
                        new SqlParameter("@Breed", newPet.Breed),
                        new SqlParameter("@Age", newPet.Age),
                        new SqlParameter("@CustomerId", newPet.CustomerId));

                    object newId = DatabaseHelper.ExecuteScalar(
                        "SELECT MAX(Id) FROM Pets WHERE CustomerId=@CId AND PetName=@Name",
                        new SqlParameter("@CId", newPet.CustomerId),
                        new SqlParameter("@Name", newPet.Name));
                    newPet.Id = Convert.ToInt32(newId);

                    customerPets.Add(newPet);
                    LoadPetList();
                    parentForm.RefreshPetList(customer.Id, customerPets);

                    MessageBox.Show("✅ Thêm thú cưng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm thú cưng: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPets.Columns[e.ColumnIndex].Name == "colPetEdit")
            {
                int petId = Convert.ToInt32(dgvPets.Rows[e.RowIndex].Cells["colPetId"].Value);
                EditPet(petId);
            }
            else if (dgvPets.Columns[e.ColumnIndex].Name == "colPetDelete")
            {
                int petId = Convert.ToInt32(dgvPets.Rows[e.RowIndex].Cells["colPetId"].Value);
                DeletePet(petId);
            }
        }

        private void EditPet(int petId)
        {
            Pet pet = customerPets.Find(p => p.Id == petId);
            if (pet == null) return;

            frmPetForm petForm = new frmPetForm(pet, false);
            if (petForm.ShowDialog() == DialogResult.OK)
            {
                Pet updated = petForm.GetPetData();
                updated.Id = pet.Id;
                updated.CustomerId = customer.Id;

                try
                {
                    DatabaseHelper.ExecuteStoredProcedure("sp_UpdatePet",
                        new SqlParameter("@PetId", updated.Id),
                        new SqlParameter("@PetName", updated.Name),
                        new SqlParameter("@Species", updated.Type),
                        new SqlParameter("@Breed", updated.Breed),
                        new SqlParameter("@Age", updated.Age));

                    int index = customerPets.FindIndex(p => p.Id == petId);
                    if (index >= 0) customerPets[index] = updated;

                    LoadPetList();
                    parentForm.RefreshPetList(customer.Id, customerPets);

                    MessageBox.Show("✅ Cập nhật thú cưng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeletePet(int petId)
        {
            Pet pet = customerPets.Find(p => p.Id == petId);
            if (pet == null) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa thú cưng \"{pet.Name}\"?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteStoredProcedure("sp_DeletePet",
                        new SqlParameter("@PetId", petId));

                    customerPets.RemoveAll(p => p.Id == petId);
                    LoadPetList();
                    parentForm.RefreshPetList(customer.Id, customerPets);

                    MessageBox.Show("✅ Xóa thú cưng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetNextPetId()
        {
            return customerPets.Count > 0 ? customerPets.Max(p => p.Id) + 1 : 1;
        }
    }
}