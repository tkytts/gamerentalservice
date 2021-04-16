using AutoMapper;
using GameRentalService.Domain.Entities;
using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<GameViewModel, Game>().ReverseMap();
            this.CreateMap<FriendViewModel, Friend>().ReverseMap();
            this.CreateMap<RentalViewModel, Rental>().ReverseMap();
        }
    }
}
