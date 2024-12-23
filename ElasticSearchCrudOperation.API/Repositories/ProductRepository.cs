using ElasticSearchCrudOperation.API.DTOs;
using ElasticSearchCrudOperation.API.Models;
using Nest;
using System.Collections.Immutable;

namespace ElasticSearchCrudOperation.API.Repositories
{
    public class ProductRepository
    {
        private readonly ElasticClient _client;
        private const string _indexName = "products";

        public ProductRepository(ElasticClient client)
        {
            _client = client;
        }

        public async Task<Product> SaveAsync(Product newProduct)
        {
            //var response = await _client.IndexAsync(newProduct, x => x.Index(_indexName));

            // Eğer ID Göndermek İstersek. => .Id(Guid.NewGuid().ToString())
            var response = await _client.IndexAsync(newProduct, x => x.Index(_indexName).Id(Guid.NewGuid().ToString()));
            if (!response.IsValid) return null;
            newProduct.Id = response.Id;
            return newProduct;
        }

        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(s => s.Index(_indexName).Query(q => q.MatchAll()));
            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;
            return result.Documents.ToImmutableList();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var response = await _client.GetAsync<Product>(id, x => x.Index(_indexName));
            if (!response.Found || !response.IsValid) return null;
            response.Source.Id = response.Id;
            return response.Source;
        }

        public async Task<bool> UpdateAsync(ProductUpdateDto product)
        {
            var response = await _client.UpdateAsync<Product, ProductUpdateDto>(product.Id, x => x.Index(_indexName).Doc(product));
            return response.IsValid;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _client.DeleteAsync<Product>(id, x => x.Index(_indexName));
            return response.IsValid;
        }
    }
}
