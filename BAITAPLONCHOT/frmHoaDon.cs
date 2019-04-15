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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            hoadon_ngaythang.Format = DateTimePickerFormat.Custom;
            hoadon_ngaythang.CustomFormat = "MM/yyyy";
            hoadon_ngaythang.ShowUpDown = true;
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
    }
}
