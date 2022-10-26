using System;
using System.Text.Json;
using SportStore.Common;

namespace SportStore.Serv.Services
{
    public class ActionClientService: IActionClientService
    {
        private readonly IGoodsJService _goodsJService;
        private readonly IBasketJService _basketJService;
        private readonly IStoreJService _storeJService;
        private readonly IHistoryJService _historyJService;


        public ActionClientService(IGoodsJService goodsJService, IBasketJService basketJService,
            IStoreJService storeJService, IHistoryJService historyJService)
        {
            _goodsJService = goodsJService;
            _basketJService = basketJService;
            _storeJService = storeJService;
            _historyJService = historyJService;
        }

        public string Basket(QueryBasketType query, string obj)
        {
            if (query == QueryBasketType.Get)
                return _basketJService.Get();

            var id = JsonSerializer.Deserialize<int>(obj);

            if (query == QueryBasketType.Add)
                return _basketJService.Add(id);

            else if (query == QueryBasketType.Delete)
                return _basketJService.Delete(id);

            else if (query == QueryBasketType.GetIdItem)
                return _basketJService.GetIdItem(id);

            throw new Exception("Basket method wasn`t found");
        }

        public string Clothes(QueryGoodsType query, string obj)
        {
            if (query == QueryGoodsType.GetGoods)
                return _goodsJService.Get();

            else if (query == QueryGoodsType.Get)
            {
                int carId = JsonSerializer.Deserialize<int>(obj);
                return _goodsJService.Get(carId);
            }
            throw new Exception("Clothes method wasn`t found");
        }

        public string History(QueryHistoryType query, string obj)
        {
            if (query == QueryHistoryType.Get)
                return _historyJService.Get();

            else if (query == QueryHistoryType.SyncGoods)
                return _historyJService.SyncClothes(obj);

            else if (query == QueryHistoryType.Delete)
                return _historyJService.Delete(obj);

            throw new Exception("History method wasn`t found");
        }

        public string Store(QueryStoreType query, string obj)
        {
            if (query == QueryStoreType.Get)
                return _storeJService.Get();

            throw new Exception("Store method wasn`t found");
        }
    }
}

