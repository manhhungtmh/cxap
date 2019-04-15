namespace BAITAPLONCHOT
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDon));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lvHoaDon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báocaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongtinnhanvienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.dNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChiSoMoi = new System.Windows.Forms.TextBox();
            this.txtThueGTGT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChiSoTieuThu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChiSoCu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(305, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ HÓA ĐƠN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm kiếm :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 36);
            this.panel1.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(86, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(164, 24);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lvHoaDon
            // 
            this.lvHoaDon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvHoaDon.FullRowSelect = true;
            this.lvHoaDon.GridLines = true;
            this.lvHoaDon.HideSelection = false;
            this.lvHoaDon.Location = new System.Drawing.Point(12, 310);
            this.lvHoaDon.Name = "lvHoaDon";
            this.lvHoaDon.Size = new System.Drawing.Size(883, 259);
            this.lvHoaDon.TabIndex = 4;
            this.lvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lvHoaDon.View = System.Windows.Forms.View.Details;
            this.lvHoaDon.SelectedIndexChanged += new System.EventHandler(this.lvHoaDon_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã HĐ";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã NV";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã KH";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày lập";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Từ ngày";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đến ngày";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 95;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Chỉ số cũ";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 95;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Chỉ số mới";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 95;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Location = new System.Drawing.Point(297, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 46);
            this.panel2.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Image = global::BAITAPLONCHOT.Properties.Resources.export;
            this.button5.Location = new System.Drawing.Point(453, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 39);
            this.button5.TabIndex = 11;
            this.button5.Text = "In danh sách";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Image = global::BAITAPLONCHOT.Properties.Resources.add_icon__2_;
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 39);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Image = global::BAITAPLONCHOT.Properties.Resources.Trash_can_icon1;
            this.btnXoa.Location = new System.Drawing.Point(338, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 39);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Image = global::BAITAPLONCHOT.Properties.Resources.Save_as_icon;
            this.btnLuu.Location = new System.Drawing.Point(113, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 39);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Image = global::BAITAPLONCHOT.Properties.Resources.Settings_5_icon___Copy;
            this.btnSua.Location = new System.Drawing.Point(228, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 39);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýHóaĐơnToolStripMenuItem,
            this.báocaoToolStripMenuItem,
            this.thongtinnhanvienToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(910, 48);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.Employees;
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(138, 44);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.Customer;
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(150, 44);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnToolStripMenuItem
            // 
            this.quảnLýHóaĐơnToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.quảnLýHóaĐơnToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.quảnLýHóaĐơnToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.Bill1;
            this.quảnLýHóaĐơnToolStripMenuItem.Name = "quảnLýHóaĐơnToolStripMenuItem";
            this.quảnLýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(130, 44);
            this.quảnLýHóaĐơnToolStripMenuItem.Text = "Quản lý hóa đơn";
            this.quảnLýHóaĐơnToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.quảnLýHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnToolStripMenuItem_Click);
            // 
            // báocaoToolStripMenuItem
            // 
            this.báocaoToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.Statistic1;
            this.báocaoToolStripMenuItem.Name = "báocaoToolStripMenuItem";
            this.báocaoToolStripMenuItem.Size = new System.Drawing.Size(137, 44);
            this.báocaoToolStripMenuItem.Text = "Báo cáo thống kê";
            this.báocaoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.báocaoToolStripMenuItem.Click += new System.EventHandler(this.báocaoToolStripMenuItem_Click);
            // 
            // thongtinnhanvienToolStripMenuItem
            // 
            this.thongtinnhanvienToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.user;
            this.thongtinnhanvienToolStripMenuItem.Name = "thongtinnhanvienToolStripMenuItem";
            this.thongtinnhanvienToolStripMenuItem.Size = new System.Drawing.Size(139, 44);
            this.thongtinnhanvienToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thongtinnhanvienToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.thongtinnhanvienToolStripMenuItem.Click += new System.EventHandler(this.thongtinnhanvienToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = global::BAITAPLONCHOT.Properties.Resources.logout;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(109, 44);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã hóa đơn :";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(142, 30);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(132, 24);
            this.txtMaHD.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã nhân viên lập :";
            // 
            // txtMaNV
            // 
            this.txtMaNV.BackColor = System.Drawing.SystemColors.Menu;
            this.txtMaNV.Location = new System.Drawing.Point(142, 67);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(132, 24);
            this.txtMaNV.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã khách hàng :";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(142, 105);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(132, 24);
            this.txtMaKH.TabIndex = 2;
            // 
            // dNgayLap
            // 
            this.dNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dNgayLap.Location = new System.Drawing.Point(730, 30);
            this.dNgayLap.Name = "dNgayLap";
            this.dNgayLap.Size = new System.Drawing.Size(132, 24);
            this.dNgayLap.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(636, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tháng :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Chỉ số mới :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(636, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Thuế GTGT :";
            // 
            // txtChiSoMoi
            // 
            this.txtChiSoMoi.Location = new System.Drawing.Point(450, 67);
            this.txtChiSoMoi.Name = "txtChiSoMoi";
            this.txtChiSoMoi.Size = new System.Drawing.Size(132, 24);
            this.txtChiSoMoi.TabIndex = 5;
            this.txtChiSoMoi.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.txtChiSoMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChiSoMoi_KeyPress);
            // 
            // txtThueGTGT
            // 
            this.txtThueGTGT.Location = new System.Drawing.Point(730, 67);
            this.txtThueGTGT.Name = "txtThueGTGT";
            this.txtThueGTGT.Size = new System.Drawing.Size(132, 24);
            this.txtThueGTGT.TabIndex = 6;
            this.txtThueGTGT.Text = "0.1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 18);
            this.label10.TabIndex = 14;
            this.label10.Text = "Chỉ số tiêu thụ :";
            // 
            // txtChiSoTieuThu
            // 
            this.txtChiSoTieuThu.Location = new System.Drawing.Point(450, 105);
            this.txtChiSoTieuThu.Name = "txtChiSoTieuThu";
            this.txtChiSoTieuThu.ReadOnly = true;
            this.txtChiSoTieuThu.Size = new System.Drawing.Size(132, 24);
            this.txtChiSoTieuThu.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(636, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 18);
            this.label11.TabIndex = 16;
            this.label11.Text = "Tổng tiền :";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(730, 105);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(132, 24);
            this.txtTongTien.TabIndex = 17;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Chỉ số cũ :";
            // 
            // txtChiSoCu
            // 
            this.txtChiSoCu.Location = new System.Drawing.Point(450, 30);
            this.txtChiSoCu.Name = "txtChiSoCu";
            this.txtChiSoCu.Size = new System.Drawing.Size(132, 24);
            this.txtChiSoCu.TabIndex = 21;
            this.txtChiSoCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChiSoCu_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChiSoCu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtChiSoTieuThu);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtThueGTGT);
            this.groupBox1.Controls.Add(this.txtChiSoMoi);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dNgayLap);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết hóa đơn";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(910, 581);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lvHoaDon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "d";
            this.MaximumSizeChanged += new System.EventHandler(this.frmHoaDon_MaximumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHoaDon_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHoaDon_FormClosed);
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ListView lvHoaDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báocaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongtinnhanvienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.DateTimePicker dNgayLap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChiSoMoi;
        private System.Windows.Forms.TextBox txtThueGTGT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChiSoTieuThu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChiSoCu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
    }
}