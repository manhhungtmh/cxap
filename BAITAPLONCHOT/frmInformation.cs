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
using System.Configuration;

namespace BAITAPLONCHOT
{
    public partial class frmInformation : Form
    {
        public frmInformation()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        
        private void frmInformation_Load(object sender, EventArgs e)
        {
            hienthiif();
        }
        private void hienthiif()
        {
            string manv = get_manv();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_nhanvien";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@action", "selectone");
            command.Parameters.Add("@manv", manv);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaNV.Text = manv;
                txtTenNV.Text = reader.GetString(1);
                //if (reader.GetString(4)=="Nam")
                if (reader.GetString(4) == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
                dNgaySinh.Value = reader.GetDateTime(2);
                txtDiaChi.Text = reader.GetString(3);
                txtSDT.Text = reader.GetString(5);
                txtChucVu.Text = reader.GetString(6);
                txtTenTaiKhoan.Text = reader.GetString(0);
                reader.Close();
            }
        }

        //Lấy mã nhân viên trong bảng tblss
        public static string get_manv()
        {
            frmDangNhap.check();
            string manv = "";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_getss";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                manv = reader.GetString(1);
                reader.Close();
            }

            return manv;
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmInformation_FormClosing(object sender, FormClosingEventArgs e)
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

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
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
                    frmNhanVien frm = new frmNhanVien();
                    if (OpenAForm(frm))
                    {
                        frm.Show();
                    }
                }
                //Nếu quyền == 0 thì thống báo k có quyền
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập vào chức năng này !");
                }
                reader.Close();
            }
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            if (OpenAForm(frm))
            {
                frm.Show();
            }
        }

        private void báocaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            if (OpenAForm(frm))
            {
                frm.Show();
            }
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            if (OpenAForm(frm))
            {
                frm.Show();
            }
        }

        private Boolean OpenAForm(Form form)
        {
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {

                    Form n = Application.OpenForms[i];
                    if (n.Name == form.Name)
                    {
                        n.BringToFront();
                        return false;
                    }
                }
            }
            catch
            {
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn chỉnh sửa thông tin cá nhân của mình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmDangNhap.check();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_nhanvien";
                command.Connection = frmDangNhap.conn;
                command.Parameters.Add("@action", "update");
                command.Parameters.Add("@manv", txtMaNV.Text);
                command.Parameters.Add("@tennv", txtTenNV.Text);
                command.Parameters.Add("@ngaysinh", dNgaySinh.Text);
                command.Parameters.Add("@diachi", txtDiaChi.Text);
                if (rdNam.Checked)
                {
                    command.Parameters.Add("@gioitinh", "Nam");
                }
                else
                {
                    command.Parameters.Add("@gioitinh", "Nữ");
                }
                command.Parameters.Add("@sdt", txtSDT.Text);
                command.Parameters.Add("@chucvu", txtChucVu.Text);
                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("Sửa thông tin thành công");
                }

                else
                {
                    MessageBox.Show("Sửa thông tin không thành công");
                }
                frmDangNhap.conn.Close();
                frmInformation_Load(sender, e);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matk = "";
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_getss";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                 matk = reader.GetString(3);
            }
            reader.Close();
            MessageBox.Show(matk);
        }
    }
}
