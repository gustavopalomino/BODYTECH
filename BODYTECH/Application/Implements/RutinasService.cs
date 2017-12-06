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
    public class RutinasService : EntityService<Rutinas>, IRutinasService
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IRutinasRepository _rutinasRepository;

        public RutinasService(IUnitOfWork unitOfWork, IRutinasRepository rutinaRepository)
            : base(unitOfWork, rutinaRepository)
        {
            _unitOfWork = unitOfWork;
            _rutinasRepository = rutinaRepository;
        }

    }
}
