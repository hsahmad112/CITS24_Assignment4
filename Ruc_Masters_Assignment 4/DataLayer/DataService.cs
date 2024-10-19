using Microsoft.EntityFrameworkCore;


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
           

            var query = db.Products.Include(x => x.Category).ToList().Find(x => x.Id == id);
            return query;
        }  

    }
}
