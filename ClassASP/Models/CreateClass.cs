using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassASP.Models
{
    public class CreateClass
    {
        [Required]
        [JsonRequired]
        [StringLength(100)]
        public string ClassName { get; set; }
        [Required]
        public int StudentCount { get; set; }
    }
}
