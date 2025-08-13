using AutoMapper;
using PlanoDeAula.Communication.Requests;

namespace PlanoDeAula.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
                .ForMember(destiny => destiny.Password, opt => opt.Ignore());
        }


    }
}
