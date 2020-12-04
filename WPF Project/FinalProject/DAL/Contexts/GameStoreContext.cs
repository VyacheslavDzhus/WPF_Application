namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
            : base("name=GameStoreContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(e => e.GameName)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);
        }
    }
}
