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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            lock_unlock(luu.KT);
        }

        void lock_unlock(bool kt)
        {
            mnuLogin.Enabled = mnuThoat.Enabled = kt;
            mnuLogout.Enabled = mnuDM.Enabled = mnuHD.Enabled= mnuFind.Enabled = mnuBC.Enabled = mnuTG.Enabled =!kt;
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            lock_unlock(luu.KT);
        }

        private void mnuNV_Click(object sender, EventArgs e)
        {
            frmDMNhanVien f = new frmDMNhanVien();
            f.Show();
        }

        private void mnuKH_Click(object sender, EventArgs e)
        {
            frmDMKhachHang f = new frmDMKhachHang();
            f.Show();
        }

        private void mnuHH_Click(object sender, EventArgs e)
        {
            frmDMHangHoa f = new frmDMHangHoa();
            f.Show();
        }

        private void mnuloaihang_Click(object sender, EventArgs e)
        {
            frmLoaiHang f = new frmLoaiHang();
            f.Show();
        }

        private void mnuHoadonban_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.Show();
        }
    }
}
