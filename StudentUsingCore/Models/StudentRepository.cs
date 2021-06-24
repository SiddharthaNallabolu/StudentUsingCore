using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentUsingCore.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db = null;
        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        //Create
        public async Task AddStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }
        //Read
        public async Task<List<Student>> GetAllStudents()
        {
            var lis = await _db.Students.ToListAsync();
            return lis;
        }

        public async Task<Student> GetStudentById(int? id)
        {
            Student student = await _db.Students.FindAsync(id);
            return student;
        }

        //Delete
        public async Task DeleteStudent(int? id)
        {
            Student student = await _db.Students.FindAsync(id);
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task SaveDetails()
        {
            await _db.SaveChangesAsync();
        }
        
    }
}
