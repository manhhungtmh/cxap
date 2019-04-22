using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAPLONCHOT
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            hienthikhachhang();
        }
        private void hienthikhachhang()
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_khachhang";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("action", "selectall");
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);

            foreach (DataRow row in dtb.Rows)
            {
                ListViewItem item = new ListViewItem(row["sMaKH"].ToString());
                item.SubItems.Add(row["sTenKH"].ToString());
                item.SubItems.Add(row["dNgaySinh"].ToString());
                item.SubItems.Add(row["sDiaChi"].ToString());
                item.SubItems.Add(row["sGioiTinh"].ToString());
                item.SubItems.Add(row["sSDT"].ToString());
                item.SubItems.Add(row["sMaCongTo"].ToString());
                item.SubItems.Add((bool)(row["bTrangThai"]) == true ? "Đang sử dụng" : "Không sử dụng");
                lvKhachHang.Items.Add(item);
            }
        }


        private void thôngTinNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void frmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void quảnLýNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_khachhang";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@action", "insert");
            command.Parameters.Add("@tenkh", txtTenKH.Text);
            command.Parameters.Add("@ngaysinh", mtbNgaySinh.Text);
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
            command.Parameters.Add("@macongto", txtMaCongTo.Text);
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
            lvKhachHang.Items.Clear();
            frmKhachHang_Load(sender, e);
        }

        private void lvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            if (lvKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvKhachHang.SelectedItems[0];
                string makh = lvi.SubItems[0].Text;
                //hienthichitiet(makh);
                txtMaKH.Text = lvi.SubItems[0].Text;
                //lvi.SubItems[4].Text = "Nam" ? rdNam.Checked == true : rdNu.Checked == true;
                if (lvi.SubItems[4].Text == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
                mtbNgaySinh.Text = lvi.SubItems[2].Text;
                txtTenKH.Text = lvi.SubItems[1].Text;
                txtDiaChi.Text = lvi.SubItems[3].Text;
                txtSDT.Text = lvi.SubItems[5].Text;
                txtMaCongTo.Text = lvi.SubItems[6].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_mamoi";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaKH.Text = reader.GetString(0);
                reader.Close();
            }
            reader.Close();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            mtbNgaySinh.Clear();
            txtSDT.Clear();
            btnLuu.Enabled = true; 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text=="")
            {
                MessageBox.Show("Vui lòng chọn người muốn sửa");
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn sửa khách hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmDangNhap.check();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_khachhang";
                    command.Connection = frmDangNhap.conn;
                    command.Parameters.Add("@action", "update");
                    command.Parameters.Add("@makh", txtMaKH.Text);
                    command.Parameters.Add("@tenkh", txtTenKH.Text);
                    command.Parameters.Add("@ngaysinh", mtbNgaySinh.Text);
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
                    command.Parameters.Add("@macongto", txtMaCongTo.Text);
                    int ret = command.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                    }

                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                    frmDangNhap.conn.Close();
                    lvKhachHang.Items.Clear();
                    frmKhachHang_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn người muốn sửa");
            }
            else {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmDangNhap.check();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_khachhang";
                    command.Connection = frmDangNhap.conn;
                    command.Parameters.Add("@action", "lock");
                    command.Parameters.Add("@makh", txtMaKH.Text);


                    int ret = command.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        lvKhachHang.Items.Clear();
                        frmKhachHang_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "timkiemkhachhang";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@data", txtTimKiem.Text);
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);
            lvKhachHang.Items.Clear();
            foreach (DataRow row in dtb.Rows)
            {
                ListViewItem item = new ListViewItem(row["sMaKH"].ToString());
                item.SubItems.Add(row["sTenKH"].ToString());
                item.SubItems.Add(row["dNgaySinh"].ToString());
                item.SubItems.Add(row["sDiaChi"].ToString());
                item.SubItems.Add(row["sGioiTinh"].ToString());
                item.SubItems.Add(row["sSDT"].ToString());
                item.SubItems.Add(row["sMaCongTo"].ToString());
                item.SubItems.Add((bool)(row["bTrangThai"]) == true ? "Đang sử dụng" : "Không sử dụng");
                lvKhachHang.Items.Add(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvKhachHang.SelectedItems.Count > 0)
            {
                InKhachHangTheoMa iKH = new InKhachHangTheoMa(txtMaKH.Text);
                iKH.Show();
            }
            else
            {
                DanhSachKhachHang rptInKH = new DanhSachKhachHang();
                rptInKH.Show();
            } 
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất hỏi hệ không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenLoginForm));
                Application.Exit();
                t.Start();
            }
        }
        public static void OpenLoginForm()
        {
            Application.Run(new frmDangNhap()); //run your new form
        }
    }
}
