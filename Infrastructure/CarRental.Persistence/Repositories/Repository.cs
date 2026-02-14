using CarRental.Application.Interfaces;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories
{
	public class Repository<T>(CarRentalContext context) : IRepository<T> where T : class
	{
		public async Task CreateAsync(T entity)
		{
			context.Set<T>().Add(entity);
			await context.SaveChangesAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await context.Set<T>().FindAsync(id);
		}

		public async Task RemoveAsync(T entity)
		{
			context.Set<T>().Remove(entity);
			await context.SaveChangesAsync();
		}

		public Task UpdateAsync(T entity)
		{
			context.Set<T>().Update(entity);
			return context.SaveChangesAsync();
		}
	}
}
