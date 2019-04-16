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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
            //Không cho phóng to form
            this.MaximizeBox = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(txtChiSoCu.Text!=""&&txtChiSoMoi.Text!="")
            {
                int chisocu = 0, chisomoi = 0, chisotieuthu = 0;
                chisocu = int.Parse(txtChiSoCu.Text);
                chisomoi = int.Parse(txtChiSoMoi.Text);
                chisotieuthu = chisomoi - chisocu;
                if(chisotieuthu<0)
                {
                    MessageBox.Show("Chỉ số mới phải lớn hơn thằng ngu -.-", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    
                    float ttkhongthue = 0, ttthue = 0, thue = 0;
                    thue = float.Parse(txtThueGTGT.Text);
                    txtChiSoTieuThu.Text = chisotieuthu.ToString();
                    //Lấy tổng tiền
                    ttkhongthue = tongtien(chisotieuthu);
                    ttthue = ttkhongthue + (ttkhongthue * thue);
                    txtTongTien.Text = ttthue.ToString();
                }
            }

        }

        //Function tính tổng tiền chưa thuế.
        private float tongtien(int chisotieuthu)
        {
             int loai1 = 0, loai2 = 0, loai3 = 0, loai4 = 0;
            //TA QUY ƯỚC NHƯ SAU.
            // chỉ số tiêu thụ loại 1 = 10
            // loại 2 = 10
            // loại 3 = 20
            // loại 4 = còn lại 
            // VÍ DỤ. chỉ số tiêu thụ = 45 thì:
            // Loại 1 : 10
            // Loại 2 : 10
            // Loại 3 : 20
            // Loại 4 : 5
             //Nếu chỉ số tiêu thụ trong khoảng 0->10 tiêu thụ loại 1 = chỉ số tiêu thụ
             if (chisotieuthu > 0 && chisotieuthu <= 10)
             {
                 loai1 = chisotieuthu;
             }
            //Nếu chỉ số tiêu thụ nằm trong khoảng 10->20 tiêu tụ loại 1 = 10, loại 2 = chi số tiêu thụ trừ loại 1
             if (chisotieuthu > 10 && chisotieuthu <= 20)
             {
                 loai1 = 10;
                 loai2 = chisotieuthu - loai1;
             }
             //Nếu chỉ số tiêu thụ nằm trong khoảng 20->40 tiêu tụ loại 1 = 10, loại 2 = 10, loại 3 = chi số tiêu thụ trừ loại 1 - loại 2
             if (chisotieuthu > 20 && chisotieuthu <= 40)
             {
                 loai1 = 10;
                 loai2 = 10;
                 loai3 = chisotieuthu - loai1 - loai2;
             }
            // Nếu chỉ số tiêu thụ lớn hơn 40 tiêu thụ loại 1 = 10,  loại 2 = 10, loại 3 = 20, loại 4 còn lại
             if (chisotieuthu > 40)
             {
                 loai1 = 10;
                 loai2 = 10;
                 loai3 = 20;
                 loai4 = chisotieuthu - loai1 - loai2 - loai3;
             }
             float tongtien = loai1 * 5000 + loai2 * 7000 + loai3 * 9000 + loai4 * 10000;
            return tongtien;
        }
        //Function lấy thuế
        private float getthue(string mahd)
        {
            float thue = 0;
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_getthue";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@mahd", mahd);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                thue = reader.GetFloat(0);
                reader.Close();
            }

            return thue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dNgayLap.Format = DateTimePickerFormat.Custom;
            dNgayLap.CustomFormat = "MM/yyyy";
            dNgayLap.ShowUpDown = true;
            hienthihoadon();
        }
        private void hienthihoadon()
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_hoadon";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("action", "selectall");
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);

            foreach (DataRow row in dtb.Rows)
            {
                ListViewItem item = new ListViewItem(row["sMaHD"].ToString());
                item.SubItems.Add(row["sMaKH"].ToString());
                item.SubItems.Add(row["sMaNV"].ToString());
                item.SubItems.Add(row["dNgayLap"].ToString());
                item.SubItems.Add(row["dTuNgay"].ToString());
                item.SubItems.Add(row["dDenNgay"].ToString());
                item.SubItems.Add(row["fChiSoCu"].ToString());
                item.SubItems.Add(row["fChiSoMoi"].ToString());
                item.SubItems.Add(row["fThueGTGT"].ToString());
                item.SubItems.Add((bool)(row["bTrangThai"]) == true ? "Đang sử dụng" : "Không sử dụng");
                lvHoaDon.Items.Add(item);
            }

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
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
            MessageBox.Show("là: " + this.Name, "Thông báo");
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

        private void frmHoaDon_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_mahd";
            command.Connection = frmDangNhap.conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaHD.Text = reader.GetString(0);
                reader.Close();
            }
            string mahd = frmInformation.get_manv();
            txtMaNV.Text = mahd;
            txtMaKH.Clear();
            txtChiSoTieuThu.Clear();
            txtChiSoCu.Clear();
            txtChiSoMoi.Clear();
            txtTimKiem.Clear();
            txtTongTien.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtChiSoCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Vui lòng nhập số");
                }

        }

        private void txtChiSoMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void lvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvHoaDon.SelectedItems[0];
                txtMaHD.Text = lvi.SubItems[0].Text;
                txtMaKH.Text = lvi.SubItems[1].Text;
                txtMaNV.Text = lvi.SubItems[2].Text;
                txtChiSoCu.Text = lvi.SubItems[6].Text;
                txtChiSoMoi.Text = lvi.SubItems[7].Text;
                dNgayLap.Text = lvi.SubItems[5].Text;
             }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChiSoCu_TextChanged(object sender, EventArgs e)
        {
            if (txtChiSoCu.Text != "" && txtChiSoMoi.Text != "")
            {
                int chisocu = 0, chisomoi = 0, chisotieuthu = 0;
                chisocu = int.Parse(txtChiSoCu.Text);
                chisomoi = int.Parse(txtChiSoMoi.Text);
                chisotieuthu = chisomoi - chisocu;
                if (chisotieuthu < 0)
                {
                    MessageBox.Show("Chỉ số mới phải lớn hơn thằng ngu -.-", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    float ttkhongthue = 0, ttthue = 0, thue = 0;
                    thue = float.Parse(txtThueGTGT.Text);
                    txtChiSoTieuThu.Text = chisotieuthu.ToString();
                    //Lấy tổng tiền
                    ttkhongthue = tongtien(chisotieuthu);
                    ttthue = ttkhongthue + (ttkhongthue * thue);
                    txtTongTien.Text = ttthue.ToString();
                }
            }
        }

    }
}
