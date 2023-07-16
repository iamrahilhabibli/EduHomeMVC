using EduHome.Core.Entities.Common;

namespace EduHome.Core.Entities
{
    public class ProductEntity:BaseEntity
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
