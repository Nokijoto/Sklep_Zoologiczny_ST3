using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepZoologiczny.Common.CrossCutting.Enums;

namespace SklepZoologiczny.Common.CrossCutting.Dtos
{
    public class CrudOperationResult<TDto>
    {
        public CrudOperationResultStatus Status { get; set; }

        public TDto? Result { get; set; }
    }
}
