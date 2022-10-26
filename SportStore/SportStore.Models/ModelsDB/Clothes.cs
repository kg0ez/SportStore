using System;
namespace SportStore.Models.ModelsDB
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Cost { get; set; }

        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }

        public ClothesStore ClothesStore { get; set; }
    }
}

