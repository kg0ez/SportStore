using System;
using SportStore.BusinessLogic.Services;
using System.Text.Json;
using SportStore.Common.ModelDto;

namespace SportStore.Serv.Services
{
    public class StoreJService: IStoreJService
    {
        private readonly IStoreService _storeService;

        public StoreJService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public string Get()
        {
            var store = _storeService.Get();

            var response = JsonSerializer.Serialize<List<ClothesStoreDto>>(store);

            return response;
        }
    }
}

