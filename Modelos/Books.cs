using System.ComponentModel.DataAnnotations;

namespace PruebaClaro.Modelos
{
    public class Books
    {
        
        public int IdBook { get; set; }
    
        public string? Title { get; set; }
        public string? Autor { get; set; }
        public string? Gender { get; set; }
        public string? PagesCount { get;set; }
        public string? Description { get; set; }
        public string? Lenguage { get; set; }
        public bool? Avaliable { get; set; }
        public string? Cover { get; set; }



    }

}


