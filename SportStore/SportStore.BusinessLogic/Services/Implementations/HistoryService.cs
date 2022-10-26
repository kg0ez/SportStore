using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportStore.Common.ModelDto;
using SportStore.Models;
using SportStore.Models.ModelsDB;

namespace SportStore.BusinessLogic.Services
{
    public class HistoryService: IHistoryService
    {
        private readonly SportStoreContext _context;
        private readonly IMapper _mapper;

        public HistoryService(SportStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<HistoryDto> Get()
        {
            var histories = _context.Histories
                .AsNoTracking()
                .ToList();

            var historiesDto = _mapper.Map<List<HistoryDto>>(histories);

            return historiesDto;
        }

        public bool SyncGoods(int goodsId)
        {
            var clothesStores = _context.ClothesStores
                .FirstOrDefault(cs => cs.ClothesId == goodsId);

            if (clothesStores is null || clothesStores.Amount < 0)
                return false;

            clothesStores.Amount = clothesStores.Amount - 1;

            var clothes = _context.GetClothes
                .AsNoTracking()
                .FirstOrDefault(gc => gc.Id == goodsId);

            if (clothes is null)
                return false;

            var history = new History
            {
                Name = clothes.Model,
                Price = clothes.Cost,
                Img = clothes.Img
            };

            _context.Histories.Add(history);
            _context.ClothesStores.Update(clothesStores);
            return Save();
        }
        

        public bool Delete(int id)
        {
            var hirstory = _context.Histories.FirstOrDefault(h => h.Id == id);

            if (hirstory is null)
                return false;

            _context.Histories.Remove(hirstory);

            return Save();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

