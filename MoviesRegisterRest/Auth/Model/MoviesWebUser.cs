using System;
using Microsoft.AspNetCore.Identity;

namespace MoviesRegisterRest.Auth.Model;

public class MoviesWebUser : IdentityUser
{
	[PersonalData]
	public string? AdditionalInfo { get; set; }
	public bool ForceRelogin { get; set; }
}


