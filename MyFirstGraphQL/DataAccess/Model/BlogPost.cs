﻿namespace MyFirstGraphQL.DataAccess.Model
{
    public class BlogPost
    {

        public int Id { get; set; }

        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Title { get; set; }

        [GraphQLNonNullType]
        public int AuthorId { get; set; }

    }
}
