using ElasticSearchCrudOperation.API.Models;

namespace ElasticSearchCrudOperation.API.DTOs
{
    public record ProductCreateDto(string Name, decimal Price, int Stock, ProductFeautureDto Feature)
    {
    }
}
