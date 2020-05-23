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
        private SqlDbManipulation<Student> _repository;

        public StudentsController(SqlDbManipulation<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var studentItems = _repository.GetAll();

            return Ok(studentItems);
        }
    }
}