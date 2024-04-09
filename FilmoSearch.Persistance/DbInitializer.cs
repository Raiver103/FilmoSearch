namespace FilmoSearch.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(FilmoSearchDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
