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
    public class Cliente_PaquetesService : EntityService<Cliente_Paquetes>, ICliente_PaquetesService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICliente_PaquetesRepository _cliente_PaquetesRepository;

        public Cliente_PaquetesService(IUnitOfWork unitOfWork, ICliente_PaquetesRepository cliente_PaquetesRepository)
            : base(unitOfWork, cliente_PaquetesRepository)
        {
            _unitOfWork = unitOfWork;
            _cliente_PaquetesRepository = cliente_PaquetesRepository;
        }
    }
}
