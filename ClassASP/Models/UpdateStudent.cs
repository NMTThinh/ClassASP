using System.ComponentModel.DataAnnotations;

namespace ClassASP.Models
{
    public class UpdateStudent
    {
        [StringLength(100)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string? FirstMidName { get; set; }

        public int? ClassID { get; set; }
    }
}
