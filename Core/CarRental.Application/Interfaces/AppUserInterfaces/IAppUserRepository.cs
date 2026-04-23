using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.AppUserInterfaces
{
	public interface IAppUserRepository
	{
		Task<List<AppUser>> GetAppUsersByRoleAsync(string roleName);
		Task<List<AppUser>> GetAppUsersWithRolesAsync();
	}
}
