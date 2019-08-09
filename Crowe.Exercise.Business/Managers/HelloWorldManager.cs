using AutoMapper;
using Crowe.Exercise.Business.Contracts;
using Crowe.Exercise.Data.Contracts;
using Crowe.Exercise.Data.Entities;
using Crowe.Exercise.Model.Domain;
using Crowe.Exercise.Model.View;
using Microsoft.Extensions.Options;
using System;

namespace Crowe.Exercise.Business.Managers
{
    /// <summary>
    /// HelloWorldManager Class.
    /// </summary>
    /// <seealso cref="IHelloWorldManager" />
    public class HelloWorldManager : IHelloWorldManager
    {
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettingsConfig> _appSettings;
        private readonly IMessageRepository _messageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloWorldManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="messageRepository">The message repository.</param>
        public HelloWorldManager(IMapper mapper, IOptions<AppSettingsConfig> appSettings, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _appSettings = appSettings;
            _messageRepository = messageRepository;
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

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <returns>int</returns>
        public int AddMessage(MessageDomainModel message)
        {
            try
            {
                return _messageRepository.Add(_mapper.Map<MessageEntity>(message));
            } catch (NotImplementedException)
            {
                return 0;
            }
        }
    }
}