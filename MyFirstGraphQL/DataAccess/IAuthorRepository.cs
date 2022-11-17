﻿using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.DataAccess
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public Task<Author> CreateAuthor(Author author);
    }
}
