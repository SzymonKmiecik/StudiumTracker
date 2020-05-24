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
    public class LecturersController : ControllerBase
    {
        private readonly IDbManipulation<Lecturer> _repository;
        private IMapper _mapper;

        public LecturersController(IDbManipulation<Lecturer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LecturerDto>> GetAllLecturers()
        {
            var LecturerItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<LecturerDto>>(LecturerItems));
        }


        [HttpGet("{id}", Name = "GetLecturerById")]
        public ActionResult<Lecturer> GetLecturerById(int id)
        {
            var LecturerItem = _repository.GetById(id);
            if (LecturerItem != null)
                return Ok(_mapper.Map<LecturerDto>(LecturerItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<LecturerDto> CreateLecturer(LecturerDto LecturerDto)
        {
            var LecturerModel = _mapper.Map<Lecturer>(LecturerDto);
            Random rand = new Random();
            LecturerModel.EmployeeId = rand.Next(100000, 1000000);

            //TODO Identity cardID

            _repository.Create(LecturerModel);
            _repository.SaveChanges();

            var LecturerCreatedDto = _mapper.Map<LecturerDto>(LecturerModel);

            return CreatedAtRoute(nameof(GetLecturerById), new { Id = LecturerModel.Id }, LecturerCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UptadeLecturer(int id, LecturerDto LecturerDto)
        {
            var LecturerModelFromRepo = _repository.GetById(id);
            if (LecturerModelFromRepo == null)
                return NotFound();

            _mapper.Map(LecturerDto, LecturerModelFromRepo);
            LecturerModelFromRepo.Id = id;
            _repository.Update(LecturerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteLecturer(int id)
        {
            var LecturerModelFromRepo = _repository.GetById(id);
            if (LecturerModelFromRepo == null)
                return NotFound();

            _repository.Delete(LecturerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}