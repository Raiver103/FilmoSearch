using FilmoSearch.Persistance; 

namespace FilmoSearch.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly FilmoSearchDbContext Context;

        public TestCommandBase()
        {
            Context = FilmoSearchContextFactory.Create();
        }

        public void Dispose()
        {
            FilmoSearchContextFactory.Destroy(Context);
        }
    }
}
