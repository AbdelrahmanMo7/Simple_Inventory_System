using Simple_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_System.Interfaces
{
    // using Repository Design Pattern for CRUD operations
    public interface IProductRepository
    {
        Product GetByName(string name);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(string category_Name);
        void Add(Product product);
        void update(Product product);
    }
}
