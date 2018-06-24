using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextExport
{
    class Program
    {
        static string Path = @"C:\development\textexport\";

        static void Main(string[] args)
        {
            ClearDirectory(Path);
            Test1();
        }

        static void Test1()
        {
            Text text = new Text();
            Product product;
            List<Product> products = new List<Product>();
            Data<Product> data;
            List<Data<Product>> dataList = new List<Data<Product>>();

            product = new Product
            {
                ID = 1,
                Name = "Product 1"
            };

            products.Add(product);
            products.Add(
                new Product
                {
                    ID = 2,
                    Name = "Product 2"
                }
            );

            data = new Data<Product>
            {
                State = "SP",
                Products = products
            };

            dataList.Add(data);
            dataList.Add(
                new Data<Product>
                {
                    State = "RJ",
                    Products = new List<Product> 
                    {
                        new Product
                        {
                            ID = 3,
                            Name = "Product 3"
                        },
                        new Product
                        {
                            ID = 4,
                            Name = "Product 4"
                        }
                    }
                }
            );

            IList<object> dataListMapped = new List<object>();
            dataList.ForEach(
                e =>
                {
                    e.Products.ForEach(
                        i =>
                        {
                            dataListMapped.Add(
                                new
                                {
                                    State = e.State,
                                    ID = i.ID,
                                    Name = i.Name
                                }
                            );
                        }
                    );
                }
            );

            text.Export(
                product,
                string.Format(
                    "{0}Item",
                    Path
                )
            );

            text.Export(
                products,
                string.Format(
                    "{0}ItemList",
                    Path
                )
            );

            text.Export(
                data,
                string.Format(
                    "{0}ComplexData",
                    Path
                )
            );

            text.Export(
                dataListMapped,
                string.Format(
                    "{0}ComplexDataMapped",
                    Path
                )
            );
        }

        public static void ClearDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("The path cannot be null.");
            }

            var di = new DirectoryInfo(path);
            if (di.Exists)
            {
                var files = di.GetFiles();
                foreach (var file in files)
                {
                    file.Delete();
                }
            }
            else
            {
                di.Create();
            }
        }
    }
}