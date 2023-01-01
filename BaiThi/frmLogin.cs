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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (QLMayTinhEntities db = new QLMayTinhEntities())
            {
                string s = "select * from _User  where CONVERT (varchar(100), DECRYPTBYPASSPHRASE('bbb', password))='" +
                    txtPass.Text + "' and username = '" + txtUn.Text + "'";
                var list = db.C_User.SqlQuery(s).ToList();
                if (list.Count > 0)
                {
                    MessageBox.Show("Đăng Nhập Thành Công!", "Thong báo");
                    luu.KT = !luu.KT;
                    Close();
                }
                else
                {
                    MessageBox.Show("Username hoặc password không đúng", "Thông báo");
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
