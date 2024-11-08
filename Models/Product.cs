using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_System.Models
{
    public class Product
    {
        // product Entity Properties 
        public string Product_Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(string _Product_Name, string _Category, double _Price, int _StockQuantity)
        {
            this.Product_Name = _Product_Name;
            this.Category = _Category;
            this.Price = _Price;
            this.StockQuantity = _StockQuantity;
        }

        // override the tostring() to display product properties
        public override string ToString()
        {
            return $"Product name : {this.Product_Name} , Category : {this.Category} ->  Price : {this.Price:C} , Stock Quantity : {this.StockQuantity}";
        }

    }
}
