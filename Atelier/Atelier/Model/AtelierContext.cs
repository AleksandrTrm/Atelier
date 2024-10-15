using System.Data.Entity;

namespace Atelier.Model
{
    public class AtelierContext : DbContext
    {
        public AtelierContext() : base("DefaultConnection") 
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Size> Sizes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Fitting> Fittings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
