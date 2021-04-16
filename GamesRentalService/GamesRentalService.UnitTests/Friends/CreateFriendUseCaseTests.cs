using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Profiles;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GamesRentalService.UnitTests.Friends
{
    [TestClass]
    public class CreateFriendUseCaseTests
    {
        [TestMethod]
        public async Task TestSimpleExecution()
        {
            // Arrange
            var repositoryMock = new Mock<IFriendRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new CreateFriendUseCase(mapper, repositoryMock.Object);
            var friendViewModel = new FriendViewModel();

            // Act
            await useCase.ExecuteAsync(friendViewModel);

            // Assert
            repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Friend>()), Times.Once());
        }
    }
}
