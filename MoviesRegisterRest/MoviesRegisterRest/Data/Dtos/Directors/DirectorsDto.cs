namespace MoviesRegisterRest.Data.Dtos.Directors;

public record DirectorDto(int Id, string FullName, string Gender, string Country, DateTime BirthDate, DateTime RegisterDate, string Biography, string SpokenLanguages, string Address, string Phone, string Email, bool IsAvailable);
public record CreateDirectorDto(string FullName, string Gender, string Country, DateTime BirthDate, string Biography, string SpokenLanguages, string Address, string Phone, string Email, bool IsAvailable);
public record UpdateDirectorDto(string FullName, string Gender, string Country, DateTime BirthDate, string Biography, string SpokenLanguages, string Address, string Phone, string Email, bool IsAvailable);