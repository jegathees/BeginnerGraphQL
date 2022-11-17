using HotChocolate.Resolvers;
using MyFirstGraphQL.DataAccess;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.GraphQL
{
    public class BlogPostResolver
    {
        private readonly IBlogRepository
        _blogPostRepository;
        public BlogPostResolver([Service] IBlogRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts()
            .Where(b => b.AuthorId == author.Id);
        }
    }
}
