using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckOut : System.Web.UI.Page
{
    //Import   using System.Data; For DataTable

    DataTable dt = new DataTable();
    decimal total; //total is variable.eita GridView1_RowDataBound er jonno

    DatabaseEntities db = new DatabaseEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pk"] != null)    //Session means memory variable
        {
            dt = (DataTable)Session["pk"];

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            Response.Redirect("BuyProduct.aspx");   //for go to another page
        }
    }

    //GridView er event theke RowDeleting double click kore nicher code
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //GridView Design er moddhe Delete button er jonno CommandField theke Delete nite hobe
        dt.Rows.RemoveAt(e.RowIndex);   //Grid er jei row click korbo oitai RowIndex
        GridView1.DataBind();
        grandTotal();

        lblCount.Text = ((DataTable)Session["pk"]).Rows.Count.ToString();
    }

    protected void btnContinueShopping_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuyProduct.aspx"); //for go to another page
    }


    //Crate grandTotal Method
    public decimal grandTotal()
    {
        decimal total = 0;  // decimal total = 0; eita just dhore neya hoyeche

        //Loop
        //GridView1.Rows means GridView1 er sob gulo Row
        //je koita Row ase sob GridViewRow r er moddhe rakhbe
        //  r means akta Row bujhai
        //je koita Row thakbe tar prothom Row r er moddhe rakhbe
        //then 2nd Row,3rd Row ................

        foreach (GridViewRow r in GridView1.Rows)
        {
            total += decimal.Parse(r.Cells[4].Text);
            //decimal.Parse(r.Cells[4].Text); means GridView er Row(1st,2nd,3rd.....je koita Row thakbe) er 4 number Cells/Column er Text decimal convert kore total er moddhe rakhbe
            //je koita Row totobar ee erokomvabe Loop hobe
        }
        return total; //total return korbe
    }
    protected void btnEndShopping_Click(object sender, EventArgs e)
    {
        Customer cus = new Customer();

        cus.CName = txtCustomerName.Text;
        cus.Email = txtEmail.Text;
        cus.Address = txtAddress.Text;
        cus.Phone = txtPhoneNumber.Text;
        if (txtEnroll.Text != "")
        {
            cus.DOE = DateTime.Parse(txtEnroll.Text);
        }

        db.Customers.Add(cus);
        db.SaveChanges();


        Order o = new Order();
        o.OrderDate = DateTime.Now;
        o.GrandTotal = grandTotal();

        db.Orders.Add(o);
        db.SaveChanges();

        foreach (GridViewRow r in GridView1.Rows)
        {
            OrderDetail oD = new OrderDetail();

            oD.Id = o.Id;
            oD.PId = Int32.Parse(r.Cells[1].Text);
            oD.SalesQTY = Int32.Parse(r.Cells[3].Text);
            oD.SalesPrice = decimal.Parse(r.Cells[4].Text);

            // oD.SaleTotal = decimal.Parse(r.Cells[5].Text);

            db.OrderDetails.Add(oD);
            db.SaveChanges();

        }
        dt.Clear();   //for DataTable clear
        GridView1.DataBind();

        Literal1.Text = "Order Placed";

        SendMail();
    }

    //jodi kono code k method er moddhe nite chai tahole code select kore right mouse Quick Actions and Refactorings click,then Extract Method click,NewMethod name er poriborte method er name,then Apply click
    //create SendMail Method
    private void SendMail()         //DataType void means true/false check kora
    {
        //Admin display name
        //round-27 password
        //Sending Email

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(txtEmail.Text);
        mail.From = new System.Net.Mail.MailAddress("diitidb@gmail.com", "Admin", System.Text.Encoding.UTF8);    //ekhane Admin display name
        mail.Subject = "Thank You For Purchase !!!";   //Subject jekonokicui hote pare. 

        //body can edit or design
        string body = "";
        body += "</br>";
        body += "</br>";
        body += "</br>";
        body += "</br>";
        body += "</br>";
        body += "</br>";
        body += "</br>";
        body += "Best Regards";
        body += "Manager, AAAA";

        //mail.Body = "Hello,";
        mail.Body = body;
        mail.IsBodyHtml = true;

        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("diitidb@gmail.com", "round-27");

        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;


        //this code for send
        try
        {
            client.Send(mail);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent');", true);
        }
        catch (Exception ex)
        {
            Literal1.Text = ex.Message;
        }
    }

    //GridView er event theke RowDataBound double click kore nicher code
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            total = 0;  //0 means ekhane Header value 0
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += decimal.Parse(e.Row.Cells[5].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Total Amount"; //ekhane Cells[4] means 4 number Cells Total Amount likha dekhabe
            e.Row.Cells[5].Text = total.ToString(); //ekhane 5 number Cells Total Amount dekhabe

            //GridView er propertises theke ShowFooter,ShowHeaderWhenEmpty true kore dite hobe

        }
    }

    protected void btnOrderHere_Click(object sender, EventArgs e)
    {
        SendMail();
    }
}