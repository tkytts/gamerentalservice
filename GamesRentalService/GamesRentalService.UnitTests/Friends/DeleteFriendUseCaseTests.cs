using AutoMapper;
using GameRentalService.Infrastructure.Profiles;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GamesRentalService.UnitTests.Friends
{
    [TestClass]
    public class DeleteFriendUseCaseTests
    {
        [TestMethod]
        public async Task TestSimpleExecution()
        {
            // Arrange
            var repositoryMock = new Mock<IFriendRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new DeleteFriendUseCase(repositoryMock.Object);
            var id = 1;
            // Act
            await useCase.Execute(id);

            // Assert
            repositoryMock.Verify(r => r.DeleteAsync(id), Times.Once());
        }
    }
}
