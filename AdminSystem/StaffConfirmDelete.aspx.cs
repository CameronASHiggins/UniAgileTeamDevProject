using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    Int32 StaffId;
    protected void Page_Load(object sender, EventArgs e)
    {
        StaffId = Convert.ToInt32(Session["StaffId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        clsStaffCollection StaffRegister = new clsStaffCollection();
        StaffRegister.ThisStaffMember.Find(StaffId);
        StaffRegister.Delete();
        Response.Redirect("StaffList.aspx");
    }
}