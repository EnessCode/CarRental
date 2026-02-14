using CarRental.Application.Interfaces.CategoryInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.CategoryRepositories
{
	public class CategoryRepository(CarRentalContext context) : ICategoryRepository
	{
		public async Task<List<Category>> GetCategoriesWithBlogs()
		{
			return await context.Categories.Include(x => x.Blogs).ToListAsync();
		}
	}
}
