using Nest;

namespace ElasticSearchCrudOperation.API.Models
{
    public class Product
    {
        [PropertyName("_id")]
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public ProductFeauture? Feauture { get; set; }
    }
}
