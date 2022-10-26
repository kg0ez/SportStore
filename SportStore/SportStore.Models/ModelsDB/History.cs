using System;
namespace SportStore.Models.ModelsDB
{
    public class History
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; } = DateTime.Now;
    }
}

