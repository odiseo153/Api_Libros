using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaClaro.DTOS;
using PruebaClaro.Modelos;
using PruebaClaro.Solicitudes;
using PruebaClaro.Validations;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace PruebaClaro.Controllers
{
    public class BookController : Controller
    {
        private IMapper mapper;

        public BookController(IMapper map)
        {
        mapper = map;
        }


        //endpoint para obtener todos los libros
        [HttpGet("Get/Book")]
        public dynamic Get()
        {
            return  BooksLogistica.Get(); 
        }

        //obtener un libro especifico mediante ID
        [HttpGet("Get/Book/{id}")]
        public dynamic GetById([Required]int id)
        {
            return BooksLogistica.GetById(id);
        }

        [HttpGet("Get/Book/campos")]
        public dynamic BuscarTitulo([Required] string columna, [Required] string atributo)
        {

            return BooksLogistica.Buscar(columna, atributo);
        }

        //Crear un libro en la DB
        [HttpPost("Post/Book")]
        public ActionResult Insert([Required][FromBody]BookCreateDTO bookdto) 
        {
            Books book = mapper.Map<Books>(bookdto);

            return BooksLogistica.Post(book);
        }

        //Actualizar un libro mediante un ID
        [HttpPut("Put/Book/{id}")]
        public dynamic Put([Required]int id,[FromBody]BookCreateDTO bookdto) 
        {
            Books book = mapper.Map<Books>(bookdto);

            return BooksLogistica.Put(id, book);
        }

        //borrar un libro mediante ID
        [HttpDelete("Delete/Book/{id}")]
        public ActionResult Delete([Required] int id) 
        {

            return BooksLogistica.Delete(id);
        }



    }
}
