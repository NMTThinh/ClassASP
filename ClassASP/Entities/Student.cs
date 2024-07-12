using System.ComponentModel.DataAnnotations.Schema;

namespace ClassASP.Entities
{
    [Table("Student")]
    public class Student
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName  { get; set; }
        public DateTime? CreatedSt { get; set; }
        public DateTime? UpdatedSt { get; set; }
    }
}
