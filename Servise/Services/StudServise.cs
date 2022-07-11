using Grpc.Core;
using StudentService;
using StudentsServise.StudentsData;
using StudentsServise.Models;


namespace StudentsServise.Services;

public class StudServise : RemoteStudent.RemoteStudentBase
 {
      private readonly ILogger<StudServise> _logger;
         private readonly StudentDataContext _context;

       public StudServise(ILogger<StudServise> logger, StudentDataContext context)
        {
             _logger = logger;
            _context = context;
         }


       public override Task<StudentFindModel> GetStudentInfo(StudentDataModel request, ServerCallContext context)
         {
             StudentFindModel output = new StudentFindModel();

            var student = _context.Students.Find(request.StudentId);

             _logger.LogInformation("Отправка ответа");

            if (student != null)
            {
                 output.StudentId = student.StudentId;
                 output.FirstName = student.FirstName;
                 output.LastName = student.LastName;
                output.Email = student.Email;
             }

             return Task.FromResult(output);
         }
         public override Task<Reply> InsertStudent(StudentFindModel request, ServerCallContext context)
         {
             var s = _context.Students.Find(request.StudentId);

            if (s != null)
            {
                 return Task.FromResult(
                   new Reply()
                   {
                       Result = $"Студент {request.FirstName} {request.LastName} уже существует.",
                       IsOk = false
                   }
                );
            }

             Student student = new Student()
             {
                 StudentId = request.StudentId,
                 FirstName = request.FirstName,
                 LastName = request.LastName,
                 Email = request.Email,
            };

             _logger.LogInformation("Вставить студента");

            try
            {
                 _context.Students.Add(student);
                 var returnVal = _context.SaveChanges();
            }
             catch (Exception ex)
             {
                 _logger.LogInformation(ex.ToString());
             }

             return Task.FromResult(
                new Reply()
                {
                    Result = $"Студент {request.FirstName} {request.LastName}  был успешно добавлен.",
                    IsOk = true 
                }
             );
         }

         public override Task<Reply> UpdateStudent(StudentFindModel request, ServerCallContext context)
         {
             var s = _context.Students.Find(request.StudentId);

             if (s == null)
             {
                 return Task.FromResult(
                  new Reply()
                  {
                      Result = $"Студент {request.FirstName} {request.LastName} Не найден.",
                       IsOk = false
                  }
                 );
             }

             s.FirstName = request.FirstName;
             s.LastName = request.LastName;
             s.Email = request.Email;

             _logger.LogInformation("Обновить студента");

             try
             {
                 var returnVal = _context.SaveChanges();
             }
             catch (Exception ex)
             {
                 _logger.LogInformation(ex.ToString());
             }

             return Task.FromResult(
                new Reply()
                {
                    Result = $"Студент {request.FirstName} {request.LastName} был успешно обновлен.",
                    IsOk = true
                }
             );
         }

         public override Task<Reply> DeleteStudent(StudentDataModel request, ServerCallContext context)
         {
             var s = _context.Students.Find(request.StudentId);

             if (s == null)
             {
                 return Task.FromResult(
                   new Reply()
                   {
                       Result = $"Студент с номером {request.StudentId} Не найден.",
                       IsOk = false
                   }
                );
             }

             _logger.LogInformation("Удалить студента");

             try
             {
                 _context.Students.Remove(s);
                 var returnVal = _context.SaveChanges();
             }
             catch (Exception ex)
             {
                 _logger.LogInformation(ex.ToString());
             }

             return Task.FromResult(
                new Reply()
                {
                    Result = $"Студент с номером {request.StudentId} был успешно удален.",
                    IsOk = true
                }
             );
         }

         public override Task<StudentList> RetrieveAllStudents(Empty request, ServerCallContext context)
         {
             _logger.LogInformation("Получить всех студентов");

             StudentList list = new StudentList();

             try
             {
                 List<StudentFindModel> studentList = new List<StudentFindModel>();

                 var students = _context.Students.ToList();

                 foreach (var c in students)
                 {
                     studentList.Add(new StudentFindModel()
                     {
                         StudentId = c.StudentId,
                         FirstName = c.FirstName,
                         LastName = c.LastName,
                         Email = c.Email,
                     });
                 }

                 list.Items.AddRange(studentList);
             }
             catch (Exception ex)
             {
                 _logger.LogInformation(ex.ToString());
             }

             return Task.FromResult(list);
         }
}