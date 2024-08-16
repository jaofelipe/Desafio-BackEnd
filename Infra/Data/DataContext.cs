using DesafioBackEnd.Infra.Data.Mappings;
using DesafioBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Motorcycle2024Registration> Motorcycle2024Registrations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<DeliveryPerson> Deliveries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeliveryPersonMap());
            modelBuilder.ApplyConfiguration(new MotorcycleMap());
            modelBuilder.ApplyConfiguration(new Motorcycle2024RegistrationMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
        }
    }
}