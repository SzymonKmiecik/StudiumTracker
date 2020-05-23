using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudiumTracker.Data;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbManipulation<Student> _repository;

        public StudentsController(IDbManipulation<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var studentItems = _repository.GetAll();

            return Ok(studentItems);
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var studentItem = _repository.GetById(id);
            if (studentItem != null)
                return Ok(studentItem);
            return NotFound();
        }

        //[HttpPost]
        //public ActionResult<Student> CreateStudent(Student student)
        //{
        //    _repository.Create(student);
        //    _repository.SaveChanges();

        //    //return CreatedAtRoute(nameof(GetStudentById), new { Id = student.Id }, student);
        //    return Ok();
        //}
    }
}