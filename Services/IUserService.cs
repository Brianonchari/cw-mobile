using CW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW.Services
{
	public interface IUserService
	{
		Task<List<UserResponseModel>> GetUsers() ;

		Task<bool> AddUser(AddUpdateUserRequest request	);

		Task<bool> updateuser(int id, AddUpdateUserRequest addUpdateUserRequest);

		Task<bool> deleteuser(int id);

		Task<UserResponseModel> getUserById(int id);
	}
}
