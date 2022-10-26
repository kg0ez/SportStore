using System;
namespace SportStore.Serv.Services
{
    public interface IBasketJService
    {
        string Add(int goodsId);
        string Delete(int id);
        string Get();
        string GetIdItem(int id);
    }
}

