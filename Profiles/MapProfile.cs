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

            //Dto to Domain
            CreateMap<StudentDto, Student>();
            CreateMap<LecturerDto, Lecturer>();
        }
    }
}
