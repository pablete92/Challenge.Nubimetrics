using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Domain.DataModels;

namespace Challenge.Nubimetrics.Api.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PaisDataModel, PaisModel>();
            CreateMap<GeoInformationDataModel, GeoInformationModel>();
            CreateMap<LocationDataModel, LocationModel>();
            CreateMap<StateDataModel, StateModel>();
        }
    }
}
