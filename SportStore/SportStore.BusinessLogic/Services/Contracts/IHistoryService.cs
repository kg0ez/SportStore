using System;
using SportStore.Common.ModelDto;

namespace SportStore.BusinessLogic.Services
{
    public interface IHistoryService
    {
        bool SyncGoods(int goodsId);
        List<HistoryDto> Get();
        bool Delete(int Id);
    }
}

