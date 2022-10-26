using System;
using SportStore.Common.ModelDto;

namespace SportStore.BusinessLogic.Services
{
    public interface IBasketService
    {
        bool Add(int goodsId);
        bool Delete(int id);
        List<BasketDto> Get();
        int GetIdItem(int id);
    }
}

