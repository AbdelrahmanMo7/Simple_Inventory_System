using Simple_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_System.Interfaces
{
    public interface IInventoryManagement
    {
        void AddNewProduct(Product product);
        void UpdateStockQuantity(string product_name, int NewQuantity);
        void DisplayProducts_ByCategory(string category_name);
        void DisplayTotalInventory();
    }
}
