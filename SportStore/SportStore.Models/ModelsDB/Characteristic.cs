using System;
using System.Runtime.ConstrainedExecution;

namespace SportStore.Models.ModelsDB
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Season { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Composition { get; set; } = null!;
        public string TypeSize { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Clothes Clothes { get; set; }
    }
}

