using System;
namespace SportStore.Common.ModelDto
{
    public class ClothesStoreDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public int ClothesId { get; set; }
        public ClothesDto Clothes { get; set; }
    }
}

