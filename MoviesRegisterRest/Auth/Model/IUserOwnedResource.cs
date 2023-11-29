using System;
namespace MoviesRegisterRest.Auth.Model;

public interface IUserOwnedResource
{
	public string UserId { get; }
}

