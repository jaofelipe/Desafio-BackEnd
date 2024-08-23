using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Application.Services;

namespace DesafioBackEnd.API.Dependencies
{
    public static class ApplicationDependencyInjector
    {
        public static IServiceCollection Add(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMotorcycleService, MotorcycleService>();
            serviceCollection.AddScoped<IDeliveryPersonService, DeliveryPersonService>();
            serviceCollection.AddScoped<IRentalService, RentalService>();

            return serviceCollection;
        }

    }
}
