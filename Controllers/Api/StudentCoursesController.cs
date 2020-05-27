using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudiumTracker.Data;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers.Api
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

        [HttpGet]
        public ActionResult Index()
        {
            return NoContent();
        }

        
        [HttpPost]
        public IActionResult Index(object data)
        {
            dynamic parsedData = JObject.Parse(data.ToString());
            int courseId = parsedData.courseId;
            int studentId = parsedData.studentId;
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

            //string json = System.Text.Json.JsonSerializer.Serialize(data);
            //var result = new Regex(@"\d+").Matches(json)
            //    .Cast<Match>()
            //    .Select(m => Int32.Parse(m.Value))
            //    .ToArray();

            //return View("~/Views/StudentCourses/Index.cshtml", data);

            var courseModelFromRepo = _context.Courses.SingleOrDefault(c => c.Id == courseId);
            if (courseModelFromRepo == null)
                return NotFound();

            var studentModelFromRepo = _context.Students.SingleOrDefault(s => s.Id == studentId);
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