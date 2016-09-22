using LittleSheep.Configuration;
using LittleSheep.Entities;
using System;
using System.IO;
using System.Xml.Linq;

namespace LittleSheep.Products
{
    public class ProductRepository
    {
        public bool AddNewProduct(Product item)
        {
            try
            {
                if (File.Exists(Paths.PathToProductsXml()))
                {
                    var xDocument = XDocument.Load(Paths.PathToProductsXml());
                    var product = xDocument.Element("Products");

                    if (product != null)
                    {
                        product.Add(new XElement("Product",
                            new XElement("Category", item.Category),
                            new XElement("Name", item.Name),
                            new XElement("Description", item.Description),
                            new XElement("Price", item.Price),
                            new XElement("Units", item.Units),
                            new XElement("ImageSource", item.ImageSource)));

                        xDocument.Save(Paths.PathToProductsXml());
                    }
                }
                else
                {
                    var product =
                        new XElement("Products",
                            new XElement("Product",
                               new XElement("Category", item.Category),
                               new XElement("Name", item.Name),
                               new XElement("Description", item.Description),
                               new XElement("Price", item.Price),
                               new XElement("Units", item.Units),
                            new XElement("ImageSource", item.ImageSource)));

                    using (var streamWriter = new StreamWriter(Paths.PathToProductsXml(), true))
                    {
                        product.Save(streamWriter);
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                using (var streamWriter = new StreamWriter(Paths.PathToExceptionLog(), true))
                {
                    streamWriter.WriteLine(DateTime.Now + " " + exception.Message);
                }

                return false;
            }
        }

        public static void EditExistingProduct()
        {

        }

        public static void AbstractBoughtProduct()
        {

        }

    }
}