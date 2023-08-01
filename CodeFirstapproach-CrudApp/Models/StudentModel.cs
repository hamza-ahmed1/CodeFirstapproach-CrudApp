using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstapproach_CrudApp.Models
{
    public class StudentModel
    {
        [Key]
        public int ID    { get; set; }
        [Column("Student_Name",TypeName ="varchar(30)")]
        public String? Name { get; set; }
        [Column("Student_Gender", TypeName = "varchar(10)")]
        public string? Gender { get; set; }
        //[Column("Student_Age",TypeName ="int")]
        public int Age { get; set; }
    }
}
