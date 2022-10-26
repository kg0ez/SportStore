using System;
using System.Text.Json;
using SportStore.BusinessLogic.Services;
using SportStore.Common.ModelDto;

namespace SportStore.Serv.Services
{
    public class HistoryJService: IHistoryJService
    {
        private readonly IHistoryService _historyService;

        public HistoryJService(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public string Delete(string json)
        {
            var id = JsonSerializer.Deserialize<int>(json);

            var result = _historyService.Delete(id);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }

        public string Get()
        {
            var history = _historyService.Get();

            var response = JsonSerializer.Serialize<List<HistoryDto>>(history);

            return response;
        }

        public string SyncClothes(string json)
        {
            var goodsId = JsonSerializer.Deserialize<int>(json);

            var result = _historyService.SyncGoods(goodsId);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }
    }
}

