using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstracts;
using Domain.Entities;
using Application.Abstract;
using Application.Implements;
using Application.Base;

namespace Application.Implements
{
    public class PersonService : EntityService<Personas>, IPersonService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }

    }
}
