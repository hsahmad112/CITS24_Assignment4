namespace CITS_asgmt_4.DataLayer
{
    public class DataService
    {

        public List<Category> GetCategories()
        {
            var db = new NorthwindContext();
            return db.Categories.ToList();
        }
    }
}
