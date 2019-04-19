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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            hienthinv();
        }
        private void hienthinv()
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_nhanvien";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@action", "selectall");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string manv = reader.GetString(0);
                string tennv = reader.GetString(1);
                DateTime ngaysinh = reader.GetDateTime(2);
                string diachi = reader.GetString(3);
                string gioitinh = reader.GetString(4);
                string sdt = reader.GetString(5);
                string chucvu = reader.GetString(6);
                double hsl = reader.GetDouble(7);
                Boolean trangthai = reader.GetBoolean(8);
                ListViewItem lvi = new ListViewItem(manv + "");
                lvi.SubItems.Add(tennv);
                lvi.SubItems.Add(ngaysinh.ToString());
                lvi.SubItems.Add(diachi);
                lvi.SubItems.Add(gioitinh);
                lvi.SubItems.Add(sdt);
                lvi.SubItems.Add(chucvu);
                lvi.SubItems.Add(hsl + "");
                lvi.SubItems.Add(trangthai ? "Đang đi làm" : "Đã nghỉ");
                lvNhanVien.Items.Add(lvi);
            }
            reader.Close();
            cbChucVu.Items.Add("Quản lý");
            cbChucVu.Items.Add("Nhân viên");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void thongtinnhanvienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformation frm = new frmInformation();
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
                    reader.Close();
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

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvNhanVien.SelectedItems[0];
                string manv = lvi.SubItems[0].Text;
                txtMaNV.Text = lvi.SubItems[0].Text;
                txtTenNV.Text = lvi.SubItems[1].Text;
                dNgaySinh.Text = lvi.SubItems[2].Text;
                txtDiaChi.Text = lvi.SubItems[3].Text;
                if (lvi.SubItems[4].Text == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
                txtSDT.Text = lvi.SubItems[5].Text;
                if (lvi.SubItems[6].Text == "Quản Lý")
                {
                    cbChucVu.SelectedIndex = 0;
                }
                else
                {
                    cbChucVu.SelectedIndex = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_mamoinhanvien";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaNV.Text = reader.GetString(0);
            }
            reader.Close();
            txtDiaChi.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            dNgaySinh.Clear();
            cbChucVu.SelectedIndex = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "" || txtMaNV.Text == "" || txtSDT.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn sửa");
            }
            else
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
                if (cbChucVu.SelectedIndex == 0)
                {
                    command.Parameters.Add("@chucvu", "Quản Lý");
                    command.Parameters.Add("@hsl", Math.Round(float.Parse("1,2"), 1));
                }
                else
                {
                    command.Parameters.Add("@chucvu", "Nhân viên");
                    command.Parameters.Add("@hsl", Math.Round(float.Parse("0,9"), 1));
                }
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
                lvNhanVien.Items.Clear();
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "" || txtMaNV.Text == "" || txtSDT.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmDangNhap.check();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_nhanvien";
                    command.Connection = frmDangNhap.conn;
                    command.Parameters.Add("@action", "lock");
                    command.Parameters.Add("@manv", txtMaNV.Text);


                    int ret = command.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        lvNhanVien.Items.Clear();
                        frmNhanVien_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }

                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_nhanvien";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@action", "insert");
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
            if (cbChucVu.SelectedIndex == 0)
            {
                command.Parameters.Add("@chucvu", "Quản Lý");
                command.Parameters.Add("@hsl", Math.Round(float.Parse("1,2"), 1));
            }
            else
            {
                command.Parameters.Add("@chucvu", "Nhân viên");
                command.Parameters.Add("@hsl", Math.Round(float.Parse("0,9"),1));
            }
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thêm thành công");
            }

            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            frmDangNhap.conn.Close();
            lvNhanVien.Items.Clear();
            frmNhanVien_Load(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_timkiemnhanvien";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@data", txtTimKiem.Text);
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);
            lvNhanVien.Items.Clear();
            foreach (DataRow row in dtb.Rows)
            {
                ListViewItem item = new ListViewItem(row["sMaNV"].ToString());
                item.SubItems.Add(row["sTenNV"].ToString());
                item.SubItems.Add(row["dNgaySinh"].ToString());
                item.SubItems.Add(row["sDiaChi"].ToString());
                item.SubItems.Add(row["sGioiTinh"].ToString());
                item.SubItems.Add(row["sSDT"].ToString());
                item.SubItems.Add(row["sChucVu"].ToString());
                item.SubItems.Add(row["fHSL"].ToString());
                item.SubItems.Add((bool)(row["bTrangThai"]) == true ? "Đang đi làm" : "Đã nghỉ");
                lvNhanVien.Items.Add(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                InNhanVienTheoMa rptInNhanVien = new InNhanVienTheoMa(txtMaNV.Text);
                rptInNhanVien.Show();  
            }
            else
            {
                DanhSachNhanVien rptInNhanVien = new DanhSachNhanVien();
                rptInNhanVien.Show();
            } 
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất hỏi hệ không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Close();
            }
        }
    }
}
