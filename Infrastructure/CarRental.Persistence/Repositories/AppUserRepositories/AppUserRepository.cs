using CarRental.Application.Interfaces.AppUserInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository(CarRentalContext context) : IAppUserRepository
	{
		public async Task<List<AppUser>> GetAppUsersByRoleAsync(string roleName)
		{
			return await context.AppUsers
				.Include(x => x.AppRole) 
				.Where(x => x.AppRole.Name == roleName)
				.ToListAsync();
		}

		public async Task<List<AppUser>> GetAppUsersWithRolesAsync()
		{
			return await context.AppUsers
				.Include(x => x.AppRole)
				.ToListAsync();
		}
	}
}