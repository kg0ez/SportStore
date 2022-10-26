using System;
namespace SportStore.Models.ModelsDB
{
    public class ClothesStore
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public int ClothesId { get; set; }
        public Clothes Clothes { get; set; }
    }
}

