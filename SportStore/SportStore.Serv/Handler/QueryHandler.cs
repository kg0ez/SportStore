using System;
using SportStore.Common;
using System.Text.Json;
using SportStore.Serv.Services;

namespace SportStore.Serv.Handler
{
    public static class QueryHandler
    {
        public static string SearchType(
            ServQuery query,
            IActionClientService actionClient)
        {

            if (query.Type == QueryType.Goods)
            {
                var method = JsonSerializer.Deserialize<QueryGoodsType>(query.TypeAction);
                return actionClient.Clothes(method, query.Object);
            }
            else if (query.Type == QueryType.Basket)
            {
                var method = JsonSerializer.Deserialize<QueryBasketType>(query.TypeAction);
                return actionClient.Basket(method, query.Object);
            }
            else if (query.Type == QueryType.Store)
            {
                var method = JsonSerializer.Deserialize<QueryStoreType>(query.TypeAction);
                return actionClient.Store(method, query.Object);
            }
            else if (query.Type == QueryType.History)
            {
                var method = JsonSerializer.Deserialize<QueryHistoryType>(query.TypeAction);
                return actionClient.History(method, query.Object);
            }

            throw new Exception("Type method wasn`t found");
        }
    }
}

