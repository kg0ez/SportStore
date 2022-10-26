using System;
namespace SportStore.Serv.Services
{
    public interface IHistoryJService
    {
        string Delete(string json);
        string SyncClothes(string json);
        string Get();
    }
}

