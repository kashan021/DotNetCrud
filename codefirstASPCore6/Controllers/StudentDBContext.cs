using codefirstASPCore6.Models;
using Microsoft.EntityFrameworkCore;

namespace codefirstASPCore6.Controllers
{
    public class StudentDBContext :DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
