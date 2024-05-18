using Microsoft.EntityFrameworkCore;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Para permitir NULL na tabela User, coluna Password
            modelBuilder.Entity<User>().Property(c => c.PasswordHash).IsRequired(false);
            modelBuilder.Entity<User>().Property(d => d.PasswordSalt).IsRequired(false);

            modelBuilder.Entity<Ingredient>().HasIndex(i => i.Product).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            // Implementar dados na Base de Dados nas diferentes Tabelas
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        // Permite atualizar as datas após as gravações
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Recipe && e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((Recipe)entry.Entity).CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((Recipe)entry.Entity).ModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
