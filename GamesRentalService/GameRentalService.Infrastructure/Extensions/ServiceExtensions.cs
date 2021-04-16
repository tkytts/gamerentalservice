using GameRentalService.Infrastructure.Repositories;
using GameRentalService.Infrastructure.UseCases.Games;
using GameRentalService.Infrastructure.UseCases.Games.Interfaces;
using GamesRentalService.Infrastructure.Repositories;
using GamesRentalService.Infrastructure.UseCases.Friends;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using GamesRentalService.Infrastructure.UseCases.Rentals;
using GamesRentalService.Infrastructure.UseCases.Rentals.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateGameUseCase, CreateGameUseCase>();
            services.AddScoped<IUpdateGameUseCase, UpdateGameUseCase>();
            services.AddScoped<IDeleteGameUseCase, DeleteGameUseCase>();
            services.AddScoped<IGetPaginatedGamesUseCase, GetPaginatedGamesUseCase>();
            services.AddScoped<IGetGameUseCase, GetGameUseCase>();

            services.AddScoped<ICreateFriendUseCase, CreateFriendUseCase>();
            services.AddScoped<IUpdateFriendUseCase, UpdateFriendUseCase>();
            services.AddScoped<IDeleteFriendUseCase, DeleteFriendUseCase>();
            services.AddScoped<IGetPaginatedFriendsUseCase, GetPaginatedFriendsUseCase>();
            services.AddScoped<IGetFriendUseCase, GetFriendUseCase>();

            services.AddScoped<IRentGameUseCase, RentGameUseCase>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
        }
    }
}
