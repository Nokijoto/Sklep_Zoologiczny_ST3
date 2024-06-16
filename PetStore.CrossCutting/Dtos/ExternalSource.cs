using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.CrossCutting.Dtos
{
    public abstract class ExternalSource  
    {
        public Guid ExternalId { get; set; }
        public string ExternalSourceName { get; set; }
    }
}
