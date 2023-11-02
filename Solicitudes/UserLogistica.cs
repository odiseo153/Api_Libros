using Dapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PruebaClaro.Modelos;
using PruebaClaro.Validations;
using System.Data;
using System.Data.SqlClient;

namespace PruebaClaro.Solicitudes
{
    public class UserLogistica
    {
        public static string conexcion = "Data source=Odiseo\\ODISEO;Initial Catalog=curso;User ID=sa;Password=1234 ";
        private static SqlConnection db = new SqlConnection(conexcion);
        private static IDbConnection Open = BooksLogistica.Open();
        private static UserValidation validacion = new UserValidation();

        public static IEnumerable<Cliente> GetClientes() 
        {
            string query = "select * from cliente";
            var clientes = Open.Query<Cliente>(query);
            BooksLogistica.Close();

            return clientes;

        }

        public static IEnumerable<Cliente> GetClienteById(int id)
        {
            string query = $"select * from cliente where id = {(id <= 0 ? 0 : id)}";
            var cliente = Open.Query<Cliente>(query);
            BooksLogistica.Close(); 
            return cliente;
        }

        public static IEnumerable<Cliente> GetClienteByName(string nombre)
        {
            string query = $"select * from cliente where nombre = '{nombre}'";
            var cliente = Open.Query<Cliente>(query);
            BooksLogistica.Close();
            return cliente;
        }

        public static ActionResult GuardarCliente(Cliente cliente)
        {
            ValidationResult valid = validacion.Validate(cliente);


            try
            {
                var query = "INSERT INTO cliente(nombre,clave) VALUES(@nombre,@clave)";
                var insert = Open.Execute(query, new { cliente.nombre, cliente.clave});
            }
            catch (Exception ex)
            {
                BooksLogistica.Close();
                throw new Exception("error en la insercion de datos: " + ex.Message);
            }

            BooksLogistica.Close();
            return new JsonResult(new
            {
                Message = "El usuario fue agregado exitosamente",
                New_Client = cliente
            });
        }



    }
}
