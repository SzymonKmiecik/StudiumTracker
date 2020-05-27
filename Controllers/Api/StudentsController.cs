using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudiumTracker.Data;
using StudiumTracker.Dtos;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbManipulation<Student> _repository;
        private readonly IMapper _mapper;

        public StudentsController(IDbManipulation<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetAllStudents()
        {
            var studentItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(studentItems));
        }


        [HttpGet("{id}", Name="GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var studentItem = _repository.GetById(id);
            if (studentItem != null)
                return Ok(_mapper.Map<StudentDto>(studentItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent(StudentDto studentDto)
        {
            var studentModel = _mapper.Map<Student>(studentDto);
            var rand = new Random();
            studentModel.CardId = rand.Next(100000, 1000000);

            //TODO Identity cardID

            _repository.Create(studentModel);
            _repository.SaveChanges();

            var studentCreatedDto = _mapper.Map<StudentDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById), new { Id = studentModel.Id }, studentCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            var studentModelFromRepo = _repository.GetById(id);
            if (studentModelFromRepo == null)
                return NotFound();

            _mapper.Map(studentDto, studentModelFromRepo);
            studentModelFromRepo.Id = id;
            _repository.Update(studentModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentModelFromRepo = _repository.GetById(id);
            if (studentModelFromRepo == null)
                return NotFound();

            _repository.Delete(studentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}