using AutoMapper;
using Crowe.Exercise.Api.Contracts;
using Crowe.Exercise.Business.Contracts;
using Crowe.Exercise.Model.Api;
using Crowe.Exercise.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Crowe.Exercise.Api.Controllers
{
    /// <summary>
    /// HelloWorldController Class.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    /// <seealso cref="IHelloWorldController" />
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase, IHelloWorldController
    {
        private readonly IMapper _mapper;
        private readonly IHelloWorldManager _helloWorldManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloWorldController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="helloWorldManager">The hello world manager.</param>
        public HelloWorldController(IMapper mapper, IHelloWorldManager helloWorldManager)
        {
            _mapper = mapper;
            _helloWorldManager = helloWorldManager;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>
        /// MessageApiModel
        /// </returns>
        [HttpGet("[action]")]
        public IActionResult Message()
        {
            var message = _helloWorldManager.GetMessage();
            return Ok(_mapper.Map<MessageApiModel>(message));
        }

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// IActionResult
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpPost("[action]")]
        public IActionResult Message([FromBody] MessageApiModel message)
        {
            var response = _helloWorldManager.AddMessage(_mapper.Map<MessageDomainModel>(message));
            if (response == 0)
            {
                return BadRequest();
            } else
            {
                return Ok();
            }
        }
    }
}