using Microsoft.EntityFrameworkCore;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.DataAccess
{
    public class BlogPostRepository : IBlogRepository
    {

        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BlogPostRepository(IDbContextFactory
            <ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database
                .EnsureCreated();
            }
        }
        public List<BlogPost> GetBlogPosts()
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext
                .BlogPosts.ToList();
            }
        }
        public BlogPost GetBlogPostById(int id)
        {
            using (var applicationDbContext =
                _dbContextFactory.CreateDbContext())
            {
#pragma warning disable CS8603 // Possible null reference return.
                return applicationDbContext.BlogPosts.SingleOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

    }
}
