namespace MoviesRegisterRest.Data.Dtos.MovieStudio;

public record MovieStudioDto(int Id, string Name, string Address, string Phone, string Email);
public record CreateMovieStudioDto(int Id, string Name, string Address, string Phone, string Email);
public record UpdateMovieStudioDto(int Id, string Name, string Address, string Phone, string Email);