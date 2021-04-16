using AutoMapper;
using FluentAssertions;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.Profiles;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesRentalService.UnitTests.Friends
{
    [TestClass]
    public class GetPaginatedFriendsUseCaseTests
    {
        private static List<Friend> GetMockedFriends(int numberOfEntries)
        {
            var mockedFriends = new List<Friend>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                mockedFriends.Add(new Friend
                {
                    Id = numberOfEntries,
                    Name = string.Empty,
                    Address = string.Empty,
                    BirthDate = DateTime.Now
                });
            }

            return mockedFriends;
        }

        [TestMethod]
        public async Task Execute_Success()
        {
            // Arrange
            var friendsNumber = new Random().Next(0, 20);
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var rentalRepositoryMock = new Mock<IRentalRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new GetPaginatedFriendsUseCase(friendRepositoryMock.Object, rentalRepositoryMock.Object, mapper);
            var paginationParameters = new PaginationParameters
            {
                PageNumber = 1,
                PageSize = 20
            };

            var mockedFriends = new List<Friend>();
            mockedFriends.AddRange(GetMockedFriends(friendsNumber));

            friendRepositoryMock.Setup(r => r.GetAll()).Returns(mockedFriends.AsQueryable());
            rentalRepositoryMock.Setup(r => r.GetRentalsByFriends(It.IsAny<IEnumerable<int>>())).ReturnsAsync(new List<Rental>());
            // Act
            var result = await useCase.Execute(paginationParameters);

            // Asert
            result.RowCount.Should().Be(friendsNumber);
        }

        [TestMethod]
        public async Task Execute_TwoPages_Success()
        {
            var friendsNumber = new Random().Next(21, 40);
            var friendRepositoryMock = new Mock<IFriendRepository>();
            var rentalRepositoryMock = new Mock<IRentalRepository>();
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();
            var useCase = new GetPaginatedFriendsUseCase(friendRepositoryMock.Object, rentalRepositoryMock.Object, mapper);
            var paginationParameters = new PaginationParameters
            {
                PageNumber = 1,
                PageSize = 20
            };

            var mockedFriends = new List<Friend>();
            mockedFriends.AddRange(GetMockedFriends(friendsNumber));

            friendRepositoryMock.Setup(r => r.GetAll()).Returns(mockedFriends.AsQueryable());
            rentalRepositoryMock.Setup(r => r.GetRentalsByFriends(It.IsAny<IEnumerable<int>>())).ReturnsAsync(new List<Rental>());
            // Act
            var result = await useCase.Execute(paginationParameters);

            // Asert
            result.PageCount.Should().Be(2);
        }
    }
}
