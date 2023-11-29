using MoviesRegisterRest.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace MoviesRegisterRest.Data.Entities;

public class MovieStudio
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    
    public Director Director { get; set; }

    [Required]
    public string UserId { get; set; }
    public MoviesWebUser User { get; set; }
}