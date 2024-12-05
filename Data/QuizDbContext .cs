using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Data
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
    }
}