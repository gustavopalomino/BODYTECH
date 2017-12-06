using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstracts;
using Domain.Entities;
using Application.Abstract;
using Application.Base;
using Application.Abstracts;
namespace Application.Implements
{
    public class Rutina_EjercicioService : EntityService<Rutina_Ejercicio>, IRutina_EjercicioService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IRutina_EjercicioRepository _rutina_ejercicioRepository;

        public Rutina_EjercicioService(IUnitOfWork unitOfWork, IRutina_EjercicioRepository rutina_ejercicioRepository)
            : base(unitOfWork, rutina_ejercicioRepository)
        {
            _unitOfWork = unitOfWork;
            _rutina_ejercicioRepository = rutina_ejercicioRepository;
        }
    }
}
