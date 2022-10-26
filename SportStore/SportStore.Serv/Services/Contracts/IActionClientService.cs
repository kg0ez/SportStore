using System;
using SportStore.Common;

namespace SportStore.Serv.Services
{
    public interface IActionClientService
    {
        string Clothes(QueryGoodsType query, string obj);
        string Basket(QueryBasketType query, string obj);
        string Store(QueryStoreType query, string obj);
        string History(QueryHistoryType query, string obj);
    }
}

