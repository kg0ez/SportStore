using System;
using AutoMapper;
using SportStore.Common.ModelDto;
using SportStore.Models.ModelsDB;

namespace SportStore.BusinessLogic.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<History, HistoryDto>().ReverseMap();
            CreateMap<Characteristic, CharacteristicDto>().ReverseMap();
            CreateMap<Clothes, ClothesDto>().ReverseMap();
            CreateMap<ClothesStore, ClothesStoreDto>().ReverseMap();
            CreateMap<ClothesStore, SimpleClothesStore>().ReverseMap();
        }
    }
}

