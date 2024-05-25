using AutoMapper;
using PlatformApi.Dtos.Request;
using PlatformApi.Dtos.Response;
using PlatformApi.Models;

namespace PlatformApi.Helper.Mapping
{
    public class PlateformeProfile : Profile
    {
        public PlateformeProfile()
        {
            CreateMap<VendeurRequestDto, Vendeur>();
            CreateMap<Vendeur, VendeurResponseDto>();
            CreateMap<VendorUpdateDto, Vendeur>();
            CreateMap<VendeurRequestUpdatePasswordDto, Vendeur>();
            CreateMap<VendeurRegisterRequestDto, Vendeur>();

            CreateMap<AdminRequestDto, Admin>();
            CreateMap<PaiementRequestDto, Paiement>();
            CreateMap<Paiement, PaiementResponseDto>();
            CreateMap<PlanPaiementRequestDto, PlanPaiement>();
            CreateMap<PlanPaiement, PlanPaiementResponseDto>();

            CreateMap<EmailRequestDto, Email>();
        }
    }
}
