using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudiumTracker.Data;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IDbManipulation<StudentCourse> _repository;
        //private readonly IDbManipulation<Student> _studentRepository;
        //private readonly IDbManipulation<Course> _courseRepository;
        private readonly ApplicationDbContext _context; 

        public StudentCoursesController(IDbManipulation<StudentCourse> repository, IDbManipulation<Course> course, IDbManipulation<Student> student, ApplicationDbContext context)
        {
            _repository = repository;
            //_courseRepository = course;
            //_studentRepository = student;
            _context = context;
        }

        // POST api/StudentCourse/1/addStudent/1
        [HttpPost]
        public ActionResult AddStudentToCourse([FromBody] JsonElement data)
        {
            //var courseModelFromRepo = _courseRepository.GetById(courseId);
            //if (courseModelFromRepo == null)
            //    return NotFound();

            //var studentModelFromRepo = _studentRepository.GetById(studentId);
            //if (courseModelFromRepo == null)
            //    return NotFound();

            //var studentToCourse = new StudentCourse
            //{
            //    CourseId = courseModelFromRepo.Id,
            //    StudentId = studentModelFromRepo.Id
            //};

            string json = System.Text.Json.JsonSerializer.Serialize(data);
            var result = new Regex(@"\d+").Matches(json)
                .Cast<Match>()
                .Select(m => Int32.Parse(m.Value))
                .ToArray();

            var courseModelFromRepo = _context.Courses.SingleOrDefault(c => c.Id == result[0]);
            if (courseModelFromRepo == null)
                return NotFound();

            var studentModelFromRepo = _context.Courses.SingleOrDefault(s => s.Id == result[1]);
            if (studentModelFromRepo == null)
                return NotFound();

            var studentToCourse = new StudentCourse
                {
                    CourseId = courseModelFromRepo.Id,
                    StudentId = studentModelFromRepo.Id
                };
            

            _repository.Create(studentToCourse);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}