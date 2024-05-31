using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Storage;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Interfaces;

namespace SklepZoologiczny.Warehouse.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly WarehouseDbContext _context;

        public InventoryTransactionService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryTransaction>> GetAllTransactionsAsync()
        {
            return await _context.InventoryTransactions.ToListAsync();
        }

        public async Task<InventoryTransaction> GetTransactionByIdAsync(Guid id)
        {
            return await _context.InventoryTransactions.FindAsync(id);
        }

        public async Task<InventoryTransaction> CreateTransactionAsync(InventoryTransaction transaction)
        {
            _context.InventoryTransactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteTransactionAsync(Guid id)
        {
            var transaction = await _context.InventoryTransactions.FindAsync(id);
            if (transaction == null)
            {
                throw new Exception("Transaction not found.");
            }

            _context.InventoryTransactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}