using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThưcHanh04
{
    public partial class frmMatHang : Form
    {
        Classes.DataBaseProcess dtbase = new Classes.DataBaseProcess();

        public frmMatHang()
        {
            InitializeComponent();
        }
        private void HienChiTiet(bool hien)
        {
            txtMaSP.Enabled = hien;
            txtTenSP.Enabled = hien;
            dtpNgaySX.Enabled = hien; // Thêm lại dòng này để sáng ô Ngày sản xuất
            dtpNgayHH.Enabled = hien;
            txtDonVi.Enabled = hien;
            txtDonGia.Enabled = hien;
            txtGhiChu.Enabled = hien;
            // Bật/tắt 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        // Xóa trắng các ô nhập liệu trong Chi tiết
        private void XoaTrangChiTiet()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDonVi.Text = "";
            txtDonGia.Text = "";
            txtGhiChu.Text = "";
        }

        // 1. Sự kiện Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvKetQua.DataSource = dtbase.DataReader("Select * from tblMatHang");
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(false);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "TÌM KIẾM MẶT HÀNG";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            string sql = "SELECT * FROM tblMatHang where MaSP is not null ";
            if (txtTKMaSP.Text.Trim() != "")
            {
                sql += " and MaSP like '%" + txtTKMaSP.Text + "%'";
            }
            if (txtTKTenSP.Text.Trim() != "")
            {
                sql += " AND TenSP like N'%" + txtTKTenSP.Text + "%'";
            }
            dgvKetQua.DataSource = dtbase.DataReader(sql);
        }


        // Sự kiện Click chọn dòng trên DataGridView
        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            try
            {
                txtMaSP.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
                dtpNgaySX.Value = (DateTime)dgvKetQua.CurrentRow.Cells[2].Value;
                dtpNgayHH.Value = (DateTime)dgvKetQua.CurrentRow.Cells[3].Value;
                txtDonVi.Text = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
                txtDonGia.Text = dgvKetQua.CurrentRow.Cells[5].Value.ToString();
                txtGhiChu.Text = dgvKetQua.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
            }
        }
        // 3. Chức năng Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "THÊM MẶT HÀNG";
            XoaTrangChiTiet();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(true);
        }

        // 4. Chức năng Sửa
        private void button1_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "CẬP NHẬT MẶT HÀNG";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(true);
            txtMaSP.Enabled = false; // Không cho sửa mã sản phẩm khi cập nhật

        }

        // 5. Chức năng Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa mã mặt hàng " + txtMaSP.Text + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblTieuDe.Text = "XÓA MẶT HÀNG";
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                HienChiTiet(true);
            }
        }
        // 6. Chức năng Lưu (Thêm / Sửa / Xóa)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";

            // Kiểm tra ràng buộc dữ liệu
            if (txtTenSP.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenSP, "Bạn không để trống tên sản phẩm!");
                return;
            }
            else { errChiTiet.Clear(); }

            if (dtpNgaySX.Value > DateTime.Now)
            {
                errChiTiet.SetError(dtpNgaySX, "Ngày sản xuất không hợp lệ!");
                return;
            }
            else { errChiTiet.Clear(); }

            if (dtpNgayHH.Value < dtpNgaySX.Value)
            {
                errChiTiet.SetError(dtpNgayHH, "Ngày hết hạn nhỏ hơn ngày sản xuất!");
                return;
            }
            else { errChiTiet.Clear(); }

            if (txtDonVi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDonVi, "Bạn không để trống đơn vị!");
                return;
            }
            else { errChiTiet.Clear(); }

            if (txtDonGia.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDonGia, "Bạn không để trống đơn giá!");
                return;
            }
            else { errChiTiet.Clear(); }

            // Thêm mới
            if (btnThem.Enabled == true)
            {
                if (txtMaSP.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtMaSP, "Bạn không để trống mã sản phẩm trường này!");
                    return;
                }
                else
                {
                    sql = "Select * From tblMatHang Where MaSP ='" + txtMaSP.Text + "'";
                    DataTable dtSP = dtbase.DataReader(sql);
                    if (dtSP.Rows.Count > 0)
                    {
                        errChiTiet.SetError(txtMaSP, "Mã sản phẩm trùng trong cơ sở dữ liệu");
                        return;
                    }
                    errChiTiet.Clear();
                }

                sql = "INSERT INTO tblMatHang(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES(";
                sql += "N'" + txtMaSP.Text + "',N'" + txtTenSP.Text + "','" + dtpNgaySX.Value.Date.ToString("yyyy-MM-dd") + "','" +
                    dtpNgayHH.Value.Date.ToString("yyyy-MM-dd") + "',N'" + txtDonVi.Text + "'," + txtDonGia.Text + ",N'" + txtGhiChu.Text + "')";
            }

            // Sửa dữ liệu
            if (btnSua.Enabled == true)
            {
                sql = "Update tblMatHang SET ";
                sql += "TenSP = N'" + txtTenSP.Text + "',";
                sql += "NgaySX = '" + dtpNgaySX.Value.Date.ToString("yyyy-MM-dd") + "',";
                sql += "NgayHH = '" + dtpNgayHH.Value.Date.ToString("yyyy-MM-dd") + "',";
                sql += "DonVi = N'" + txtDonVi.Text + "',";
                sql += "DonGia = " + txtDonGia.Text + ",";
                sql += "GhiChu = N'" + txtGhiChu.Text + "' ";
                sql += "Where MaSP = N'" + txtMaSP.Text + "'";
            }

            // Xóa dữ liệu
            if (btnXoa.Enabled == true)
            {
                sql = "Delete From tblMatHang Where MaSP = N'" + txtMaSP.Text + "'";
            }

            dtbase.DataChange(sql);

            // Cập nhật lại DataGridView
            sql = "Select * from tblMatHang";
            dgvKetQua.DataSource = dtbase.DataReader(sql);

            // Reset trạng thái các nút
            HienChiTiet(false);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            XoaTrangChiTiet();
        }
        // 7. Chức năng Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            XoaTrangChiTiet();
            HienChiTiet(false);
        }

        // 8. Chức năng Thoát
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        // 9. Ràng buộc chỉ cho phép nhập số nguyên vào TextBox Đơn giá
        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }
    }
}
