using System;
using System.Text.Json;
using SportStore.BusinessLogic.Services;
using SportStore.Common.ModelDto;

namespace SportStore.Serv.Services
{
    public class GoodsJService: IGoodsJService
    {
        private readonly IGoodsService _goodsService;

        public GoodsJService(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        public string Get()
        {
            var goods = _goodsService.Get();

            var response = JsonSerializer.Serialize<List<ClothesDto>>(goods);

            return response;
        }

        public string Get(int Id)
        {
            var goods = _goodsService.Get(Id);

            var response = JsonSerializer.Serialize<ClothesDto>(goods);

            return response;
        }
    }
}

