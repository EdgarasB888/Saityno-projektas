using System;
namespace MoviesRegisterRest.Auth.Model;

public static class MoviesWebRoles
{
    public const string Admin = nameof(Admin);
	public const string Director = nameof(Director);
    public const string MovieStudioCEO = nameof(MovieStudioCEO);

    public static readonly IReadOnlyCollection<string> All = new[] { Admin, Director, MovieStudioCEO };
}

