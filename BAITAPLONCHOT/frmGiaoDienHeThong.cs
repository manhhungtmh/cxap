using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BAITAPLONCHOT
{
    public partial class frmGiaoDienHeThong : Form
    {
        public frmGiaoDienHeThong()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
            this.Close();
        }
         
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_getss";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //Nếu quyền == 1 thì cho vào xem
                if (reader.GetBoolean(2))
                {
                    reader.Close();
                    frmNhanVien frm = new frmNhanVien();
                    frm.Show();
                    this.Close();
                }
                //Nếu quyền == 0 thì thống báo k có quyền
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập vào chức năng này !");
                }
                
            }
            reader.Close();
        }

        private void frmGiaoDienHeThong_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất hỏi hệ không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.Show();
            this.Close();
        }

        private void frmGiaoDienHeThong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                if (MessageBox.Show("Bạn có muốn thoát không?",
                               "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Hide();
                    Environment.Exit(1);
                }
                else
                    e.Cancel = true;
            }
        }

        private void frmGiaoDienHeThong_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmInformation frm = new frmInformation();
            frm.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmInformation frm = new frmInformation();
            frm.Show();
            this.Close();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_getss";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //Nếu quyền == 1 thì cho vào xem
                if (reader.GetBoolean(2))
                {
                    reader.Close();
                    frmNhanVien frm = new frmNhanVien();
                    frm.Show();
                    this.Close();
                }
                //Nếu quyền == 0 thì thống báo k có quyền
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập vào chức năng này !");
                    reader.Close();
                }
                reader.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.Show();
            this.Close();
        }
    }
}
