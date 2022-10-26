using System;
using SportStore.Common.ModelDto;

namespace SportStore.BusinessLogic.Services
{
    public interface IGoodsService
    {
        void Sync();
        List<ClothesDto> Get();
        ClothesDto Get(int Id);
    }
}

