using System.Collections.Frozen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


namespace CITS_asgmt_4.DataLayer
{
    public class DataService
    {
        public List<Category> GetCategories()
        {
            var db = new NorthwindContext();

            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var db = new NorthwindContext();
            Category category = db.Categories.ToList().Find(x => x.Id == id);
            return category;
        }

        public Category CreateCategory(string name, string description)
        {
            var db = new NorthwindContext();
            bool result; //Can be checked to see if change was created.

            Category category = new Category
            {
                Id = GetCategories().Max(x => x.Id) + 1, //ID set to max id of category + 1
                Name = name,
                Description = description
            };

            try
            {

                db.Categories.Add(category);
                db.SaveChanges();
                result = true;
                return category;
            }
            catch
            {
                result = false;

            }
            return category;


        }


        public bool DeleteCategory(int id)
        {
            var db = new NorthwindContext();
            bool result;
            Category category = db.Categories.ToList().Find(x => x.Id == id);
            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                result = true;
                return result;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            var db = new NorthwindContext();
            bool result;
            Category category = db.Categories.ToList().Find(x => x.Id == id);
            try
            {
                category.Name = name;
                category.Description =  description;
                db.SaveChanges();
                result = true;

            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<Product> GetProducts()
        {
            var db = new NorthwindContext();
            var product = db.Products.ToList();
            return product;
        }

        public Product GetProduct(int id)
        {
            var db = new NorthwindContext();


            var product = db.Products.Include(x => x.Category).ToList().Find(x => x.Id == id);
            return product;
        }

        public List<Product> GetProductByCategory(int id)
        {
            var db = new NorthwindContext();
            var query = db.Products.Include(x => x.Category).ToList().FindAll(x => x.CategoryId == id);
            return query;
        }
        
        public List<Product> GetProductByName(string name)
        {
            var db = new NorthwindContext();
            var q = db.Products.Include(x => x.Category).ToList().FindAll(x => x.ProductName.Contains(name));
            return q;
        }

        public Order GetOrder(int id)
        {
            var db = new NorthwindContext();
            var q = db.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude( x => x.Category).ToList().Find(x => x.Id == id);
            
            return q;
        }
        public List<Order> GetOrders()
        {
            var db = new NorthwindContext();
            return db.Orders.ToList();

        }
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            var db = new NorthwindContext();
            return db.OrderDetails.Include(x => x.Product).ToList().FindAll(x => x.OrderId == id);
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            var db = new NorthwindContext();
            return db.OrderDetails.Include(x => x.Order).Include(x => x.Product).ThenInclude(x => x.Category).OrderBy(x => x.OrderId).ToList().FindAll(x => x.ProductId == id);
        }
    }
}
