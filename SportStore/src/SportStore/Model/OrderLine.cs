
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class OrderLine : CartLine
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}