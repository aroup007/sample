using System;
using System.Collections.Generic;
using System.Data;    
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class BuyProduct : System.Web.UI.Page
{
    //Import   using System.Data; For DataTable

    DataTable dt = new DataTable();
    decimal total;  //total is variable.eita GridView1_RowDataBound er jonno

    DatabaseEntities db = new DatabaseEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //jodi IsPostBack na kore tahole nicher kaj korbe.mane DataTable banabe

            if (Session["pk"] == null) //session jodi null hoi ei kaj korbe.null na hole eita kaj korbe na
            {
                //session jodi null hoi nicher kaj korbe.mane DataTable banabe

                dt = new DataTable();
                dt.Columns.Add(new DataColumn("Product Id"));
                dt.Columns.Add(new DataColumn("Product Name"));
                dt.Columns.Add(new DataColumn("Product Quantity"));
                dt.Columns.Add(new DataColumn("Sales Price"));
                dt.Columns.Add(new DataColumn("Total Price"));

                Session["pk"] = dt;  //pk means variable

            }

            DataList1.DataSource = db.Products.ToList();
            DataList1.DataBind();

            GridView1.DataSource = (DataTable)Session["pk"];
            GridView1.DataBind();

        }
        else
        {
            //session jodi Not null hoi nicher kaj korbe

            dt = (DataTable)Session["pk"];  // (DataTable)Session["pk"] dt er moddhe rakhbe
        }
        GridView1.DataSource = (DataTable)Session["pk"];
        GridView1.DataBind();

    }

    //DataList er event theke ItemCommand double click kore nicher code
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "B")
        {
            //string variable = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("source er vitore jei Id thakbe")).Text;

            string pId = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("IdLabel")).Text;
            Session["ProductID"] = pId;
            string ProductName = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("ProductNameLabel")).Text;
            Session["ProductName"] = ProductName;
            string Quantity = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("QuantityLabel")).Text;
            Session["Quantity"] = Quantity;
            string Price = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("PriceLabel")).Text;
            Session["Price"] = Price;
            string ProductImage = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("ProductImageLabel")).Text;
            Session["ProductImage"] = ProductImage;
            string CategoryID = ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("CategoryIdLabel")).Text;
            Session["CategoryID"] = CategoryID;


            // SalesQTY fixed 1 dhora hoyeche.jate prottekbar 1 kore Quantity barbo.

            int SalesQTY = 1;

            if (!AddQuantity(pId, SalesQTY)) //pId,SalesQTY pass hoye AddQuantity method chole jabe
            {
                //jodi AddQuantity method pId,SalesQTY na pawaa jai tahole return false kore ekhane asbe
                //na pawa gele DataTable er NewRow banabe

                DataRow dR = dt.NewRow();
                dR[0] = pId;    //pId means variable.it means object
                dR[1] = ProductName;
                dR[2] = SalesQTY;  // ekhane SalesQTY is a variable.(SalesQTY=Quantity)same
                dR[3] = Price;
                dR[4] = Convert.ToInt32(dR[2]) * Convert.ToDecimal(dR[3]);  //dR[4] = Convert.ToInt32(dR[2].ToString()) *Convert.ToDecimal(dR[3].ToString()); Same


                dt.Rows.Add(dR);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }


    //Create AddQuantity Method
    private bool AddQuantity(string idnum, int qty)
    {
        //Loop
        //dt.Rows means DataTable er sob gulo Row
        //je koita Row ase sob DataRow item er moddhe rakhbe
        //item means akta Row bujhai
        //je koita Row thakbe tar prothom Row item er moddhe rakhbe
        //then 2nd Row,3rd Row ................

        foreach (DataRow item in dt.Rows)  //ekhane var=DataRow,collection=dt.Rows
        {
            //Product Id,Product Name,.........eigula Column.sequence of column number 0,1,2,3,.......
            //item[0] means "Product Id"
            //item[1] means "Product Name"
            //item[2] means "Product Quantity"
            //item[3] means "Sales Price"
            //item[4] means "Total Price"

            if (item[0].ToString() == idnum) //string idnum
            {
                //Variable TQty
                //int TQty = 1ta Quantity +Quantity -->(item[2]) (jotogulo Quantity barbe ekhane seita);
                //qty means int qty

                int TQty = qty + Int32.Parse(item[2].ToString());
                item[2] = TQty;     //Declaration of Quantity.mane akta Row er jotogulo Quantity hoi sob
                item[4] = TQty * Convert.ToDecimal(item[3].ToString());     //Total Price=Product Quantity * Sales Price


                return true;
            }
        }
        return false;
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
            lblCount.Text = ((DataTable)Session["pk"]).Rows.Count.ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[4].Text = "Total Amount"; //ekhane Cells[4] means 4 number Cells Total Amount likha dekhabe
            e.Row.Cells[5].Text = total.ToString(); //ekhane 5 number Cells Total Amount dekhabe

            //GridView er propertises theke ShowFooter,ShowHeaderWhenEmpty true kore dite hobe
        }
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

    //GridView er event theke RowDeleting double click kore nicher code
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //GridView Design er moddhe Delete button er jonno CommandField theke Delete nite hobe
        dt.Rows.RemoveAt(e.RowIndex);   //Grid er jei row click korbo oitai RowIndex
        GridView1.DataBind();
        grandTotal();

        lblCount.Text = ((DataTable)Session["pk"]).Rows.Count.ToString();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        //Order oo = new Order();
        //oo.OrderDate = DateTime.Now;
        //oo.GrandTotal = grandTotal();

        //db.Orders.Add(oo);
        //db.SaveChanges();

        //foreach (GridViewRow r in GridView1.Rows)
        //{
        //    OrderDetail oRD = new OrderDetail();

        //    oRD.Id = oo.Id;
        //    oRD.PId = r.Cells[1].Text;
        //    oRD.SalesQty = Int32.Parse(r.Cells[3].Text);
        //    oRD.SalesPrice = decimal.Parse(r.Cells[4].Text);

        //    //oRD.SaleTotal = decimal.Parse(r.Cells[3].Text);

        //    db.OrderDetails.Add(oRD);
        //    db.SaveChanges();
        //}
        ////dt.Clear();   //for DataTable clear
        //GridView1.DataBind();

        Response.Redirect("CheckOut.aspx");
    }
}