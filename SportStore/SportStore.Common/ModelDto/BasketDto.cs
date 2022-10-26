using System;
namespace SportStore.Common.ModelDto
{
    public class BasketDto
    {
        public int Id { get; set; }

        public int ClothesId { get; set; }
        public ClothesDto Clothes { get; set; }
    }
}

