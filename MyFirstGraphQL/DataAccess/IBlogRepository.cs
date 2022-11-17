using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.DataAccess
{
    public interface IBlogRepository
    {
        public List<BlogPost> GetBlogPosts();
        public BlogPost GetBlogPostById(int id);
    }
}
