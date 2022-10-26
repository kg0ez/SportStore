using System;
namespace SportStore.Serv.Services
{
    public interface IGoodsJService
    {
        string Get();
        string Get(int Id);
    }
}

