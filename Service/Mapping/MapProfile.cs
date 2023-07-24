using AutoMapper;
using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookReader, BookReaderDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
