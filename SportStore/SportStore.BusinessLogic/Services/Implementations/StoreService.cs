using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportStore.Common.ModelDto;
using SportStore.Models;

namespace SportStore.BusinessLogic.Services
{
    public class StoreService: IStoreService
    {
        private readonly SportStoreContext _context;
        private readonly IMapper _mapper;

        public StoreService(SportStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ClothesStoreDto> Get()
        {
            var clothesStore = _context.ClothesStores
                .Include(cs => cs.Clothes)
                .AsNoTracking()
                .ToList();

            var clothesStoreDto = _mapper.Map<List<ClothesStoreDto>>(clothesStore);

            return clothesStoreDto;
        }
    }
}

