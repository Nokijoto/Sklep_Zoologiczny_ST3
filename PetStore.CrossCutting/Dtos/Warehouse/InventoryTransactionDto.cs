using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class InventoryTransactionDto
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } // Assuming you want to transfer product name along with the transaction

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; } // Assuming you want to transfer employee name along with the transaction

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
