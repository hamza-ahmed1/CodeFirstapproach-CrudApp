using Microsoft.EntityFrameworkCore;

namespace CodeFirstapproach_CrudApp.Models
{
    public class student_Db_context:DbContext
    {
        public student_Db_context(DbContextOptions options):base(options)
        {
              
        }
        public DbSet<StudentModel> Students { get; set; }  //represents our table
    }
}
