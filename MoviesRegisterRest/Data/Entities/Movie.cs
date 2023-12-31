using MoviesRegisterRest.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace MoviesRegisterRest.Data.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string PlotSummary { get; set; }
    public double Budget { get; set; }
    public string ProductionStatus { get; set; }
    public string OriginCountry { get; set; }

    public MovieStudio MovieStudio { get; set; }

    [Required]
    public string UserId { get; set; }
    public MoviesWebUser User { get; set; }
}