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
    public class EntrenadorService : EntityService<Entrenador>, IEntrenadorService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IEntrenadorRepository _entrenadorRepository;

        public EntrenadorService(IUnitOfWork unitOfWork, IEntrenadorRepository entrenadorRepository)
            : base(unitOfWork, entrenadorRepository)
        {
            _unitOfWork = unitOfWork;
            _entrenadorRepository = entrenadorRepository;
        }
    }
}
