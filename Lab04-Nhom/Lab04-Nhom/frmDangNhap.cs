using DatabaseLib;
using Lab04_Nhom.CryptoExtension;
using Lab04_Nhom.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_Nhom.CryptoExtension;
namespace Lab04_Nhom
{
    public partial class frmDangNhap : Form
    {
        SqlDatabase DbLib;
        public frmDangNhap()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginDTO login = new LoginDTO
            {
                TenDN = usernameTextBox.Text,
                MatKhau = passwordTextBox.Text.GetMd5Hash()
            };

            var nvDt = DbLib.GetDataTable("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN", login.ToSqlParameter());

            if (nvDt.Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công nha !");
                return;
            }

            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không thèm đúng !");
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
