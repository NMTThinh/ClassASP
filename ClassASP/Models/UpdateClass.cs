using System.ComponentModel.DataAnnotations;

namespace ClassASP.Models
{
    public class UpdateClass
    {
        [StringLength(100)]
        public string? ClassName { get; set; }
       
        public int? StudentCount { get; set; }
    }
}
