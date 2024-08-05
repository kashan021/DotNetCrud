using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codefirstASPCore6.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Standard { get; set; }

        [Required]
        public int age { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }


}
