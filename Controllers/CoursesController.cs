using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudiumTracker.Data;
using StudiumTracker.Dtos;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IDbManipulation<Course> _repository;
        private readonly IMapper _mapper;

        public CoursesController(IDbManipulation<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courseItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courseItems));
        }


        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var courseItem = _repository.GetById(id);
            if (courseItem != null)
                return Ok(_mapper.Map<CourseDto>(courseItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CourseDto> CreateCourse(CourseDto courseDto)
        {
            var courseModel = _mapper.Map<Course>(courseDto);


            _repository.Create(courseModel);
            _repository.SaveChanges();

            var courseCreatedDto = _mapper.Map<CourseDto>(courseModel);

            return CreatedAtRoute(nameof(GetCourseById), new { Id = courseModel.Id }, courseCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, CourseDto CourseDto)
        {
            var courseModelFromRepo = _repository.GetById(id);
            if (courseModelFromRepo == null)
                return NotFound();

            _mapper.Map(CourseDto, courseModelFromRepo);
            courseModelFromRepo.Id = id;
            _repository.Update(courseModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var courseModelFromRepo = _repository.GetById(id);
            if (courseModelFromRepo == null)
                return NotFound();

            _repository.Delete(courseModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}