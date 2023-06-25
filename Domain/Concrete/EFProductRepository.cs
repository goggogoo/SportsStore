using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFProductRepository:IProductsRepository
    {
        private EFdbcontext context = new EFdbcontext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0) { context.Products.Add(product); }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    //dbEntry.Name = product.Name;
                    //dbEntry.Description = product.Description;
                    //dbEntry.Price = product.Price;
                    //dbEntry.Category = product.Category;
                    //dbEntry.ImageData = product.ImageData;
                    //dbEntry.ImageMimeType = product.ImageMimeType;

                    foreach (System.Reflection.PropertyInfo info1 in dbEntry.GetType().GetProperties())
                    {
                        if (info1.Name.ToString() != "ProductId")
                        {
                            foreach (System.Reflection.PropertyInfo info2 in product.GetType().GetProperties())
                            {
                                if (info1.Name == info2.Name)
                                {
                                    if ((info2.Name.ToString() == "ImageData" && info2.GetValue(product) == null) || (info2.Name.ToString() == "ImageMimeType" && info2.GetValue(product) == null)) { }else
                                    info1.SetValue(dbEntry, info2.GetValue(product));
                                }
                            }
                        }
                    }
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
