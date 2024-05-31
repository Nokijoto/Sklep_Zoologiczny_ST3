using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Extension;
using SklepZoologiczny.Warehouse.Interfaces;
using SklepZoologiczny.Warehouse.Storage;

namespace SklepZoologiczny.Warehouse.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly WarehouseDbContext _context;

        public EmployeService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllEmployesAsync()
        {
            return await _context.Employees.Select(e=>e.ToDto()).ToListAsync();
        }
        public async Task<EmployeeDto> GetEmployeByIdAsync(Guid id)
        {
            var employe = await _context.Employees.FindAsync(id);
            if (employe == null)
            {
                throw new Exception("Employe not found.");
            }
            return employe.ToDto();
        }


        public async Task<EmployeeDto> CreateEmployeAsync(EmployeeDto employe)
        {
            _context.Employees.Add(employe.ToEntity());
            await _context.SaveChangesAsync();
            return employe;
        }
        public async Task<EmployeeDto> UpdateEmployeAsync(Guid id, EmployeeDto updatedEmploye)
        {
            var employe = await _context.Employees.FindAsync(id);
            if (employe == null)
            {
                throw new Exception("Employe not found.");
            }

            employe.Name = updatedEmploye.Name;


            await _context.SaveChangesAsync();
            return employe.ToDto();
        }
    }
}
