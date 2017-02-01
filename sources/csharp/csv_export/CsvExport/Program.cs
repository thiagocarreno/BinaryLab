using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using LINQtoCSV;
using System.Collections;
using CsvExport;

namespace CsvExport
{
    class Program
    {
        static string Path = @"C:\development\csvexport\";

        static void Main(string[] args)
        {
            ClearDirectory(Path);
            Test1();
            //Test2();
        }

        static void Test1()
        {
            Csv csv = new Csv();
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
                Products = products,
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

            csv.Export(
                product,
                string.Format(
                    "{0}Item",
                    Path
                )
            );

            csv.Export(
                products,
                string.Format(
                    "{0}ItemList",
                    Path
                )
            );

            csv.Export(
                data,
                string.Format(
                    "{0}ComplexData",
                    Path
                )
            );

            csv.Export(
                dataList,
                string.Format(
                    "{0}DataList",
                    Path
                )
            );

            csv.Export(
                dataListMapped,
                string.Format(
                    "{0}ComplexDataMapped",
                    Path
                )
            );
        }

        static void Test2()
        {
            Csv csv = new Csv();
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

            var settings = new CsvFileDescription
            {
                SeparatorChar = ';'
            };

            var csvContext = new CsvContext();
            csvContext.Write(
                new List<Product>
                {
                    product
                },
                string.Format(
                    "{0}Item.csv",
                    Path
                ),
                settings
            );

            csvContext.Write(
                products,
                string.Format(
                    "{0}ItemList.csv",
                    Path
                ),
                settings
            );

            var complexData = (
                from obj in data.Products
                select new
                {
                    State = data.State,
                    ID = obj.ID,
                    Name = obj.Name
                }
            );

            csvContext.Write(
                complexData,
                string.Format(
                    "{0}ComplexData.csv",
                    Path
                ),
                settings
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

            csvContext.Write(
                dataListMapped,
                string.Format(
                    "{0}ComplexDataList.csv",
                    Path
                ),
                settings
            );


            IList<object> result = new List<object>();
            foreach (var item in dataList)
            {
                //var test = (
                //    from obj in data.Products
                //    select new
                //        {
                //            State = item.State,
                //            ID = obj.ID,
                //            Name = obj.Name
                //        }
                //);

                foreach (var j in item.Products)
                {
                    result.Add(
                        new
                        {
                            State = item.State,
                            ID = j.ID,
                            Name = j.Name
                        }
                    );
                }
            }

            csvContext.Write(
                result,
                string.Format(
                    "{0}Test.csv",
                    Path
                ),
                settings
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