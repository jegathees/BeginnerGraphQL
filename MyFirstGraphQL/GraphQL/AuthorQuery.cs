using HotChocolate.Subscriptions;
using MyFirstGraphQL.DataAccess;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.GraphQL
{
    public class AuthorQuery
    {
        public async Task<List<Author>> GetAlllAuthors([Service] IAuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender)
        {
            List<Author> authors = authorRepository.GetAuthors();
            await eventSender.SendAsync("ReturnedAuthors", authors);
            return authors;
        }
        public async Task<Author> SaveAuthorById([Service] IAuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender, int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);
            return author;
        }
        public async Task<List<BlogPost>> GetAllBlogPosts([Service] IBlogRepository blogPostRepository,
        [Service] ITopicEventSender eventSender)
        {
            List<BlogPost> blogPosts =
            blogPostRepository.GetBlogPosts();
            await eventSender.SendAsync("ReturnedBlogPosts",
            blogPosts);
            return blogPosts;
        }
        public async Task<BlogPost> GetBlogPostById([Service] IBlogRepository blogPostRepository,
        [Service] ITopicEventSender eventSender, int id)
        {
            BlogPost blogPost =
            blogPostRepository.GetBlogPostById(id);
            await eventSender.SendAsync("ReturnedBlogPost",
            blogPost);
            return blogPost;
        }
    }
}
