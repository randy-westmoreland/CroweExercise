using AutoMapper;
using Crowe.Exercise.Model.Api;
using Crowe.Exercise.Model.Domain;
using Crowe.Exercise.Model.View;

namespace Crowe.Exercise.Api.Configurations
{
    /// <summary>
    /// AutoMapperConfig Class.
    /// </summary>
    /// <seealso cref="Profile" />
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperConfig"/> class.
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<AppSettingsConfig, MessageDomainModel>()
                .ForMember(dest => dest.Message,
                           opts => opts.MapFrom(src => src.MessageToSend))
                .ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<MessageDomainModel, MessageApiModel>();
        }
    }
}