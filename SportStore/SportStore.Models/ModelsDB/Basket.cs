using System;
namespace SportStore.Models.ModelsDB
{
    public class Basket
    {
        public int Id { get; set; }

        public int ClothesId { get; set; }
        public Clothes Clothes { get; set; }
    }
}

