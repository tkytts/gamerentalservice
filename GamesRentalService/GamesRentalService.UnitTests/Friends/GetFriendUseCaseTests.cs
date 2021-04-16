using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Profiles;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesRentalService.UnitTests.Friends
{
    [TestClass]
    public class GetFriendUseCaseTests
    {
        [TestMethod]
        public async Task TestNotFound()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var rentalRepositoryMock = new Mock<IRentalRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new GetFriendUseCase(friendRepositoryMock.Object, rentalRepositoryMock.Object, mapper);
            var id = 1;
            
            // Act
            await useCase.Execute(id);

            // Assert
            friendRepositoryMock.Verify(r => r.GetAsync(id), Times.Once());
            rentalRepositoryMock.Verify(r => r.GetGamesRentedByFriend(id), Times.Never());
        }

        [TestMethod]
        public async Task TestFound()
        {
            // Arrange
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var rentalRepositoryMock = new Mock<IRentalRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new GetFriendUseCase(friendRepositoryMock.Object, rentalRepositoryMock.Object, mapper);
            var id = 1;

            friendRepositoryMock.Setup(x => x.GetAsync(id)).ReturnsAsync(new Friend
            {
                Id = id
            });

            rentalRepositoryMock.Setup(x => x.GetGamesRentedByFriend(id)).ReturnsAsync(new List<Game>
            {
                new Game
                {
                    Id = 1
                }
            });

            // Act
            await useCase.Execute(id);

            // Assert
            friendRepositoryMock.Verify(r => r.GetAsync(id), Times.Once());
            rentalRepositoryMock.Verify(r => r.GetGamesRentedByFriend(id), Times.Once());
        }
    }
}
