using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SchoolManagement.Dtos;
using SchoolManagement.Models;

namespace SchoolManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<BoardOfDirector, BoardOfDirectorDto>();
            Mapper.CreateMap<BoardOfDirectorDto, BoardOfDirector > ().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Staff, StaffDto>();
            Mapper.CreateMap<StaffDto, Staff>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Teacher, TeacherDto>();
            Mapper.CreateMap<TeacherDto, Teacher>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Subject, SubjectDto>();
            Mapper.CreateMap<SubjectDto, Subject>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}