using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUsingCore.Models
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int? id);
        Task DeleteStudent(int? id);

    }
}
