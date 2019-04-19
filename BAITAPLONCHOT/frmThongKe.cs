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
    public partial class frmThongKe : Form
    {
        public DataTable dtb_hd;

        public frmThongKe()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void frmThongKe_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmThongKe_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            hienthithongkenhanvien();
            thongkehoadon();
        }
        private void hienthithongkenhanvien()
        {
            int soluongnhanvien = 0;
            int nhanviendanglam = 0;
            
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "thongkenhanvien";
            command.Connection = frmDangNhap.conn;
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);
            lvThongKeNhanVien.Items.Clear();
            foreach (DataRow row in dtb.Rows)
            {
                
                soluongnhanvien = soluongnhanvien + 1;
                ListViewItem item = new ListViewItem(row["sMaNV"].ToString());
                item.SubItems.Add(row["sTenNV"].ToString());
                item.SubItems.Add(row["dNgaySinh"].ToString());
                item.SubItems.Add(row["sDiaChi"].ToString());
                item.SubItems.Add(row["sGioiTinh"].ToString());
                item.SubItems.Add(row["sSDT"].ToString());
                item.SubItems.Add(row["sChucVu"].ToString());
                item.SubItems.Add(row["SoLuongHoaDon"].ToString());
                item.SubItems.Add((bool)(row["bTrangThai"]) == true ? "Đang đi làm" : "Đã nghỉ");
                if((bool)row["bTrangThai"] == true){
                    nhanviendanglam = nhanviendanglam + 1;
                }
                lvThongKeNhanVien.Items.Add(item);
            }
            SoLuongNhanVien.Text = soluongnhanvien.ToString();
            DangDiLam.Text = nhanviendanglam.ToString();
        }
        private void thongkehoadon()
        {
            dTuNgay.CustomFormat = "dd-MM-yyyy";
            dDenNgay.CustomFormat = "dd-MM-yyyy";
            //MessageBox.Show(dTuNgay.Text.ToString());
            rdTatCaThanhTien.Checked = true;
            rdTatCaThoiGian.Checked = true;
            dTuNgay.Enabled = false;
            dDenNgay.Enabled = false;
            txtTuTien.Enabled = false;
            txtDenTien.Enabled = false;
            int chisotieuthu = 0;
            int soluonghoadon = 0;
            int tongsoluongtieuthu = 0;
            int tongnuochoadon = 0;
            float tonggiatrihoadon = 0;
            float trungbinhgiatrihoadon = 0;
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_hoadon";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("action", "thongke");
            dtb_hd = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb_hd);

            foreach (DataRow row in dtb_hd.Rows)
            {
                soluonghoadon++;
                ListViewItem item = new ListViewItem(row["sMaHD"].ToString());
                item.SubItems.Add(row["sTenNV"].ToString());
                item.SubItems.Add(row["sTenKH"].ToString());
                item.SubItems.Add(row["dNgayLap"].ToString());
                item.SubItems.Add(row["dTuNgay"].ToString());
                item.SubItems.Add(row["dDenNgay"].ToString());
                item.SubItems.Add(row["fChiSoCu"].ToString());
                item.SubItems.Add(row["fChiSoMoi"].ToString());
                tongsoluongtieuthu = tongsoluongtieuthu + (Convert.ToInt32(row["fChiSoMoi"]));
                chisotieuthu = (Convert.ToInt32(row["fChiSoMoi"])) - (Convert.ToInt32(row["fChiSoCu"]));
                tongnuochoadon = tongnuochoadon + chisotieuthu;
                item.SubItems.Add(chisotieuthu.ToString());
                item.SubItems.Add(row["fThueGTGT"].ToString());
                item.SubItems.Add(row["fTongTien"].ToString());
                tonggiatrihoadon = tonggiatrihoadon + (Convert.ToInt32(row["fTongTien"]));
                lvThongKeHoaDon.Items.Add(item);
            }
            float trungbinhnuochoadon = (float)(tongnuochoadon / soluonghoadon);
            trungbinhgiatrihoadon = (float)(tonggiatrihoadon/soluonghoadon);
            SoLuongHoaDon.Text = soluonghoadon.ToString();
            TongSoNuocTieuThu.Text = tongsoluongtieuthu.ToString();
            TrungBinhNuocHoaDon.Text = trungbinhnuochoadon.ToString();
            TongGiaTriHoaDon.Text = tonggiatrihoadon.ToString();
            TrungBinhGiaTriHoaDon.Text = trungbinhgiatrihoadon.ToString();
            frmDangNhap.conn.Close();
            
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

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void listView3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void Bink(object sender, System.EventArgs e)
        {
            CheckBox test = sender as CheckBox;

            for (int i = 0; i < lvThongKeHoaDon.Items.Count; i++)
            {
                lvThongKeHoaDon.Items[i].Checked = test.Checked;
            }
        }

        private void listView3_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lvThongKeHoaDon.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lvThongKeHoaDon.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lvThongKeHoaDon.Items)
                    item.Checked = !value;

                this.lvThongKeHoaDon.Invalidate();
            }
        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void lvThongKeNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Lọc bên Nhân viên
        private string loccheckbox()
        {
            string query = "";
            if (cbNam.Checked == true && cbNu.Checked == true)
            {
                if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == true)
                {
                    query = "1 = 1";
                }
            }
            if (cbNam.Checked == true && cbNu.Checked == false)
            {
                if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == false)
                {
                    query = "sGioiTinh = N'Nam' and bTrangThai = 0";
                }
                if (cbDaNghiViec.Checked == false && cbDangLamViec.Checked == true)
                {
                    query = "sGioiTinh = N'Nam' and bTrangThai = 1";
                }
                if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == true)
                {
                    query = "sGioiTinh = N'Nam'";
                }
                if (cbDaNghiViec.Checked == false && cbDangLamViec.Checked == false)
                {

                }

            }
            if (cbNam.Checked == false && cbNu.Checked == true)
            {
                if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == false)
                {
                    query = "sGioiTinh = N'Nữ' and bTrangThai = 0";
                }
                if (cbDaNghiViec.Checked == false && cbDangLamViec.Checked == true)
                {
                    query = "sGioiTinh = N'Nữ' and bTrangThai = 1";
                }
                if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == true)
                {
                    query = "sGioiTinh = N'Nữ'";
                }
                if (cbDaNghiViec.Checked == false && cbDangLamViec.Checked == false)
                {

                }
            }
            if (cbDaNghiViec.Checked == true && cbDangLamViec.Checked == false)
            {
                if (cbNam.Checked == true && cbNu.Checked == false)
                {
                    query = "sGioiTinh = N'Nam' and bTrangThai = 0";
                }
                if (cbNam.Checked == false && cbNu.Checked == true)
                {
                    query = "sGioiTinh = N'Nữ' and bTrangThai = 0";
                }
                if (cbNam.Checked == true && cbNu.Checked == true)
                {
                    query = "bTrangThai = 0";
                }
                if (cbNam.Checked == false && cbNu.Checked == false)
                {

                }
            }
            if (cbDaNghiViec.Checked == false && cbDangLamViec.Checked == true)
            {
                if (cbNam.Checked == true && cbNu.Checked == false)
                {
                    query = "sGioiTinh = N'Nam' and bTrangThai = 1";
                }
                if (cbNam.Checked == false && cbNu.Checked == true)
                {
                    query = "sGioiTinh = N'Nữ' and bTrangThai = 1";
                }
                if (cbNam.Checked == true && cbNu.Checked == true)
                {
                    query = "bTrangThai = 1";
                }
                if (cbNam.Checked == false && cbNu.Checked == false)
                {

                }
            }
            return query;
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
            string truyvan = loccheckbox();
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_locnhanvien";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@action", truyvan);
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);
            lvThongKeNhanVien.Items.Clear();
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
                lvThongKeNhanVien.Items.Add(item);
            }
            }
            catch (Exception x)
            {
                MessageBox.Show("Vui lòng chọn đúng điều liện lọc");
            }
        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            frmDangNhap.check();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_timkiemthongkehoadon";
            command.Connection = frmDangNhap.conn;
            command.Parameters.Add("@data", txtTimKiemHD.Text);
            int chisotieuthu = 0;
            int soluonghoadon = 0;
            int tongsoluongtieuthu = 0;
            int tongnuochoadon = 0;
            float tonggiatrihoadon = 0;
            float trungbinhgiatrihoadon = 0;
            DataTable dtb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dtb);
            lvThongKeHoaDon.Items.Clear();
            foreach (DataRow row in dtb.Rows)
            {
                soluonghoadon++;
                ListViewItem item = new ListViewItem(row["sMaHD"].ToString());
                item.SubItems.Add(row["sTenNV"].ToString());
                item.SubItems.Add(row["sTenKH"].ToString());
                item.SubItems.Add(row["dNgayLap"].ToString());
                item.SubItems.Add(row["dTuNgay"].ToString());
                item.SubItems.Add(row["dDenNgay"].ToString());
                item.SubItems.Add(row["fChiSoCu"].ToString());
                item.SubItems.Add(row["fChiSoMoi"].ToString());
                tongsoluongtieuthu = tongsoluongtieuthu + (Convert.ToInt32(row["fChiSoMoi"]));
                chisotieuthu = (Convert.ToInt32(row["fChiSoMoi"])) - (Convert.ToInt32(row["fChiSoCu"]));
                tongnuochoadon = tongnuochoadon + chisotieuthu;
                item.SubItems.Add(chisotieuthu.ToString());
                item.SubItems.Add(row["fThueGTGT"].ToString());
                item.SubItems.Add(row["fTongTien"].ToString());
                tonggiatrihoadon = tonggiatrihoadon + (Convert.ToInt32(row["fTongTien"]));
                lvThongKeHoaDon.Items.Add(item);
            }
            float trungbinhnuochoadon = 0 ;
            try {
                trungbinhnuochoadon = (float)(tongnuochoadon / soluonghoadon);
                trungbinhgiatrihoadon = (float)(tonggiatrihoadon / soluonghoadon);
            }
            catch(Exception y) {
                
            }
            SoLuongHoaDon.Text = soluonghoadon.ToString();
            TongSoNuocTieuThu.Text = tongsoluongtieuthu.ToString();
            TrungBinhNuocHoaDon.Text = trungbinhnuochoadon.ToString();
            TongGiaTriHoaDon.Text = tonggiatrihoadon.ToString();
            TrungBinhGiaTriHoaDon.Text = trungbinhgiatrihoadon.ToString();
            frmDangNhap.conn.Close();
        }

        private void rdTuyChinhThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dTuNgay.Enabled = true;
            dDenNgay.Enabled = true;
        }

        private void rdTuyChinhThanhTien_CheckedChanged(object sender, EventArgs e)
        {
            txtTuTien.Enabled = true;
            txtDenTien.Enabled = true;
        }

        private void rdTatCaThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dTuNgay.Enabled = false;
            dDenNgay.Enabled = false;
        }

        private void rdTatCaThanhTien_CheckedChanged(object sender, EventArgs e)
        {
            txtTuTien.Enabled = false;
            txtDenTien.Enabled = false;
        }

        private void btnLocHoaDon_Click(object sender, EventArgs e)
        {

            int chisotieuthu = 0;
            int soluonghoadon = 0;
            int tongsoluongtieuthu = 0;
            int tongnuochoadon = 0;
            float tonggiatrihoadon = 0;
            float trungbinhgiatrihoadon = 0;
            DateTime tungay;
            DateTime denngay;
            float tutien;
            float dentien;
            try
            {
                 tungay = DateTime.ParseExact(dTuNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                 denngay = DateTime.ParseExact(dDenNgay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                 tutien = float.Parse(txtTuTien.Text);
                 dentien = float.Parse(txtDenTien.Text);
                lvThongKeHoaDon.Items.Clear();
            
            foreach (DataRow row in dtb_hd.Rows)
            {
                soluonghoadon++;
                    ListViewItem item = new ListViewItem(row["sMaHD"].ToString());
                    item.SubItems.Add(row["sTenNV"].ToString());
                    item.SubItems.Add(row["sTenKH"].ToString());
                    DateTime date = DateTime.Parse(row["dNgayLap"].ToString());
                    item.SubItems.Add(date.ToString("dd/MM/yyyy hh:ss"));
                    item.SubItems.Add(row["dTuNgay"].ToString());
                    item.SubItems.Add(row["dDenNgay"].ToString());
                    item.SubItems.Add(row["fChiSoCu"].ToString());
                    item.SubItems.Add(row["fChiSoMoi"].ToString());
                tongsoluongtieuthu = tongsoluongtieuthu + (Convert.ToInt32(row["fChiSoMoi"]));
                chisotieuthu = (Convert.ToInt32(row["fChiSoMoi"])) - (Convert.ToInt32(row["fChiSoCu"]));
                tongnuochoadon = tongnuochoadon + chisotieuthu;
                item.SubItems.Add(chisotieuthu.ToString());
                item.SubItems.Add(row["fThueGTGT"].ToString());
                float tongtien = Convert.ToInt32(row["fTongTien"]);
                item.SubItems.Add(row["fTongTien"].ToString());
                tonggiatrihoadon = tonggiatrihoadon + (Convert.ToInt32(row["fTongTien"]));
                int value = DateTime.Compare(date, tungay);
                int value1 = DateTime.Compare(date, denngay);
                if (rdTatCaThoiGian.Checked == true && rdTatCaThanhTien.Checked == true)
                {
                    lvThongKeHoaDon.Items.Add(item);
                }
                if (rdTatCaThoiGian.Checked == false && rdTatCaThanhTien.Checked == false)
                {
                    if (value > 0 && value1 < 0 && tutien < tongtien && dentien > tongtien)
                    {
                        lvThongKeHoaDon.Items.Add(item);
                    }
                }
                if (rdTuyChinhThoiGian.Checked == true && rdTatCaThanhTien.Checked == true)
                {
                    if (value > 0 && value1 < 0)
                    {
                        lvThongKeHoaDon.Items.Add(item);
                    }
                }
                if (rdTatCaThoiGian.Checked == true && rdTuyChinhThanhTien.Checked == true)
                {
                    if (tutien < tongtien && dentien > tongtien)
                    {
                        lvThongKeHoaDon.Items.Add(item);
                    }
                }
                
                float trungbinhnuochoadon = (float)(tongnuochoadon / soluonghoadon);
                trungbinhgiatrihoadon = (float)(tonggiatrihoadon / soluonghoadon);
                SoLuongHoaDon.Text = soluonghoadon.ToString();
                TongSoNuocTieuThu.Text = tongsoluongtieuthu.ToString();
                TrungBinhNuocHoaDon.Text = trungbinhnuochoadon.ToString();
                TongGiaTriHoaDon.Text = tonggiatrihoadon.ToString();
                TrungBinhGiaTriHoaDon.Text = trungbinhgiatrihoadon.ToString();
                frmDangNhap.conn.Close();
            }
            }
            catch (Exception z)
            {

            }
        }

        private void dTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất hỏi hệ không ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Close();
            }
        }
    }
}