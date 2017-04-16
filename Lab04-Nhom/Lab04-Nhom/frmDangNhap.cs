using DatabaseLib;
using Lab04_Nhom.CryptoExtension;
using Lab04_Nhom.DTO;
using System;
using System.Windows.Forms;
using Lab04_Nhom.Entity;

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
                MatKhau = passwordTextBox.Text.GetSHA1Hash()
            };

            var nv = DbLib.GetOne<NhanVien>("SP_GETBYUSERNAMEANDPASS_PUBLIC_ENCRYPT_NHANVIEN", login.ToSqlParameter());

            if (nv != null)
            {
                MessageBox.Show("Đăng nhập thành công nha !");
                var frmQLSV = new frmQuanLySV(nv, passwordTextBox.Text);
                this.Hide();
                frmQLSV.Show();
                return;
            }
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không thèm đúng !");
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
