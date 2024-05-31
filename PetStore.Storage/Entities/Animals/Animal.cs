using SklepZoologiczny.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Storage.Entities.Animals
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }

        public Guid SpecieId { get; set; }
        public virtual Specie Specie { get; set; }
    }
}
