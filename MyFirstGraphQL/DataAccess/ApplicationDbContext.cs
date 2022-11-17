﻿using Microsoft.EntityFrameworkCore;
using MyFirstGraphQL.DataAccess.Model;

namespace MyFirstGraphQL.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }


        protected override void OnModelCreating
        (ModelBuilder modelBuilder)
        {
            Author author1 = new Author
            {
                Id = 1,
                FirstName = "NivYukt",
                LastName = "Jegathees"
            };
            Author author2 = new Author
            {
                Id = 2,
                FirstName = "Jegathees",
                LastName = "Viswanatan"
            };
            Author author3 = new Author
            {
                Id = 3,
                FirstName = "Niharika",
                LastName = "Jegathees"
            };
            modelBuilder.Entity<Author>().HasData(author1, author2, author3);

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Introducing C# 10.0",
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "Introducing Entity Framework Core",
                    AuthorId = 2
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Introducing Kubernetes",
                    AuthorId = 1
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Introducing Machine Learning",
                    AuthorId = 2
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "Introducing DevSecOps",
                    AuthorId = 3
                }
                );
        }
    }
}
