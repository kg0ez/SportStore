using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportStore.Common.ModelDto;
using SportStore.Models;
using SportStore.Models.ModelsDB;

namespace SportStore.BusinessLogic.Services
{
    public class BasketService: IBasketService
    {
        private readonly SportStoreContext _context;
        private readonly IMapper _mapper;

        public BasketService(SportStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(int goodsId)
        {
            var basket = new Basket { ClothesId = goodsId };

            _context.Baskets.Add(basket);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var basket = _context.Baskets.FirstOrDefault(b => b.Id == id)!;

            _context.Baskets.Remove(basket);
            return _context.SaveChanges() > 0 ? true : false;
        }
        public int GetIdItem(int id)
        {
            var itemId = _context.Baskets.FirstOrDefault(b => b.Id == id)!.ClothesId;
            return itemId;
        }
        public List<BasketDto> Get()
        {
            var basket = _context.Baskets
                .Include(b => b.Clothes)
                .AsNoTracking()
                .ToList();

            var basketDto = _mapper.Map<List<BasketDto>>(basket);

            return basketDto;
        }
    }
}

