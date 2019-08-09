using AutoMapper;
using Crowe.Exercise.Business.Contracts;
using Crowe.Exercise.Model.Domain;
using Crowe.Exercise.Model.View;
using Microsoft.Extensions.Options;

namespace Crowe.Exercise.Business.Managers
{
    /// <summary>
    /// HelloWorldManager Class.
    /// </summary>
    /// <seealso cref="IHelloWorldManager" />
    public class HelloWorldManager : IHelloWorldManager
    {
        private readonly IOptions<AppSettingsConfig> _appSettings;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloWorldManager"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="mapper">The mapper.</param>
        public HelloWorldManager(IOptions<AppSettingsConfig> appSettings, IMapper mapper)
        {
            _appSettings = appSettings;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>
        /// MessageDomainModel
        /// </returns>
        public MessageDomainModel GetMessage()
        {
            return _mapper.Map<MessageDomainModel>(_appSettings.Value);
        }
    }
}