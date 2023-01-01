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
    public partial class frmDMHangHoa : Form
    {
        HANG model = new HANG();
        public frmDMHangHoa()
        {
            InitializeComponent();
            loadDataToGrv();
            LoadDataToCbb();
        }

        void loadDataToGrv()
        {
            dgvHH.AutoGenerateColumns = false;
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                dgvHH.DataSource = luu.CreateDataTable<HANG>(db.HANGs.ToList<HANG>());

            }
        }

        void LoadDataToCbb()
        {
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                var list = db.LOAIHANGs.ToList();
                foreach(var item in list)
                {
                    cbbLH.Items.Add(item.Tenloaihang);
                }
            }
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                txtAnh.Text = dlgOpen.FileName;
                
            }
        }

        private void dgvHH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMHH.Focus();
                return;
            }
            txtMHH.Text = dgvHH.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenHH.Text = dgvHH.CurrentRow.Cells["Tenhang"].Value.ToString();
            txtSL.Text = dgvHH.CurrentRow.Cells["soluong"].Value.ToString();
            txtDGN.Text = dgvHH.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDGB.Text = dgvHH.CurrentRow.Cells["Dongiaban"].Value.ToString();
            txtAnh.Text = dgvHH.CurrentRow.Cells["Anh"].Value.ToString();
            txtGhichu.Text = dgvHH.CurrentRow.Cells["Ghichu"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            model.Mahang = txtMHH.Text;
            model.Tenhang = txtTenHH.Text;
            model.Soluong = Convert.ToInt32(txtSL.Text);
            model.Dongianhap = Convert.ToDouble(txtDGN.Text);
            model.Dongiaban = Convert.ToDouble(txtDGB.Text);
            model.Anh = txtAnh.Text;
            model.Ghichu = txtGhichu.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.HANGs.Add(model);
                db.SaveChanges();
                MessageBox.Show("Chèn Thành Công", "Thông báo");
                txtMHH.Text = "";
                txtTenHH.Text = "";
                txtSL.Text = "";
                txtDGN.Text = "";
                txtDGB.Text = "";
                txtAnh.Text = "";
                txtGhichu.Text = "";
                loadDataToGrv();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            model.Mahang = txtMHH.Text;
            model.Tenhang = txtTenHH.Text;
            model.Soluong = Convert.ToInt32(txtSL.Text);
            model.Dongianhap = Convert.ToDouble(txtDGN.Text);
            model.Dongiaban = Convert.ToDouble(txtDGB.Text);
            model.Anh = txtAnh.Text;
            model.Ghichu = txtGhichu.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Cập nhật Thành Công", "Thông báo");
                txtMHH.Text = "";
                txtTenHH.Text = "";
                txtSL.Text = "";
                txtDGN.Text = "";
                txtDGB.Text = "";
                txtAnh.Text = "";
                txtGhichu.Text = "";
                loadDataToGrv();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            model.Mahang = txtMHH.Text;
            model.Tenhang = txtTenHH.Text;
            model.Soluong = Convert.ToInt32(txtSL.Text);
            model.Dongianhap = Convert.ToDouble(txtDGN.Text);
            model.Dongiaban = Convert.ToDouble(txtDGB.Text);
            model.Anh = txtAnh.Text;
            model.Ghichu = txtGhichu.Text;


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa Thành Công", "Thông báo");
                txtMHH.Text = "";
                txtTenHH.Text = "";
                txtSL.Text = "";
                txtDGN.Text = "";
                txtDGB.Text = "";
                txtAnh.Text = "";
                txtGhichu.Text = "";
                loadDataToGrv();
            }
        }
    }
}
