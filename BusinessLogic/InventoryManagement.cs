using Simple_Inventory_System.Interfaces;
using Simple_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_System.BusinessLogic
{
    public class InventoryManagement : IInventoryManagement
    {
        private readonly IProductRepository productRepository;
        public InventoryManagement(IProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }

        // adding new product to inventory
        public void AddNewProduct(Product product)
        {
            try
            {
                this.productRepository.Add(product);
                Console.WriteLine($"** Product named : {product.Product_Name} added successfully. **");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // updating product Stock Quantity
        public void UpdateStockQuantity(string product_name, int NewQuantity)
        {
            try
            {
                Product product= this.productRepository.GetByName(product_name);
                product.StockQuantity = NewQuantity;
                this.productRepository.update(product);
                Console.WriteLine($"** Stock Quantity of Product named : {product.Product_Name} updated successfully. **");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // display all products in a particular category.
        public void DisplayProducts_ByCategory(string category_name)
        {
            try
            {
                List<Product> Category_Products_List = this.productRepository.GetByCategory(category_name).ToList();

                Console.WriteLine($"-- Products list of : {category_name} Category : ");
                foreach (Product product in Category_Products_List)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        //Calculate and display the total inventory value (sum of the Price *StockQuantity for all products).
        public void DisplayTotalInventory()
        {
            try
            {
                double TotalInventoryValue = this.productRepository.GetAll().Sum(x=>x.StockQuantity*x.Price);
              
                Console.WriteLine($"** Total Inventory Value is : {TotalInventoryValue:C} **");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
