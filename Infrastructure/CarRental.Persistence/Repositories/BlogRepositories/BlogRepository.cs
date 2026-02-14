using CarRental.Application.Interfaces.BlogInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.BlogRepositories
{
	public class BlogRepository(CarRentalContext context) : IBlogRepository
	{
		public async Task<List<Blog>> GetAllBlogsWithAuthor()
		{
			return await context.Blogs.Include(x => x.Author).Include(x => x.Category).ToListAsync();
		}

		public async Task<List<Blog>> GetBlogsByCategoryId(int id)
		{
			return await context.Blogs.Include(x => x.Author).Include(x => x.Category).Where(x => x.CategoryId == id).ToListAsync();
		}

		public async Task<Blog> GetBlogWithAuthorAndCategoryByBlogId(int id)
		{
			return await context.Blogs.Include(x => x.Author).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Blog>> GetLast3BlogsWithAuthor()
		{
			return await context.Blogs.Include(x => x.Author).OrderByDescending(x => x.Id).Take(3).ToListAsync();
		}
	}
}
