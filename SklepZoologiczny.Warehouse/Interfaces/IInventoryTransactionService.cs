using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface IInventoryTransactionService
    {
        Task<List<InventoryTransaction>> GetAllTransactionsAsync();
        Task<InventoryTransaction> GetTransactionByIdAsync(Guid id);
        Task<InventoryTransaction> CreateTransactionAsync(InventoryTransaction transaction);
        Task DeleteTransactionAsync(Guid id);

    }
}
