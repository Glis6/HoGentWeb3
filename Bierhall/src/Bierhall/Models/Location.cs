using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeerhallEF.Models
{
    public class Location
    {
        #region Properties
        [Key]
        public string PostalCode { get; set; }
        public string Name { get; set; }
        #endregion
       
    }
}
