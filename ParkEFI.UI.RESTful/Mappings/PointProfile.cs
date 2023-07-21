using AutoMapper;
using ParkEFI.Domain.Entities;
using ParkEFI.UI.RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEFI.UI.RESTful.Mappings
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<PointEntity, PointDTO>()
                ;

            CreateMap<PointCreateDTO, PointEntity>()
                 .ConvertUsing<PointCreateConverter>()
                 ;
        }
    }

    public class PointCreateConverter : ITypeConverter<PointCreateDTO, PointEntity>
    {
        public PointEntity Convert(PointCreateDTO source, PointEntity destination, ResolutionContext context)
        {
            destination = new PointEntity(
                source.Latitude,
                source.Longitude
                );
            return destination;
        }
    }
}
