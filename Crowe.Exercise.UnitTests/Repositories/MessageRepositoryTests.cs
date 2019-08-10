using Crowe.Exercise.Data.Contracts;
using Crowe.Exercise.Data.Entities;
using Crowe.Exercise.Data.Repositories;
using Crowe.Exercise.UnitTests.Helpers;
using Moq;
using System;
using Xunit;

namespace Crowe.Exercise.UnitTests.Repositories
{
    public class MessageRepositoryTests
    {
        [Theory]
        [InlineData("The method or operation is not implemented.")]
        [Trait("Category", nameof(Repositories))]
        public void Add(string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange / Act
                var ex = Assert.Throws<NotImplementedException>(() => scope.InstanceUnderTest.Add(It.IsAny<MessageEntity>()));

                // Assert
                Assert.Equal(expected, ex.Message);
            }
        }

        [Theory]
        [InlineData("The method or operation is not implemented.")]
        [Trait("Category", nameof(Repositories))]
        public void Delete(string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange / Act
                var ex = Assert.Throws<NotImplementedException>(() => scope.InstanceUnderTest.Delete(It.IsAny<MessageEntity>()));

                // Assert
                Assert.Equal(expected, ex.Message);
            }
        }

        [Theory]
        [InlineData("The method or operation is not implemented.")]
        [Trait("Category", nameof(Repositories))]
        public void GetAll(string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange / Act
                var ex = Assert.Throws<NotImplementedException>(() => scope.InstanceUnderTest.GetAll());

                // Assert
                Assert.Equal(expected, ex.Message);
            }
        }

        [Theory]
        [InlineData("The method or operation is not implemented.")]
        [Trait("Category", nameof(Repositories))]
        public void GetEntity(string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange / Act
                var ex = Assert.Throws<NotImplementedException>(() => scope.InstanceUnderTest.GetEntity(It.IsAny<string>()));

                // Assert
                Assert.Equal(expected, ex.Message);
            }
        }

        [Theory]
        [InlineData("The method or operation is not implemented.")]
        [Trait("Category", nameof(Repositories))]
        public void Update(string expected)
        {
            using (var scope = new DefaultScope())
            {
                // Arrange / Act
                var ex = Assert.Throws<NotImplementedException>(() => scope.InstanceUnderTest.Update(It.IsAny<MessageEntity>()));

                // Assert
                Assert.Equal(expected, ex.Message);
            }
        }

        [Fact]
        [Trait("Category", nameof(Repositories))]
        public void Dispose()
        {
            using (var scope = new DefaultScope())
            {
                scope.InstanceUnderTest.Dispose();
            }
        }

        private class DefaultScope : DisposableTestScope<IMessageRepository>
        {
            public DefaultScope()
            {
                DbContextMock = new Mock<IDbContext>();

                InstanceUnderTest = new MessageRepository(DbContextMock.Object);
            }

            public Mock<IDbContext> DbContextMock { get; set; }
        }
    }
}