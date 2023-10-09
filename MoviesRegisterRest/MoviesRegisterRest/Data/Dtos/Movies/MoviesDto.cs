namespace MoviesRegisterRest.Data.Dtos.Movies;
public record MovieDto(int Id, string Name, string Genre, string PlotSummary, double Budget, string ProductionStatus, string OriginCountry);
public record CreateMovieDto(int Id, string Name, string Genre, string PlotSummary, double Budget, string ProductionStatus, string OriginCountry);
public record UpdateMovieDto(int Id, string Name, string Genre, string PlotSummary, double Budget, string ProductionStatus, string OriginCountry);

