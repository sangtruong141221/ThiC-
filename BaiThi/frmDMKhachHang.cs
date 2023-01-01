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
    public partial class frmDMKhachHang : Form
    {
        KHACHANG model = new KHACHANG();
        public frmDMKhachHang()
        {
            InitializeComponent();
            loadDataToGrv();
        }
        void loadDataToGrv()
        {
            dgvKH.AutoGenerateColumns = false;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                dgvKH.DataSource = luu.CreateDataTable<KHACHANG>(db.KHACHANGs.ToList<KHACHANG>());

            }
        }

        private void dgvKH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMKH.Focus();
                return;
            }
            txtMKH.Text = dgvKH.CurrentRow.Cells["Makhach"].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells["Tenkhach"].Value.ToString();
            txtDiaChi.Text = dgvKH.CurrentRow.Cells["Diachi"].Value.ToString();
            txtSDT.Text = dgvKH.CurrentRow.Cells["sdt"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            model.Makhach = txtMKH.Text;
            model.Tenkhach = txtTenKH.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
           using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.KHACHANGs.Add(model);
                db.SaveChanges();
                MessageBox.Show("Chèn Thành Công", "Thông báo");
                txtMKH.Text = "";
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                loadDataToGrv();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            model.Makhach = txtMKH.Text;
            model.Tenkhach = txtTenKH.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                txtMKH.Text = "";
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                loadDataToGrv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            model.Makhach = txtMKH.Text;
            model.Tenkhach = txtTenKH.Text;
            model.Diachi = txtDiaChi.Text;
            model.sdt = txtSDT.Text;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Thông báo");
                txtMKH.Text = "";
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                loadDataToGrv();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
