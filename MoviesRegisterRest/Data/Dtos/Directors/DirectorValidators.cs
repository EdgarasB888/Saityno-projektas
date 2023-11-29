using System.Xml;
using FluentValidation;

namespace MoviesRegisterRest.Data.Dtos.Directors;

public class DirectorValidators
{
    public class CreateDirectorDtoValidator : AbstractValidator<CreateDirectorDto>
    {
        public CreateDirectorDtoValidator()
        {
            RuleFor(dto => dto.FullName).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Gender).NotEmpty().NotNull().Length(min: 2, max: 10);
            RuleFor(dto => dto.Country).NotEmpty().NotNull().Length(min: 2, max: 35);
            RuleFor(dto => dto.BirthDate).NotEmpty().NotNull().Must(birthDate => CalculateAge(birthDate) >= 18).WithMessage("Director must be 18 years old or older");
            RuleFor(dto => dto.SpokenLanguages).NotEmpty().NotNull().Length(min: 2, max: 100);
            RuleFor(dto => dto.Biography).NotEmpty().NotNull().Length(min: 10, max: 500);
            RuleFor(dto => dto.Address).NotEmpty().NotNull().Length(min: 2, max: 150);
            RuleFor(dto => dto.Phone).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.Email).NotEmpty().NotNull().Length(min: 2, max: 50);
        }
    }
    
    public class UpdateDirectorDtoValidator : AbstractValidator<UpdateDirectorDto>
    {
        public UpdateDirectorDtoValidator()
        {
            RuleFor(dto => dto.FullName).NotEmpty().NotNull().Length(min: 2, max: 50);
            RuleFor(dto => dto.Gender).NotEmpty().NotNull().Length(min: 2, max: 10);
            RuleFor(dto => dto.Country).NotEmpty().NotNull().Length(min: 2, max: 35);
            RuleFor(dto => dto.BirthDate).NotEmpty().NotNull().Must(birthDate => CalculateAge(birthDate) >= 18).WithMessage("Director must be 18 years old or older");
            RuleFor(dto => dto.SpokenLanguages).NotEmpty().NotNull().Length(min: 2, max: 100);
            RuleFor(dto => dto.Biography).NotEmpty().NotNull().Length(min: 10, max: 500);
            RuleFor(dto => dto.Address).NotEmpty().NotNull().Length(min: 2, max: 150);
            RuleFor(dto => dto.Phone).NotEmpty().NotNull().Length(min: 2, max: 20);
            RuleFor(dto => dto.Email).NotEmpty().NotNull().Length(min: 2, max: 50);
        }
    }
    
    private static int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        // Check if the birthday has occurred this year
        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}
