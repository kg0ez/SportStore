using System;
using System.Reflection.PortableExecutable;

namespace SportStore.Common.ModelDto
{
    public class ClothesDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Cost { get; set; }

        public int CharacteristicId { get; set; }
        public CharacteristicDto Characteristic { get; set; }

        public SimpleClothesStore ClothesStore { get; set; }
    }
}

