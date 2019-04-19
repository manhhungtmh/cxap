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
    public partial class InNhanVienTheoMa : Form
    {
        //public InNhanVienTheoMa()
        //{
        //    InitializeComponent();
        //}
        string manv;
        public InNhanVienTheoMa(string ma)
        {
            InitializeComponent();
            manv = ma;
        }

        //private void InNhanVienTheoMa_Load(object sender, EventArgs e)
        //{
        //    hiendein();
        //}
        private void hiendein()
        {

            // MessageBox.Show(ma);
            ReportDocument rpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            rpt.Load(@"C:\Users\hungh\Desktop\fit\cxap\BAITAPLONCHOT\cr_InMotNhanVIen.rpt");
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
            rpt.SetParameterValue("@manv", manv);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void InNhanVienTheoMa_Load_1(object sender, EventArgs e)
        {
            hiendein();
        }
    }
}
