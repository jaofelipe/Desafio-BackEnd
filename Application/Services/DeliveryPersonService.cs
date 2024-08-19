using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Infra.Repository;
using DesafioBackEnd.Models;

namespace DesafioBackEnd.Application.Services
{
    public class DeliveryPersonService : IDeliveryPersonService
    {
        private readonly IDeliveryPersonRepository _repository;
        private readonly IHostEnvironment _environment;

        public DeliveryPersonService(IDeliveryPersonRepository repository, IHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public async Task AddAsync(DeliveryPerson deliveryPerson)
        {
            if (await _repository.ExistsByCnpjAsync(deliveryPerson.Cnpj))
            {
                throw new InvalidOperationException("Já existe um cadastro com esse CNPJ.");
            }

            await _repository.AddAsync(deliveryPerson);
        }

        public async Task<IEnumerable<DeliveryPerson?>> GetAllAsync() => await _repository.GetAllAsync();
        

        public async Task<string> SaveCnhImageAsync(Guid deliveryPersonId, IFormFile cnhImage)
        {
            if (cnhImage == null || (cnhImage.ContentType != "image/png" && cnhImage.ContentType != "image/bmp"))
            {
                throw new ArgumentException("Formato inválido, somente PNG ou BMP são permitidos.");
            }

            var directoryPath = Path.Combine(_environment.ContentRootPath, "cnh_images", deliveryPersonId.ToString());
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = "cnh" + Path.GetExtension(cnhImage.FileName);
            var filePath = Path.Combine(directoryPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await cnhImage.CopyToAsync(fileStream);
            }

            return filePath;
        }

        private void DeleteCnhImage(Guid deliveryPersonId)
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "cnh_images", deliveryPersonId.ToString());
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }


    }
}
