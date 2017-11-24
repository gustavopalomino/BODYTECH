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
    public class RutinaService : EntityService <Rutina>, IRutinaService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IRutinaRepository _rutinaRepository;

        public RutinaService(IUnitOfWork unitOfWork, IRutinaRepository rutinaRepository)
            : base(unitOfWork, rutinaRepository)
        {
            _unitOfWork = unitOfWork;
            _rutinaRepository = rutinaRepository;
        }
    }
}
