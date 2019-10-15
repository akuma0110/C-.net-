using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lolproject
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
            }
        }
        private void load()
        {
            NorthwindEntities entities = new NorthwindEntities();
            DataTable tbl = new DataTable();
            string[] id = null;
            int i = 0;
            tbl.Columns.Add("Product Name");
            tbl.Columns.Add("Unit Price");
            tbl.Columns.Add("Units in stock");
            do
            {

            }while()
            foreach (Product p in entities.Products)
            {
                tbl.Rows.Add(p.ProductName, p.UnitPrice, p.UnitsInStock);
            }
            mytbl.DataSource = tbl;
            mytbl.DataBind();
        }

        protected void mytbl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                var frow = mytbl.FooterRow;
                TextBox txtProductName = (TextBox)frow.FindControl("txtProductName");
                TextBox txtPrice = (TextBox)frow.FindControl("txtPrice");
                TextBox txtUnitInStock = (TextBox)frow.FindControl("txtUnitInStock");
                using (NorthwindEntities entities = new NorthwindEntities())
                {
                    entities.Products.Add(new Product
                    {
                        ProductName = txtProductName.Text.Trim(),
                        UnitPrice =Decimal.Parse(txtPrice.Text.Trim()),
                        UnitsInStock = short.Parse(txtUnitInStock.Text.Trim())
                    });
                    entities.SaveChanges();
                    load();
                }
            }
        }

        protected void mytbl_RowEditing(object sender, GridViewEditEventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();
            mytbl.EditIndex = e.NewEditIndex;
            load();
        }
    }
}