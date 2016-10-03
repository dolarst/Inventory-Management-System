using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using InventoryApp.DAL;
using InventoryApp.Model;

namespace InventoryApp.BLL
{
    public class ProductManager
    {
        ProductGetway productGetway =  new ProductGetway();
        

        public int SaveProduct (Product product)
        {

            foreach (Product oldProduct in productGetway.GetProduct())
            {
                if (oldProduct.Barcode == product.Barcode)
                {
                    productGetway.UpdateQuantity(product,oldProduct);
                    return 1;

                }
            }
            
             productGetway.SaveProduct(product);
            return 2;

        }
        






        public List<Product> GetProduct()
        {
            
            return productGetway.GetProduct();
        }

        public List<Product> GetProductByDate(DateTime fromDate , DateTime toDate)
        {
           return productGetway.GetProductByDate(fromDate, toDate);
        }





    }
}