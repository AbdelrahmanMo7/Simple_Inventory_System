using Simple_Inventory_System.BusinessLogic;
using Simple_Inventory_System.DataAccessLogic;
using Simple_Inventory_System.Interfaces;
using Simple_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // using Dependency Injection and Factory Design Pattern
            
            IProductRepository productRepository =new ProductRepository();
            IInventoryManagement inventoryManagement = new InventoryManagement(productRepository);

            // sample data of products in inventory system for testing
            List<Product> products_list = new List<Product>()
            {
                new Product ( "product11", "category11",500.0,20 ),
                new Product ( "product22", "category11",30.0,60 ),
                new Product ( "product33", "category22",85.0,10 ),
                new Product ( "product44", "category22",250.0,15 ),
                new Product ( "product55", "category33",120.0,40 ),
            };

            // adding products to inventory
            foreach (Product product in products_list)
            {
                inventoryManagement.AddNewProduct(product);
            }

            // make user interact with the system via the console
            bool IsSystemOpen_ = true;
            Console.Write("\r\n                   <<<  Inventory system is running...  >>>\r\n");

            while (IsSystemOpen_)
            {
               
                Console.WriteLine(" ---->>  System options :  \r\n" +
                    " 1 - Add New Product. \r\n" +
                    " 2 - Update Stock Quantity. \r\n" +
                    " 3 - List all Products in a particular Category.\r\n" +
                    " 4 - Display Total Inventory Value. \r\n" +
                    " 5 - Close the System. \r\n" +
                    "  < Select Number (1,2,3,4,5) > : ");

                string option_Num=Console.ReadLine();   

                switch(option_Num)
                {
                    //Prompt the user to enter new product details
                    case "1":
                        Console.Write("- Enter new Product Name : ");
                        string name = Console.ReadLine();
                        Console.Write("- Enter Category : ");
                        string category = Console.ReadLine();
                        bool result=true;
                        double price=0.0;
                        do
                        {
                            Console.Write("- Enter Price : ");
                            result = double.TryParse(Console.ReadLine(),out double priceResult);
                            if (result)
                            {
                                price = priceResult;
                            }
                            else
                            {
                                Console.WriteLine("++ incorrect input format please Enter numbers !!! ");
                            }
                        }
                        while (!result);

                        int stockQuantity=0;
                        do
                        {
                            Console.Write("- Enter Stock Quantity : ");
                            result = int.TryParse(Console.ReadLine(), out int Quantity );
                            if (result)
                            {
                                stockQuantity = Quantity;
                            }
                            else
                            {
                                Console.WriteLine("++ incorrect input format please Enter numbers !!! ");
                            }
                        }
                        while (!result);
                        // add new product
                        inventoryManagement.AddNewProduct(new Product(name,category,price,stockQuantity));
                        break;

                    //Prompt the user to enter product name and new Stock Quantity for updating
                    case "2":
                        Console.Write("- Enter Product Name : ");
                        string product_name = Console.ReadLine();
                        int NewStockQuantity = 0;
                        do
                        {
                            Console.Write("- Enter the new Stock Quantity : ");
                            result = int.TryParse(Console.ReadLine(), out int Quantity);
                            if (result)
                            {
                                stockQuantity = Quantity;
                            }
                            else
                            {
                                Console.WriteLine("++ incorrect input format please Enter numbers !!! ");
                            }
                        }
                        while (!result);
                        // update product Stock Quantity
                        inventoryManagement.UpdateStockQuantity(product_name,NewStockQuantity);
                        break;

                        //List all Products in a particular Category
                        case"3":
                        Console.Write("- Enter Category name : ");
                        string selectedCategory = Console.ReadLine();
                         
                        //list products by category
                        inventoryManagement.DisplayProducts_ByCategory(selectedCategory);
                        break;

                    //Calculate and display the total inventory value 
                    case "4":
                        //get total inventory value
                        inventoryManagement.DisplayTotalInventory();
                        break;

                    //Close the System.
                    case "5":
                        //change the value of isSystemOpen? to false to stop the loop
                        Console.WriteLine("^^^  System is closing. Goodby.  ^^^");
                        IsSystemOpen_ = false;
                        break;

                    default:
                        Console.WriteLine("+++ incorrect Option Number !!!  please enter correct number of (1,2,3,4,5)..... ");
                        break;
                }

                Console.WriteLine("Press on any keyboard Key to continue [Enter] ...........");
                Console.ReadLine();
            }

           
        }
    }
}
