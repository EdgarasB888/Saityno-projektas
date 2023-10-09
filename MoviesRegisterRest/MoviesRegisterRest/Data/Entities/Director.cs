namespace MoviesRegisterRest.Data.Entities;

public class Director
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Biography { get; set; }
    public string SpokenLanguages { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool IsAvailable { get; set; }
}