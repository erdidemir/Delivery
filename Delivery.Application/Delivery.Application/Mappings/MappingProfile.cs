using AutoMapper;
using Delivery.Application.Features.Commands.Authentications;
using Delivery.Application.Features.Commands.Cargos.Adds.AddCargo;
using Delivery.Application.Models.Authentications;
using Delivery.Application.Models.Cargos;
using Delivery.Domain.Entities.Authentications;
using Delivery.Domain.Entities.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Authentications

            CreateMap<User, SignUpUserCommand>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            #endregion

            #region Cargos

            CreateMap<Cargo, CargoViewModel>().ReverseMap();
            CreateMap<Cargo, AddCargoCommand>().ReverseMap();

            #endregion
        }
    }
}
