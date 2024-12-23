using ElasticSearchCrudOperation.API.Models;
using Nest;

namespace ElasticSearchCrudOperation.API.DTOs
{
    public record ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ProductFeautureDto? Feauture { get; set; }
    }
}
