using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MvcDemo4.BL.Models;
using MvcDemo4.DAL.Entity;

namespace MvcDemo4.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM , Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryViewModel>();
            CreateMap<CountryViewModel, Country>();

            CreateMap<District, DistrictViewModel>();
            CreateMap<DistrictViewModel, District>();


            CreateMap<City, CityViewModel>();
            CreateMap<CityViewModel, City>();

            CreateMap<Trainer, TrainerViewModel>();
            CreateMap<TrainerViewModel, Trainer>();

            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();




        }

    }
}
