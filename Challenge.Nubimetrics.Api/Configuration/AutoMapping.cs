using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Domain.DataModels;
using Challenge.Nubimetrics.Domain.Entities;

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

            CreateMap<BusquedaDataModel, BusquedaModel>();
            CreateMap<AvailableFilterDataModel, AvailableFilterModel>();
            CreateMap<AvailableFilterValueDataModel, AvailableFilterValueModel>();
            CreateMap<SortDataModel, SortModel>();
            CreateMap<FilterDataModel, FilterModel>();
            CreateMap<FilterValueDataModel, FilterValueModel>();
            CreateMap<PagingDataModel, PagingModel>();
            CreateMap<ResultDataModel, ResultModel>().ForMember(d => d.SellerId, o => o.MapFrom(s => s.Seller.Id));

            CreateMap<UserEntity, UserModel>().ReverseMap();

            CreateMap<CurrencyConversionDataModel, CurrencyConversionModel>().ReverseMap();
            CreateMap<CurrencyConversionToDolarDataModel, CurrencyConversionToDolarModel>().ReverseMap();
        }
    }
}
