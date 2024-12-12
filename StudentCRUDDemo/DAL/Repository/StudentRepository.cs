using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCRUDDemo.Models;

namespace StudentCRUDDemo.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly StudentDbContext _dbContext;
        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(Student student)
        {
            _dbContext.students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var std = _dbContext.students.Find(id);
            if (std != null)
            {
                _dbContext.students.Remove(std);
                _dbContext.SaveChanges();
            }
            
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _dbContext.students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.students.Find(id);
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}