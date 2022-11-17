using HotChocolate.Resolvers;
using MyFirstGraphQL.DataAccess;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.GraphQL
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorResolver([Service] IAuthorRepository
        authorService)
        {
            _authorRepository = authorService;
        }
        public Author GetAuthor(BlogPost blog, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().FirstOrDefault(a => a.Id == blog.AuthorId);
        }
    }
}
