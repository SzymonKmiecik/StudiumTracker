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
    public class LecturersController : ControllerBase
    {
        private readonly IDbManipulation<Lecturer> _repository;
        private readonly IMapper _mapper;

        public LecturersController(IDbManipulation<Lecturer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LecturerDto>> GetAllLecturers()
        {
            var lecturerItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<LecturerDto>>(lecturerItems));
        }


        [HttpGet("{id}", Name = "GetLecturerById")]
        public ActionResult<Lecturer> GetLecturerById(int id)
        {
            var lecturerItem = _repository.GetById(id);
            if (lecturerItem != null)
                return Ok(_mapper.Map<LecturerDto>(lecturerItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<LecturerDto> CreateLecturer(LecturerDto lecturerDto)
        {
            var lecturerModel = _mapper.Map<Lecturer>(lecturerDto);
            var rand = new Random();
            lecturerModel.EmployeeId = rand.Next(100000, 1000000);

            //TODO EmployeeId Identity

            _repository.Create(lecturerModel);
            _repository.SaveChanges();

            var lecturerCreatedDto = _mapper.Map<LecturerDto>(lecturerModel);

            return CreatedAtRoute(nameof(GetLecturerById), new { Id = lecturerModel.Id }, lecturerCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLecturer(int id, LecturerDto lecturerDto)
        {
            var lecturerModelFromRepo = _repository.GetById(id);
            if (lecturerModelFromRepo == null)
                return NotFound();

            _mapper.Map(lecturerDto, lecturerModelFromRepo);
            lecturerModelFromRepo.Id = id;
            _repository.Update(lecturerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteLecturer(int id)
        {
            var lecturerModelFromRepo = _repository.GetById(id);
            if (lecturerModelFromRepo == null)
                return NotFound();

            _repository.Delete(lecturerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}