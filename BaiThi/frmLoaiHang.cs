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
    public partial class frmLoaiHang : Form
    {
        LOAIHANG model = new LOAIHANG();
        public frmLoaiHang()
        {
            InitializeComponent();
            loadDataToGrv();
        }
        void loadDataToGrv()
        {
            dgvLH.AutoGenerateColumns = false;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                dgvLH.DataSource = luu.CreateDataTable<LOAIHANG>(db.LOAIHANGs.ToList<LOAIHANG>());

            }
        }

        private void dgvLH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMLH.Focus();
                return;
            }
            txtMLH.Text = dgvLH.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txtTenLH.Text = dgvLH.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            model.Maloaihang = txtMLH.Text;
            model.Tenloaihang = txtTenLH.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.LOAIHANGs.Add(model);
                db.SaveChanges();
                MessageBox.Show("Chèn Thành Công", "Thông báo");
                txtMLH.Text = "";
                txtTenLH.Text = "";
                loadDataToGrv();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            model.Maloaihang = txtMLH.Text;
            model.Tenloaihang = txtTenLH.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                txtMLH.Text = "";
                txtTenLH.Text = "";
                loadDataToGrv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            model.Maloaihang = txtMLH.Text;
            model.Tenloaihang = txtTenLH.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Thông báo");
                txtMLH.Text = "";
                txtTenLH.Text = "";
                loadDataToGrv();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
