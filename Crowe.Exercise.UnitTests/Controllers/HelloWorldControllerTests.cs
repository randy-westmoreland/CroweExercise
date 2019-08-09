using AutoMapper;
using Crowe.Exercise.Api.Contracts;
using Crowe.Exercise.Api.Controllers;
using Crowe.Exercise.Business.Contracts;
using Crowe.Exercise.Model.Api;
using Crowe.Exercise.Model.Domain;
using Crowe.Exercise.UnitTests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Crowe.Exercise.UnitTests.Controllers
{
    public class HelloWorldControllerTests
    {
        [Theory]
        [MemberData(nameof(DefaultScope.Get_MessageData), MemberType = typeof(DefaultScope))]
        [Trait("Category", nameof(Controllers))]
        public void Get_Message(MessageDomainModel message)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange
                scope.MapperMock.Setup(x => x.Map<MessageApiModel>(It.IsAny<MessageDomainModel>()));
                scope.HelloWorldManagerMock.Setup(x => x.GetMessage()).Returns(message);

                // Act
                var result = scope.InstanceUnderTest.Message();

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }
        }

        [Theory]
        [MemberData(nameof(DefaultScope.Post_MessageData), MemberType = typeof(DefaultScope))]
        public void Post_Message(int response, object type)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange
                scope.MapperMock.Setup(x => x.Map<MessageDomainModel>(It.IsAny<MessageApiModel>()));
                scope.HelloWorldManagerMock.Setup(x => x.AddMessage(It.IsAny<MessageDomainModel>())).Returns(response);

                // Act
                var result = scope.InstanceUnderTest.Message(It.IsAny<MessageApiModel>());

                Assert.Equal(type.GetType(), result.GetType());
            }
        }


        private class DefaultScope : DisposableTestScope<IHelloWorldController>
        {
            public DefaultScope()
            {
                MapperMock = new Mock<IMapper>();
                HelloWorldManagerMock = new Mock<IHelloWorldManager>();

                InstanceUnderTest = new HelloWorldController(MapperMock.Object, HelloWorldManagerMock.Object);
            }

            public Mock<IMapper> MapperMock { get; set; }
            public Mock<IHelloWorldManager> HelloWorldManagerMock { get; set; }

            public static IEnumerable<object[]> Get_MessageData =>
                new List<object[]>
                {
                    new object[]
                    {
                        new MessageDomainModel
                        {
                            Message = "Hello World!"
                        }
                    }
                };

            public static IEnumerable<object[]> Post_MessageData =>
                new List<object[]>
                {
                    new object[] { 0, new BadRequestResult() },
                    new object[] { 1, new OkResult() }
                };
        }
    }
}