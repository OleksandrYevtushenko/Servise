using Microsoft.EntityFrameworkCore;
using StudentsServise.Models;



namespace StudentsServise.StudentsData;

public class StudentDataContext : DbContext
{
    public StudentDataContext (DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        builder.Entity<Student>().HasData(
            GetStudents()
        );
    }

    public DbSet<Student> Students { get; set; }

    private static List<Student> GetStudents()
    {
        List<Student> students = new List<Student>() {
            new Student() {    
                StudentId = 1,
                FirstName="Oleksandr",
                LastName="Yevtushenko",
                Email= "yevtushenko@gmail.com",
                
            },
            new Student() {    
                StudentId = 2,
                FirstName="Viktor",
                LastName="Kozhyn",
                Email= "kozhyn@gmail.com",
                
            },
            new Student() {    
                StudentId= 3,
                FirstName="Mykola",
                LastName="Karpenko",
                Email= "karpenko@gmail.com",
            },
            new Student() {    
                StudentId= 4,
                FirstName="Roman",
                LastName="Shyrin",
                Email= "shyrin@gmail.com",
            },
            new Student() {    
                StudentId= 5,
                FirstName="Nyna",
                LastName="Vyzir",
                Email= "vyzir@gmail.com",
            },
        };

        return students;
    }
}