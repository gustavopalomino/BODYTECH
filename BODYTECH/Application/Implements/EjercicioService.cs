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
    public class EjercicioService : EntityService<Ejercicio>, IEjercicioService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IEjercicioRepository _ejercicioRepository;

        public EjercicioService(IUnitOfWork unitOfWork, IEjercicioRepository ejercicioRepository)
            : base(unitOfWork, ejercicioRepository)
        {
            _unitOfWork = unitOfWork;
            _ejercicioRepository = ejercicioRepository;
        }
    }
}
