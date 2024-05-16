using Aloya.Domain;
using Aloya.Domain.Auth;
using Aloya.Domain.Module;
using Aloya.Domain.Tests;
using Aloya.Domain.Tests.Answers;
using Aloya.Domain.Tests.Tasks;
using Aloya.Domain.Theory;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Aloya.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        public DbSet<Module> Modules { get; set; }
        public DbSet<GlobalTest> GlobalTests { get; set; }
        public DbSet<ImageTask> ImageTasks { get; set; }
        public DbSet<FormTask> FormTasks { get; set; }
        public DbSet<AreaTask> AreaTasks { get; set; }
        public DbSet<AreaAnswer> AreaAnswers { get; set; }
        public DbSet<FormAnswer> FormAnswers { get; set; }
        public DbSet<ImageAnswer> ImageAnswers { get; set; }
        public DbSet<Illustration> Illustrations { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Verify> Verifys { get; set; }
        public DbSet<UserAdmicy> userAdmicies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
    }
}
