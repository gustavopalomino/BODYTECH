using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstracts;
using Domain.Entities;
using Application.Abstracts;
using Application.Implements;
using Application.Base;
namespace Application.Implements
{
    public class DiasService :  EntityService<Dias>, IDiasService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IDiasRepositoty _diasRepository;

        public DiasService(IUnitOfWork unitOfWork, IDiasRepositoty diasRepository)
            : base(unitOfWork, diasRepository)
        {
            _unitOfWork = unitOfWork;
            _diasRepository = diasRepository;
        }

    }
}
