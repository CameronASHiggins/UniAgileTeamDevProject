﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        clsOrders AnOrder = new clsOrders();
        AnOrder.OrderId = Convert.ToInt32(txtOrderId.Text);
        Session["AnOrder"] = AnOrder;
        //Navigate to order viewer page
        Response.Redirect("OrdersViewer.aspx");
    }
}