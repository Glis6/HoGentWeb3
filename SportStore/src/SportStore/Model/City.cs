using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SportsStore.Models
{
    public class City
    {
        [Key]
        public string Postalcode { get; set; }
        public string Name { get; set; }
    }
}