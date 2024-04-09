using AutoMapper;
using FilmoSearch.Application.Common.Mappings;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Persistance; 
using Xunit;

namespace FilmoSearch.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FilmoSearchDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = FilmoSearchContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IFilmoSearchDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            FilmoSearchContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
} 
