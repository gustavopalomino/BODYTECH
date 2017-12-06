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
    public class PaquetesService : EntityService<Paquetes>, IPaquetesService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IPaquetesRepository _paquetesRepository;

        public PaquetesService(IUnitOfWork unitOfWork, IPaquetesRepository paquetesRepository)
            : base(unitOfWork, paquetesRepository)
        {
            _unitOfWork = unitOfWork;
            _paquetesRepository = paquetesRepository;
        }


    }
}
