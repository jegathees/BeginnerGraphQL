using HotChocolate.Subscriptions;
using MyFirstGraphQL.DataAccess;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.GraphQL
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service] IAuthorRepository authorRepository,
        [Service] ITopicEventSender eventSender, int id,
        string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            var result = await authorRepository.CreateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);
            return result;
        }
    }
}
