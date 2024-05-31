using SklepZoologiczny.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Storage.Entities.Animals
{
    public class Specie : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
