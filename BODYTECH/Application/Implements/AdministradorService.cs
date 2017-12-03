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
    public class AdministradorService : EntityService<Administrador>, IAdministradorService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IUnitOfWork unitOfWork, IAdministradorRepository administradorRepository)
            : base(unitOfWork, administradorRepository)
        {
            _unitOfWork = unitOfWork;
            _administradorRepository = administradorRepository;
        }
    }
}
 