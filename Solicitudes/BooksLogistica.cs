using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using PruebaClaro.Validations;
using PruebaClaro.Modelos;
using System.Data;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace PruebaClaro.Solicitudes
{
    public class BooksLogistica
    {
        // Definición de la cadena de conexión a la base de datos SQL Server
        public static string conexcion = "Data source=Odiseo\\ODISEO;Initial Catalog=curso;User ID=sa;Password=1234 ";
        private static SqlConnection db = new SqlConnection(conexcion);

        // Método para obtener todos los libros
        public static dynamic Get()
        {
            string query = "select * from Books";
            var books = Open().Query(query);
            Close();
            return books;
        }

        public static dynamic Buscar(string columna,string atributo)
        {
            string query = $"select * from Books where {columna} = '{atributo}'";
            var books = Open().Query(query);
            Close();
            return books;
        }

        // Método para obtener un libro por su ID
        public static dynamic GetById(int id)
        {
            string query = $"select * from Books where IdBook = {(id <= 0 ? 0 : id)}";
            var book = Open().Query(query);
            Close();
            return book;
        }

        // Método para agregar un nuevo libro
        public static dynamic Post(Books book)
        {
            var valid = Validar(book);

            try
            {
                var query = "insert into Books(Title,Autor,Gender,PagesCount,Description,Lenguage,Avaliable) values(@Title,@Autor,@Gender,@PagesCount,@Description,@Lenguage,@Avaliable)";
                var insert = Open().Execute(query, new { book.Title, book.Autor, book.Gender, book.PagesCount, book.Description, book.Lenguage, book.Avaliable });
            }
            catch (Exception ex)
            {
                Close();
                throw new Exception("error en la insercion de datos: " + ex.Message);
            }

            Close();
            return new JsonResult(new
            {
                Message = "El libro fue agregado exitosamente",
                New_Client = book,
                Code = StatusCodes.Status200OK
            });
        }

        // Método para actualizar un libro por su ID
        public static dynamic Put(int id, Books book)
        {



            try
            {
                string query = @"update Books 
                                set Title=@Title,
                                Autor=@Autor,
                                Gender=@Gender,
                                PagesCount=@PagesCount,
                                Description=@Description,
                                Lenguage=@Lenguage,
                                Avaliable=@Avaliable
                                where IdBook = @id";

                int insert = Open().Execute(query, new { book.Title, book.Autor, book.Gender, book.PagesCount, book.Description, book.Lenguage, book.Avaliable, id });

                if(insert == 0) 
                {
                    return "ese id no existe";
                }

            }
            catch (Exception ex)
            {
                Close();
                return new JsonResult(new
                {
                    ex.Message,
                });
            }

            Close();
            return new JsonResult(new
            {
                Message = "the book was uptaded",
                New_Client = book,
                Code=StatusCodes.Status200OK
            });;
        }

        // Método para eliminar un libro por su ID
        public static dynamic Delete(int id)
        {
            try
            {
                string query = $"delete Books where IdBook={id}";
                Open().Query(query);
            }
            catch (Exception ex)
            {
                Close();
                return new JsonResult(new
                {
                    ex.Message,
                });
            }
            db.Close();
            return new JsonResult(new
            {
                Message = "The Book was deleted",
                Code = StatusCodes.Status200OK
            });
        }

        // Método para abrir la conexión a la base de datos
        public static IDbConnection Open()
        {
            if (db == null)
            {
                db = new SqlConnection(conexcion);
            }

            if (db.State != ConnectionState.Open)
            {
                db.Open();
            }

            return db;
        }

        // Método para cerrar la conexión a la base de datos
        public static void Close()
        {
            if (db == null && db.State == ConnectionState.Open)
            {
                db.Close();
            }
        }

        // Método para validar un objeto Books utilizando la clase BookValidation
        public static dynamic Validar(Books book)
        {
            var validar = new BookValidation().Validate(book);

            if (!validar.IsValid)
            {
                foreach (var item in validar.Errors)
                {
                    return new JsonResult(new
                    {
                        Column = item.PropertyName,
                        Message = item.ErrorMessage
                    });
                }
            }

            return true;
        }
    }
}
