using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BaiThi.Class;



namespace BaiThi
{
    public partial class frmHoaDon : Form
    {
        
       CHITIETHOADON model = new CHITIETHOADON();

        public frmHoaDon()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadDataToCbbNV();
            LoadDataToCbbKH();
            LoadDataToCbbHH();
        }

        private void LoadDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;

            string sql;
            sql = "SELECT a.Mahang, b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia,a.Thanhtien FROM CHITIETHOADON AS a, HANG AS b WHERE a.MaHD = N'" + txtMHD.Text + "' AND a.Mahang=b.Mahang";

            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                dgvHoaDon.DataSource = luu.CreateDataTable<CHITIETHOADON>(db.CHITIETHOADONs.ToList<CHITIETHOADON>());

            }

           
            //tblCTHDB = Functions.GetDataToTable(sql);
           

            
        }

        void LoadDataToCbbNV()
        {
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                var list = db.NHANVIENs.ToList();
                foreach (var item in list)
                {
                    cbbMNV.Items.Add(item.Tennhanvien);
                }
            }
        }

        void LoadDataToCbbKH()
        {
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                var list = db.KHACHANGs.ToList();
                foreach (var item in list)
                {
                    cbbMK.Items.Add(item.Tenkhach);
                }
            }
        }

        void LoadDataToCbbHH()
        {
            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                var list = db.HANGs.ToList();
                foreach (var item in list)
                {
                    cbbMaHang.Items.Add(item.Tenhang);
                }
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            model.MaHD = txtMHD.Text;
            model.Mahang = cbbMaHang.Text;
            model.Soluong =Convert.ToInt32(txtSoluong.Text);
            model.Dongia =Convert.ToDouble(txtDonGia.Text);
            model.Giamgia = Convert.ToInt32(txtGG.Text);
            model.Thanhtien = Convert.ToDouble(txtThanhTien.Text);
            


            using (QLMayTinhEntities1 db = new QLMayTinhEntities1())
            {
                db.CHITIETHOADONs.Add(model);
                db.SaveChanges();
                MessageBox.Show("Chèn Thành Công", "Thông báo");
                txtMHD.Text = "";
                txtSoluong.Text = "";
                txtDonGia.Text = "";
                txtGG.Text = "";
                LoadDataGridView();
            }

        }

        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            if (btnThemHD.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMHD.Focus();
                return;
            }
            cbbMaHang.Text = dgvHoaDon.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenHang.Text = dgvHoaDon.CurrentRow.Cells["Tenhang"].Value.ToString();
            txtSoluong.Text = dgvHoaDon.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGG.Text = dgvHoaDon.CurrentRow.Cells["Giamgia"].Value.ToString();
            txtDonGia.Text = dgvHoaDon.CurrentRow.Cells["Dongia"].Value.ToString();
            txtGG.Text = dgvHoaDon.CurrentRow.Cells["Giamgia"].Value.ToString();
            txtThanhTien.Text = dgvHoaDon.CurrentRow.Cells["Thanhtien"].Value.ToString();
            btnLuuHoaDon.Enabled = true;
            btnHuyHD.Enabled = true;
            btnInHD.Enabled = true;
        }



        // Nap info hoa don

    }
   }

