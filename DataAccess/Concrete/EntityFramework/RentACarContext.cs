using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentACarDb;Trusted_Connection=true");
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Card> Card { get; set; }

    }
}
