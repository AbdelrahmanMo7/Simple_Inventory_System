using Simple_Inventory_System.Interfaces;
using Simple_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simple_Inventory_System.DataAccessLogic
{
    // implementing of IProductRepository interface  (Repository Design Pattern)
    public class ProductRepository : IProductRepository
    {
        // dictionary to store products
        private readonly IDictionary<string,Product> Products;

        public ProductRepository()
        {
            Products = new Dictionary<string,Product>();
        }

        // get all products and if the list is empty the function will throw an exception to be handled
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = Products.Values;
            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception(" there is no products in the Iventory. ");
            }
            
        }

        // get all products within particular category and ignore the case sensitive in compairing category name in Equals Function
        //and if the list is empty or the category not found the function will throw an exception to be handled
        public IEnumerable<Product> GetByCategory(string category_Name)
        {
            IEnumerable<Product> FilteredResults=Products.Values.Where(x=>x.Category.Equals(category_Name,StringComparison.OrdinalIgnoreCase));

            if (FilteredResults.Any())
            {
                return FilteredResults;
            }
            else
            {
                throw new Exception(" there is no products in the Category: "+category_Name);
            }
        }

        // get particular product by it's name so the function will check if the named product is found :
        // if the result is true then the product will be returned and if false the function will throw an exception to be handled
        public Product GetByName(string name)
        {
            bool result = Products.TryGetValue(name, out Product product);

            if (result)
            {
                return product;

            }
            else
            {
                throw new Exception(" there is no product named : " + name);
            }
        }

        // add new product so the function will check if this product exists :
        // if the result is false then the product will be added and if true the function will throw an exception to be handled
        public void Add(Product product)
        {
            if (!Products.ContainsKey(product.Product_Name))
            {
                Products[product.Product_Name]= product;
            }
            else
            {
                throw new Exception($" The Product named : {product.Product_Name} is already exists. \r\n  -> You can use Update to increase the Stock Quantity...  ");
            }
        }

        // Update existed product so the function will check if this product already exists :
        // if the result is true then the product will be updated and if false the function will throw an exception to be handled
        public void update(Product product)
        {
            if (Products.ContainsKey(product.Product_Name))
            {
                Products[product.Product_Name] = product;
            }
            else
            {
                throw new Exception($" The Product named : {product.Product_Name} is not exists. ");
            }
        }
    }
}
