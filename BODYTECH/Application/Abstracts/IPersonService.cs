using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Base;

namespace Application.Abstract
{
    public interface IPersonService :  IEntityService<Personas>
    {
    }
}
