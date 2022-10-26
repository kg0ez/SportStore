using System;
using System.Text.Json;
using SportStore.BusinessLogic.Services;
using SportStore.Common.ModelDto;

namespace SportStore.Serv.Services
{
    public class BasketJService: IBasketJService
    {
        private readonly IBasketService _basketService;

        public BasketJService(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public string Add(int goodsId)
        {
            var answer = _basketService.Add(goodsId);

            var response = JsonSerializer.Serialize<bool>(answer);

            return response;
        }

        public string Delete(int id)
        {
            var answer = _basketService.Delete(id);

            var response = JsonSerializer.Serialize<bool>(answer);

            return response;
        }

        public string Get()
        {
            var details = _basketService.Get();

            var response = JsonSerializer.Serialize<List<BasketDto>>(details);

            return response;
        }

        public string GetIdItem(int id)
        {
            var itemId = _basketService.GetIdItem(id);

            var response = JsonSerializer.Serialize<int>(itemId);

            return response;
        }
    }
}

