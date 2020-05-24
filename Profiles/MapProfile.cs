using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudiumTracker.Dtos;
using StudiumTracker.Models;

namespace StudiumTracker.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Domain to Dto
            CreateMap<Student, StudentDto>();
            CreateMap<Lecturer, LecturerDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<Course, CourseDto>();

            //Dto to Domain
            CreateMap<StudentDto, Student>();
            CreateMap<LecturerDto, Lecturer>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<RoomDto, Room>();
            CreateMap<CourseDto, Course>();
        }
    }
}
