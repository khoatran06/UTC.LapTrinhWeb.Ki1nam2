namespace tdkhoa_day3.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}