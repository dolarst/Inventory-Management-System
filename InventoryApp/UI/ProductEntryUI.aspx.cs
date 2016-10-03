using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventoryApp.BLL;
using InventoryApp.Model;

namespace InventoryApp.UI
{
    public partial class ProductEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        ProductManager productManger =  new ProductManager();
        protected void SaveButton_Click(object sender, EventArgs e)
        {
           
            Product product =  new Product();
            product.Barcode = barcodeBox.Text;
            product.Name = nameEntryBox.Text;
            product.Quantity = int.Parse(quantityEntryBox.Text);
            product.UnitPrice = int.Parse(unitPriceEntryBox.Text);
            product.EntryDate = Convert.ToDateTime(datePikerBox.Text);
            
            
            if(productManger.SaveProduct(product) == 2)
            {
                

                messageLabel.Text = "Product Has been Saved";

            }
            else if (productManger.SaveProduct(product) == 1)
            {
                messageLabel.Text = product.Barcode + " Already Exist , Product Quantity Updated .";
            }
            else
            {
                messageLabel.Text = "Product Can not be Added ";
            }

        }

        protected void showAllButton_Click(object sender, EventArgs e)
        {
            productGridView.DataSource = productManger.GetProduct();
            productGridView.DataBind();
            messageLabel.Text = "All product info";
        }
        protected void showButoon_Click(object sender, EventArgs e)
        {

            productGridView.DataSource = productManger.GetProductByDate(Convert.ToDateTime(fromDateBox.Text), Convert.ToDateTime(toDateBox.Text));
            productGridView.DataBind();
            messageLabel.Text = "ALL Product info By entry date : " + fromDateBox.Text + " to " + toDateBox.Text;
        }




    }
}