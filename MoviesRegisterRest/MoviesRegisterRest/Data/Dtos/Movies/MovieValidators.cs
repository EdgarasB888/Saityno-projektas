using FluentValidation;

namespace MoviesRegisterRest.Data.Dtos.Movies;

public class MovieValidators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Genre).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.PlotSummary).NotEmpty().NotNull().Length(min: 10, max: 200);
            RuleFor(dto => dto.Budget).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(dto => dto.ProductionStatus).NotEmpty().NotNull().Length(min: 2, max: 15);
            RuleFor(dto => dto.OriginCountry).NotEmpty().NotNull().Length(min: 2, max: 35);
        }
    }
    
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Genre).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.PlotSummary).NotEmpty().NotNull().Length(min: 10, max: 200);
            RuleFor(dto => dto.Budget).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(dto => dto.ProductionStatus).NotEmpty().NotNull().Length(min: 2, max: 15);
            RuleFor(dto => dto.OriginCountry).NotEmpty().NotNull().Length(min: 2, max: 35);
        }
    }
}
