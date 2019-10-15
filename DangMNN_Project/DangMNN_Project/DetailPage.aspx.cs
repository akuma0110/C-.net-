using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DangMNN_Project
{
    public partial class DetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadList();
                loadinformation();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text.Trim());
            bool check = false;
            NorthwindEntities entities = new NorthwindEntities();
            foreach(Product p in entities.Products)
            {
                if(p.ProductID == id)
                {
                    check = true;
                }
            }

            if(check == true)
            {
                //update
                update();
            }
            else
            {
                //add
                add();
            }
        }

        private void loadinformation()
        {
            NorthwindEntities entities = new NorthwindEntities();
            string txtid = Request.QueryString["id"];
            if(txtid != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                var x = entities.Products.SingleOrDefault(a => a.ProductID == id);
                Console.WriteLine("asfsadfasdfasdf"+x);
                if (x != null)
                {
                    txtProductID.Text = x.ProductID.ToString();
                    txtProductName.Text = x.ProductName.Trim();
                    txtDisCon.Text = x.Discontinued.ToString();
                    txtPrice.Text = x.UnitPrice.ToString();
                    txtQuantity.Text = x.QuantityPerUnit.ToString();
                    txtStock.Text = x.UnitsInStock.ToString();
                    txtOrder.Text = x.UnitsOnOrder.ToString();
                    int subid = int.Parse(x.SupplierID.ToString());
                    string subname = Subname(subid);
                    int cateid = int.Parse(x.CategoryID.ToString());
                    string catename = CateName(cateid);
                    setSubName( subname, catename);
                }
                
            }
        }

        private void loadList()
        {
            NorthwindEntities entiti = new NorthwindEntities();
            txtSub.DataSource = (from x in entiti.Suppliers select x.CompanyName).ToList();
            txtSub.DataBind();
            txtCate.DataSource = (from x in entiti.Categories select x.CategoryName).ToList();
            txtCate.DataBind();
        }

        private string Subname(int subid)
        {
            string result = null;
            NorthwindEntities entities = new NorthwindEntities();
            var x = entities.Suppliers.Single(a => a.SupplierID == subid);
            if (x != null)
            {
                result = x.CompanyName;
            }
            return result;
        }

        private void setSubName(String subName, String cateName)
        {
            txtSub.Items.FindByValue(subName).Selected = true;
            txtCate.Items.FindByValue(cateName).Selected = true;
        }

        private string CateName(int cateID)
        {
            String result = null;
            NorthwindEntities entity = new NorthwindEntities();
            var x = entity.Categories.SingleOrDefault(a => a.CategoryID == cateID);
            if (x != null)
            {
                result = x.CategoryName;
            }
            return result;
        }
        private int CateID(String cateName)
        {
            int result = -1;
            NorthwindEntities entity = new NorthwindEntities();
            var x = entity.Categories.SingleOrDefault(a => a.CategoryName.Equals(cateName));
            if (x != null)
            {
                result = x.CategoryID;
            }
            return result;
        }

        private int SubID(String subName)
        {
            int result = -1;
            NorthwindEntities entity = new NorthwindEntities();
            var x = entity.Suppliers.SingleOrDefault(a => a.CompanyName.Equals(subName));
            if (x != null)
            {
                result = x.SupplierID;
            }
            return result;
        }
        private void update()
        {
            int id = int.Parse(txtProductID.Text);
            using (NorthwindEntities entity = new NorthwindEntities())
            {
                Product pro = (from x in entity.Products
                               where x.ProductID == id
                               select x).FirstOrDefault();
                pro.ProductName = txtProductName.Text;
                pro.QuantityPerUnit = txtQuantity.Text;
                pro.ReorderLevel = short.Parse(txtReorder.Text);
                pro.SupplierID = SubID(txtSub.Text);
                pro.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                pro.UnitsInStock = Convert.ToInt16(int.Parse(txtStock.Text));
                pro.UnitsOnOrder = Int16.Parse(txtOrder.Text);
                pro.CategoryID = CateID(txtCate.Text);
                pro.Discontinued = bool.Parse(txtDisCon.Text);
                entity.SaveChanges();
            }
            Response.Redirect("ProductManager.aspx");
        }
        private void add()
        {
            Product pro = new Product();
            pro.ProductName = txtProductName.Text;
            pro.QuantityPerUnit = txtQuantity.Text;
            pro.ReorderLevel = 0;
            pro.SupplierID = SubID(txtSub.Text);
            pro.UnitPrice = decimal.Parse(txtPrice.Text);
            pro.UnitsInStock = short.Parse(txtStock.Text);
            pro.UnitsOnOrder = 0;
            pro.CategoryID = CateID(txtCate.Text);
            pro.Discontinued = bool.Parse(txtDisCon.Text);
            NorthwindEntities entity = new NorthwindEntities();
            entity.Products.Add(pro);
            entity.SaveChanges();
        }
    }
}