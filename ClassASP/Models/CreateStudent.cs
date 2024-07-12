using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassASP.Models
{
    public class CreateStudent
    {
        [Required]
        [JsonRequired]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [JsonRequired]
        [StringLength(100)]
        public string FirstMidName { get; set; }
        
        [Required]
        public int ClassID { get; set; }
    }
}
