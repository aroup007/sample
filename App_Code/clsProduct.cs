using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsProduct
/// </summary>
public class clsProduct
{
    public clsProduct()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Id { get; set; }
    public string ProductName { get; set; }
    public Nullable<int> Quantity { get; set; }
    public Nullable<decimal> Price { get; set; }
    public string ProductImage { get; set; }
    public Nullable<int> CategoryId { get; set; }

}