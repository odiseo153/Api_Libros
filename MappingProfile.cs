using AutoMapper;
using PruebaClaro.DTOS;
using PruebaClaro.Modelos;

namespace PruebaClaro
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapeando 
            CreateMap<BookCreateDTO, Books>();
            
        }
    }
}
