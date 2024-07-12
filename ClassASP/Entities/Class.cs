using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassASP.Entities
{
    [Table("Class")]
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int StudentCount { get; set; }
        public DateTime? CreatedCl { get; set; }
        public DateTime? UpdatedCl { get; set; }
    }
}
