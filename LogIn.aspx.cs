using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    DatabaseEntities db = new DatabaseEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        var data = db.tblUsers.Where(d => d.uEmail == txtEmail.Text && d.uPassword == txtPassword.Text).FirstOrDefault();

        if (data != null)
        {
            if (data.rId == 1)  //ekhane 1 means tblRole er rId.ekhane tblRole er rId=1 hole Admin page.tbleRole Table er Name ja thakbe
            {
                Session["un"] = data.uName;
                Session["role"] = data.tblRole.rName;

                Response.Redirect("/Admin/Default.aspx");
            }
            else if (data.rId == 2)  //ekhane 2 means tblRole er rId.ekhane tblRole er rId=2 hole General page.tbleRole Table er Name ja thakbe
            {
                Session["un"] = data.uName;
                Session["role"] = data.tblRole.rName;

                Response.Redirect("/General/Default.aspx");
            }
            else if (data.rId == 3)  //ekhane 3 means tblRole er rId.ekhane tblRole er rId=3 hole Admin page.tbleRole Table er Name ja thakbe
            {

            }
        }
        else
        {
            Literal1.Text = "Sorry!!!Invalid Email Adrress";
        }
    }
}