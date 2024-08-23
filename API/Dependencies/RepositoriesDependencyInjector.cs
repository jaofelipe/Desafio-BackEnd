using DesafioBackEnd.Infra.Repository;

namespace DesafioBackEnd.API.Dependencies
{
    public static class RepositoriesDependencyInjector
    {
        public static IServiceCollection Add(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            serviceCollection.AddScoped<IDeliveryPersonRepository, DeliveryPersonRepository>();
            serviceCollection.AddScoped<IRentalRepository, RentalRepository>();


            return serviceCollection;
        }

    }
}
