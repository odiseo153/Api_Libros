using FluentValidation;
using PruebaClaro.Modelos;

namespace PruebaClaro.Validations
{
    public class UserValidation : AbstractValidator<Cliente>
    {

        public UserValidation() 
        {
            RuleFor(x => x.id).NotEmpty().NotNull();
            RuleFor(x => x.nombre).NotEmpty().NotNull();
            RuleFor(x => x.clave).NotEmpty().NotNull();
        } 
    }
}
