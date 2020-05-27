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
    public class RoomsController : ControllerBase
    {
        private readonly IDbManipulation<Room> _repository;
        private readonly IMapper _mapper;

        public RoomsController(IDbManipulation<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> GetAllRooms()
        {
            var roomItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<RoomDto>>(roomItems));
        }


        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<Room> GetRoomById(int id)
        {
            var roomItem = _repository.GetById(id);
            if (roomItem != null)
                return Ok(_mapper.Map<RoomDto>(roomItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<RoomDto> CreateRoom(RoomDto roomDto)
        {
            var roomModel = _mapper.Map<Room>(roomDto);


            _repository.Create(roomModel);
            _repository.SaveChanges();

            var roomCreatedDto = _mapper.Map<RoomDto>(roomModel);

            return CreatedAtRoute(nameof(GetRoomById), new { Id = roomModel.Id }, roomCreatedDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoom(int id, RoomDto roomDto)
        {
            var roomModelFromRepo = _repository.GetById(id);
            if (roomModelFromRepo == null)
                return NotFound();

            _mapper.Map(roomDto, roomModelFromRepo);
            roomModelFromRepo.Id = id;
            _repository.Update(roomModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(int id)
        {
            var roomModelFromRepo = _repository.GetById(id);
            if (roomModelFromRepo == null)
                return NotFound();

            _repository.Delete(roomModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}