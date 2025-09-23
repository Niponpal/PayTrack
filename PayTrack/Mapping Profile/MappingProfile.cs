using AutoMapper;
using WebApplication1.Models;

namespace PayTrack.Mapping_Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Employee mapping
            CreateMap<Employee, Employee>().ReverseMap();

            // Attendance mapping
            CreateMap<Attendance, Attendance>().ReverseMap();

            // Leave mapping
            CreateMap<Leave, Leave>().ReverseMap();

            // Payroll mapping
            CreateMap<Payroll, Payroll>().ReverseMap();

            // SalaryComponent mapping
            CreateMap<SalaryComponent, SalaryComponent>().ReverseMap();

            // Users mapping
            CreateMap<AppUser, AppUser>().ReverseMap();

            // Notification mapping
            CreateMap<Notification, Notification>().ReverseMap();
        }
    }
}
