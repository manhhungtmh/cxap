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
            this.MaximizeBox = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //float chisocu = float.Parse(txtChiSoCu.Text);
            //float chisomoi = float.Parse(txtChiSoMoi.Text);
            // //float check = chisomoi - chisocu;
            // if (chisomoi < chisocu)
            // {
            //     MessageBox.Show("ĐỊt mẹ mày");
            // }
            int chisocu = int.Parse(txtChiSoCu.Text);
            int chisomoi = int.Parse(txtChiSoMoi.Text);
            int check = chisomoi - chisocu;
            txtChiSoTieuThu.Text = check.ToString();

        }
        private float tongtien(int chisotieuthu)
        {
             int loai1, loai2, loai3, loai4;
            if (chisotieuthu >= 10)
            {
                loai1 = 10;
            }
            else{
                loai1 = chisotieuthu;
            }
            if (chisotieuthu >= 20)
            {
                loai2 = 10;
            }
            if (chisotieuthu >= 40)
            {
                loai3 = 20;
            }
            return 1;
            //if(chisotieuthu>=)
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
                //float tinhtien = float.Parse(txtChiSoTieuThu.Text);
             }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
