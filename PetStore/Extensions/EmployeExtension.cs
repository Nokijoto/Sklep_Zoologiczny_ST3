using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Extensions
{
    public static class EmployeExtension
    {
        public static EmployeeDto ToDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                ContactInformation = employee.ContactInformation
            };
        }
    }

    public static class EmployeeDtoExtension
    {
        public static Employee ToEntity(this EmployeeDto employee)
        {
            return new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                ContactInformation = employee.ContactInformation
            };
        }
    }
}
