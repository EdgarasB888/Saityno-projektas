using FluentValidation;

namespace MoviesRegisterRest.Data.Dtos.MovieStudio;

public class MovieStudioValidators
{
    public class CreateMovieStudioDtoValidator : AbstractValidator<CreateMovieStudioDto>
    {
        public CreateMovieStudioDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Address).NotEmpty().NotNull().Length(min: 2, max: 150);
            RuleFor(dto => dto.Phone).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.Email).NotEmpty().NotNull().Length(min: 2, max: 50);
        }
    }
    
    public class UpdateMovieStudioDtoValidator : AbstractValidator<UpdateMovieStudioDto>
    {
        public UpdateMovieStudioDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Address).NotEmpty().NotNull().Length(min: 2, max: 150);
            RuleFor(dto => dto.Phone).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.Email).NotEmpty().NotNull().Length(min: 2, max: 50);
        }
    }
}
