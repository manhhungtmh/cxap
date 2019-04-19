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
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;


namespace BAITAPLONCHOT
{
    public partial class InKhachHangTheoMa : Form
    {
        public InKhachHangTheoMa()
        {
            InitializeComponent();
        }
        string makh;
        public InKhachHangTheoMa(string ma)
        {
            InitializeComponent();
            makh = ma;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            hiendein();
        }
        private void hiendein()
        {

            // MessageBox.Show(ma);
            ReportDocument rpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            rpt.Load(@"C:\Users\hungh\Desktop\fit\cxap\BAITAPLONCHOT\cr_InMotKhachHang.rpt");
            Tables CrTables;
            CrTables = rpt.Database.Tables;
            crConnectionInfo.IntegratedSecurity = true;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            crystalReportViewer1.Refresh();
            rpt.SetParameterValue("@makh", makh);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
