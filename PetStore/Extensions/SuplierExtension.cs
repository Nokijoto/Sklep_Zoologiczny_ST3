
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Extensions
{ 
    public static class SuplierExtension
    {
        public static SupplierDto ToDto(this Supplier suplier)
        {
            return new SupplierDto
            {
                Id = suplier.Id,
                Name = suplier.Name,
                Email = suplier.Email,
                Phone = suplier.Phone,
                Street = suplier.Street,
                City = suplier.City,
                State = suplier.State,
                ZipCode = suplier.ZipCode,
                Country = suplier.Country,
                Products = suplier.Products.Select(p => p.Name).ToList()
            };
        }
    }

    public static class SuplierDtoExtension
    {
        public static Supplier ToEntity(this SupplierDto suplier)
        {
            return new Supplier
            {
                Id = suplier.Id,
                Name = suplier.Name,
                Email = suplier.Email,
                Phone = suplier.Phone,
                Street = suplier.Street,
                City = suplier.City,
                State = suplier.State,
                ZipCode = suplier.ZipCode,
                Country = suplier.Country
            };
        }
    }
}
