using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThi
{
    public partial class frmDMNhanVien : Form
    {
        NHANVIEN model = new NHANVIEN();
        public frmDMNhanVien()
        {
            InitializeComponent();
            loadDataToGrv();
        }
        void loadDataToGrv()
        {
            dgvNV.AutoGenerateColumns = false;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                dgvNV.DataSource = luu.CreateDataTable<NHANVIEN>(db.NHANVIENs.ToList<NHANVIEN>());

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            model.Manhanvien = txtMNV.Text;
            model.Tennhanvien = txtTenNV.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
            if (chkNam.Checked)
            {
                model.Gioitinh = "nam";
            }
            else
            {
                model.Gioitinh = "nữ";
            }
            model.Ngaysinh = dtpNgaySinh.Value;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.NHANVIENs.Add(model);
                db.SaveChanges();
                MessageBox.Show("Chèn Thành Công", "Thông báo");
                txtMNV.Text = "";
                txtTenNV.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                loadDataToGrv();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            model.Manhanvien = txtMNV.Text;
            model.Tennhanvien = txtTenNV.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
            if (chkNam.Checked)
            {
                model.Gioitinh = "nam";
            }
            else
            {
                model.Gioitinh = "nữ";
            }
            model.Ngaysinh = dtpNgaySinh.Value;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                txtMNV.Text = "";
                txtTenNV.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                btnXoa.Enabled = btnSua.Enabled = false;
                btnThem.Enabled = true;
                loadDataToGrv();
            }
        }

        private void dgvNV_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMNV.Focus();
                return;
            }
            txtMNV.Text = dgvNV.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txtTenNV.Text = dgvNV.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            if (dgvNV.CurrentRow.Cells["Gioitinh"].Value.ToString() == "nam") chkNam.Checked = true;
            else chkNam.Checked = false;
            txtDiaChi.Text = dgvNV.CurrentRow.Cells["Diachi"].Value.ToString();
            txtSDT.Text = dgvNV.CurrentRow.Cells["sdt"].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvNV.CurrentRow.Cells["Ngaysinh"].Value;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            model.Manhanvien = txtMNV.Text;
            model.Tennhanvien = txtTenNV.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
            if (chkNam.Checked)
            {
                model.Gioitinh = "nam";
            }
            else
            {
                model.Gioitinh = "nữ";
            }
            model.Ngaysinh = dtpNgaySinh.Value;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Thông báo");
                txtMNV.Text = "";
                txtTenNV.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                btnXoa.Enabled = btnSua.Enabled = false;
                btnThem.Enabled = true;
                loadDataToGrv();
            }
        }
    }
}
