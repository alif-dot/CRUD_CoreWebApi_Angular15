using System.ComponentModel.DataAnnotations;

namespace CRUDinCoreAngular.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Batch { get; set; }
    }
}
