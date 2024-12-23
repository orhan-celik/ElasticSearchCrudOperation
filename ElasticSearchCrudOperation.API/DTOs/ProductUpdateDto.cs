namespace ElasticSearchCrudOperation.API.DTOs
{
    public record ProductUpdateDto(string Id, string Name, decimal Price, int Stock, ProductFeautureDto? Feature)
    {
    }
}
