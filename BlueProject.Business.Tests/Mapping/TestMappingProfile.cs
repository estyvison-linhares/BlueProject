using AutoMapper;
using BlueProject.Business.Dto;
using BlueProject.Domain.Entities;

namespace BlueProject.Business.Tests.Mapping
{
    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}
