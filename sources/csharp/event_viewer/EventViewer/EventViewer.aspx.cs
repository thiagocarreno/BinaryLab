using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;

namespace EventViewer
{
    public partial class EventViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPage();
            }
        }

        private void LoadPage()
        {
            var log = new EventLog();

            log.Log = "System";
            log.MachineName = ".";

            DataTable objDt = new DataTable();
            objDt.Columns.Add("EntryType", typeof(string));
            objDt.Columns.Add("TimeGenerated", typeof(string));
            objDt.Columns.Add("Source", typeof(string));
            objDt.Columns.Add("EventID", typeof(string));
            objDt.Columns.Add("Message", typeof(string));
            objDt.Columns.Add("Category", typeof(string));

            for (int i = 0; i < log.Entries.Count; i++)
            {
                DataRow dr = objDt.NewRow();
                dr["EntryType"] = log.Entries[i].EntryType.ToString();
                dr["TimeGenerated"] = log.Entries[i].TimeGenerated.ToString();
                dr["Source"] = log.Entries[i].Source.ToString();
                dr["EventID"] = log.Entries[i].EventID.ToString();
                dr["Message"] = log.Entries[i].Message.ToString();
                dr["Category"] = log.Entries[i].ToString();
                objDt.Rows.Add(dr);
            }

            GrdVw_SystemLog.DataSource = objDt;
            GrdVw_SystemLog.DataBind();
        }
    }
}