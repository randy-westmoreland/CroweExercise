using AutoMapper;
using Crowe.Exercise.Business.Contracts;
using Crowe.Exercise.Business.Managers;
using Crowe.Exercise.Data.Contracts;
using Crowe.Exercise.Data.Entities;
using Crowe.Exercise.Model.Domain;
using Crowe.Exercise.Model.View;
using Crowe.Exercise.UnitTests.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Crowe.Exercise.UnitTests.Managers
{
    public class HelloWorldManagerTests
    {
        [Theory]
        [MemberData(nameof(DefaultScope.GetMessageData), MemberType = typeof(DefaultScope))]
        [Trait("Category", nameof(Managers))]
        public void GetMessage(AppSettingsConfig appSettings, MessageDomainModel message, string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange
                scope.AppSettingsMock.Setup(x => x.Value).Returns(appSettings);
                scope.MapperMock.Setup(x => x.Map<MessageDomainModel>(It.IsAny<AppSettingsConfig>())).Returns(message);

                // Act
                var result = scope.InstanceUnderTest.GetMessage();

                // Assert
                Assert.Equal(expected, result.Message);
            }
        }

        [Theory]
        [MemberData(nameof(DefaultScope.AddMessageData), MemberType = typeof(DefaultScope))]
        [Trait("Category", nameof(Managers))]
        public void AddMessage(MessageEntity message, int response, int expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange
                scope.MapperMock.Setup(x => x.Map<MessageEntity>(It.IsAny<MessageDomainModel>())).Returns(message);
                scope.MessageRepositoryMock.Setup(x => x.Add(It.IsAny<MessageEntity>())).Returns(response);

                // Act
                var result = scope.InstanceUnderTest.AddMessage(It.IsAny<MessageDomainModel>());

                // Assert
                Assert.Equal(expected, result);
            }
        }

        [Theory]
        [MemberData(nameof(DefaultScope.AddMessageData_NotImplentedException), MemberType = typeof(DefaultScope))]
        [Trait("Category", nameof(Managers))]
        public void AddMessage_NotImplementedException(MessageEntity message, int expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange
                scope.MapperMock.Setup(x => x.Map<MessageEntity>(It.IsAny<MessageDomainModel>())).Returns(message);
                scope.MessageRepositoryMock.Setup(x => x.Add(It.IsAny<MessageEntity>())).Throws<NotImplementedException>();

                // Act
                var result = scope.InstanceUnderTest.AddMessage(It.IsAny<MessageDomainModel>());

                // Assert
                Assert.Equal(expected, result);
            }
        }

        private class DefaultScope : DisposableTestScope<IHelloWorldManager>
        {
            public DefaultScope()
            {
                MapperMock = new Mock<IMapper>();
                AppSettingsMock = new Mock<IOptions<AppSettingsConfig>>();
                MessageRepositoryMock = new Mock<IMessageRepository>();

                InstanceUnderTest = new HelloWorldManager(MapperMock.Object, AppSettingsMock.Object, MessageRepositoryMock.Object);
            }

            public Mock<IMapper> MapperMock { get; set; }
            public Mock<IOptions<AppSettingsConfig>> AppSettingsMock { get; set; }
            public Mock<IMessageRepository> MessageRepositoryMock { get; set; }

            public static IEnumerable<object[]> GetMessageData =>
                new List<object[]>
                {
                    new object[]
                    {
                        new AppSettingsConfig
                        {
                            GetMessageEndpoint = null,
                            MessageToSend = "Hello World!",
                            WriteToConsole = null
                        },
                        new MessageDomainModel
                        {
                            Message = "Hello World!"
                        },
                        "Hello World!"
                    }
                };

            public static IEnumerable<object[]> AddMessageData =>
                new List<object[]>
                {
                    new object[]
                    {
                        new MessageEntity
                        {
                            MessageId = Guid.NewGuid(),
                            Message = "Hello World!"
                        },
                        1,
                        1
                    }
                };

            public static IEnumerable<object[]> AddMessageData_NotImplentedException =>
                new List<object[]>
                {
                    new object[]
                    {
                        new MessageEntity
                        {
                            MessageId = Guid.NewGuid(),
                            Message = "Hello World!"
                        },
                        0
                    }
                };
        }
    }
}