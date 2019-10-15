using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DangMNN_Project
{
    public partial class ProductManager : System.Web.UI.Page
    {
        NorthwindEntities entities = new NorthwindEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadDB();
            }
        }

        private void loadDB()
        {
            mytbl.DataSource = (from p in entities.Products where p.Discontinued == false select p).ToList();
            mytbl.DataBind();
        }
        private void search(string proname, decimal min, decimal max)
        {
            NorthwindEntities entities = new NorthwindEntities();
            List<Product> result = (from n in entities.Products where n.ProductName.Contains(proname) && n.UnitPrice >= min && n.UnitPrice <= max  select n).ToList();
            mytbl.DataSource = result;
            mytbl.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string proname = txtProName.Text;
            decimal min = decimal.Parse(txtMin.Text);
            decimal max = decimal.Parse(txtMax.Text);
            if(min == 0 && max == 0)
            {
               Response.Write("<script>alert('Please enter Price');</script>");
            }
            else
            {
                if (min > max)
                {
                    decimal temp = min;
                    min = max;
                    max = temp;
                }
                search(proname, min, max);
            }
        }

        protected void mytbl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NorthwindEntities entities = new NorthwindEntities();
            int id = int.Parse(mytbl.DataKeys[e.RowIndex].Value.ToString());
            var pro = entities.Products.SingleOrDefault(a => a.ProductID == id);

            if(pro != null)
            {
                pro.Discontinued = true;
                entities.SaveChanges();
            }
            Response.Redirect("~/ProductManager.aspx");
        }

        protected void mytbl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void mytbl_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idPro = int.Parse(mytbl.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("DetailPage.aspx?id=" + idPro);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetailPage.aspx");
        }
    }
}