﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class application : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Application.Lock();
        Application["a"] = (int)Application["a"] + 1;
        Application.UnLock();

        Response.Write(Application["a"]);

        Response.Write("<br>" + Session["name"]);
    }
}