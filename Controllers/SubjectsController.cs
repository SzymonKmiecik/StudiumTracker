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
    public class SubjectsController : ControllerBase
    {
        private readonly IDbManipulation<Subject> _repository;
        private readonly IMapper _mapper;

        public SubjectsController(IDbManipulation<Subject> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectDto>> GetAllSubjects()
        {
            var subjectItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(subjectItems));
        }


        [HttpGet("{id}", Name = "GetSubjectById")]
        public ActionResult<Subject> GetSubjectById(int id)
        {
            var subjectItem = _repository.GetById(id);
            if (subjectItem != null)
                return Ok(_mapper.Map<SubjectDto>(subjectItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<SubjectDto> CreateSubject(SubjectDto subjectDto)
        {
            var subjectModel = _mapper.Map<Subject>(subjectDto);
            

            _repository.Create(subjectModel);
            _repository.SaveChanges();

            var subjectCreatedDto = _mapper.Map<SubjectDto>(subjectModel);

            return CreatedAtRoute(nameof(GetSubjectById), new { Id = subjectModel.Id }, subjectCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSubject(int id, SubjectDto subjectDto)
        {
            var subjectModelFromRepo = _repository.GetById(id);
            if (subjectModelFromRepo == null)
                return NotFound();

            _mapper.Map(subjectDto, subjectModelFromRepo);
            subjectModelFromRepo.Id = id;
            _repository.Update(subjectModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteSubject(int id)
        {
            var subjectModelFromRepo = _repository.GetById(id);
            if (subjectModelFromRepo == null)
                return NotFound();

            _repository.Delete(subjectModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}