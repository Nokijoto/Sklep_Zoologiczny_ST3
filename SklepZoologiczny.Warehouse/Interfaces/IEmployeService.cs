using SklepZoologiczny.Warehouse.CrossCutting.Dtos;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface IEmployeService
    {
        Task<EmployeeDto> CreateEmployeAsync(EmployeeDto employe);
        Task<List<EmployeeDto>> GetAllEmployesAsync();
        Task<EmployeeDto> GetEmployeByIdAsync(Guid id);
        Task<EmployeeDto> UpdateEmployeAsync(Guid id, EmployeeDto updatedEmploye);
    }
}