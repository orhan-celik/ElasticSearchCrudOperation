using Elasticsearch.Net;
using Nest;

namespace ElasticSearchCrudOperation.API.Extensions
{
    public static class ElasticSearch
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("ElasticSearch")["Url"]!));
            var settings = new ConnectionSettings(pool);
            //settings.BasicAuthentication(configuration.GetSection("ElasticSearch")["Username"]!, configuration.GetSection("ElasticSearch")["Password"]!);
            var client = new ElasticClient(settings);
            services.AddSingleton(client);
        }
    }
}
