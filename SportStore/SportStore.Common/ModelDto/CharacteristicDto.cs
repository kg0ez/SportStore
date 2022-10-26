using System;
namespace SportStore.Common.ModelDto
{
    public class CharacteristicDto
    {
        public string Season { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Composition { get; set; } = null!;
        public string TypeSize { get; set; } = null!;
        public string Description { get; set; } = null!;

        //public ClothesDto Clothes { get; set; }
    }
}

