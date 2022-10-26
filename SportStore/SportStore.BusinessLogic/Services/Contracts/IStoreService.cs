using System;
using SportStore.Common.ModelDto;

namespace SportStore.BusinessLogic.Services
{
    public interface IStoreService
    {
        List<ClothesStoreDto> Get();
    }
}

