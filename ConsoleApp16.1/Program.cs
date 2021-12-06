using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;




namespace ConsoleApp16._1
{
    class Program
    {


        static void Main(string[] args)
        {
            string path = "C:\\Users\\kzyukina\\OneDrive - DAE\\Документы\\06_TEST\\Products.json";
            Product product1 = new Product { ProductName = Console.ReadLine(), ProductCode = Convert.ToUInt32(Console.ReadLine()), ProductCost = Convert.ToDouble(Console.ReadLine()) };
            Product product2 = new Product { ProductName = Console.ReadLine(), ProductCode = Convert.ToUInt32(Console.ReadLine()), ProductCost = Convert.ToDouble(Console.ReadLine()) };
            Product product3 = new Product { ProductName = Console.ReadLine(), ProductCode = Convert.ToUInt32(Console.ReadLine()), ProductCost = Convert.ToDouble(Console.ReadLine()) };
            Product product4 = new Product { ProductName = Console.ReadLine(), ProductCode = Convert.ToUInt32(Console.ReadLine()), ProductCost = Convert.ToDouble(Console.ReadLine()) };
            Product product5 = new Product { ProductName = Console.ReadLine(), ProductCode = Convert.ToUInt32(Console.ReadLine()), ProductCost = Convert.ToDouble(Console.ReadLine()) };
            Product[] productArray = new Product[5];
            productArray[0] = product1;
            productArray[1] = product2;
            productArray[2] = product3;
            productArray[3] = product4;
            productArray[4] = product5;


            string json = System.Text.Json.JsonSerializer.Serialize(productArray);
            Console.WriteLine(json);
            Console.ReadLine();

            StreamWriter file = new StreamWriter(path);
            file.WriteLine(json);
            Console.WriteLine("Data has been saved to file");

            file.Close();


            
            string json2 = File.ReadAllText(path);
            Product [] productset = JsonSerializer.Deserialize<Product[]>(json2);
            Console.WriteLine(json2);

            foreach (Product p in productset)
            {
               
                Console.WriteLine(p.ProductName);
                Console.WriteLine("------------");
                Console.WriteLine(p.ProductCode);
                Console.WriteLine("------------");
                Console.WriteLine(p.ProductCost);
                Console.WriteLine("------------"); }
           
            double max;
            max = productset[0].ProductCost;
            string maxName;
            maxName = productset[0].ProductName;
            for (int i=0; i<productset.Length;i++)
            {
                if (productset[i].ProductCost > max)
                {
                    max = productset[i].ProductCost;
                    maxName = productset[i].ProductName;
                }

            }

           
            Console.WriteLine("Максимальная стоимость {0} у {1}", max, maxName);
            
                        Console.ReadKey();
            }
        
    }

    class Product
    {
        [JsonPropertyName("productname")]
        public string ProductName { get; set; }
        [JsonPropertyName("productcode")]
        public uint ProductCode { get; set; }
        [JsonPropertyName("productcost")]
        public double ProductCost { get; set; }
    }
    
}
