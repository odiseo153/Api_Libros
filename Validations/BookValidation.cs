using FluentValidation;
using PruebaClaro.Modelos;

namespace PruebaClaro.Validations
{
    public class BookValidation : AbstractValidator<Books>
    {

        public BookValidation() 
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("the title cannot be empty or null").MaximumLength(50).WithMessage("the maximum lengh is 50");
            RuleFor(x => x.Avaliable).NotNull().NotEmpty().WithMessage("the avaliable params cannot be null or empty");
            RuleFor(x=>x.Autor).NotNull().NotEmpty().WithMessage("el autor cannot be null or empty").MaximumLength(50).WithMessage("the maximum lenght is 50");
            RuleFor(x=>x.Gender).NotNull().NotEmpty().WithMessage("el autor cannot be null or empty").MaximumLength(20).WithMessage("the maximum lenght is 20");
            RuleFor(x=>x.Lenguage).NotEmpty().NotNull().WithMessage("el autor cannot be null or empty").MaximumLength(20).WithMessage("the maximum lenght is 20");
            RuleFor(x => x.IdBook).NotEmpty().NotNull().WithMessage("el autor cannot be null or empty");
        }
    }
}
