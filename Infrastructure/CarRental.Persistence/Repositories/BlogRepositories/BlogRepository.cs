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
			return await context.Blogs
				.Include(x => x.AppUser)
				.Include(x => x.Category)
				.Include(x => x.Comments)
				.ToListAsync();
		}

		public async Task<List<Blog>> GetBlogsByCategoryId(int id)
		{
			return await context.Blogs
				.Include(x => x.AppUser)
				.Include(x => x.Category)
				.Where(x => x.CategoryId == id)
				.ToListAsync();
		}

		public async Task<Blog> GetBlogWithAuthorAndCategoryByBlogId(int id)
		{
			return await context.Blogs
				.Include(x => x.AppUser)
				.Include(x => x.Category)
				.Include(x => x.Comments)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<Blog>> GetLast3BlogsWithAuthor()
		{
			return await context.Blogs
				.Include(x => x.AppUser)
				.OrderByDescending(x => x.Id)
				.Take(3)
				.ToListAsync();
		}

		public async Task<List<Blog>> GetLast5BlogsWithAuthors(int? appUserId = null)
		{
			var query = context.Blogs
				.Include(x => x.Category)
				.Include(x => x.AppUser)
				.AsQueryable();

			if (appUserId.HasValue && appUserId.Value > 0)
				query = query.Where(x => x.AppUserId == appUserId.Value);

			return await query.OrderByDescending(x => x.Id).Take(5).ToListAsync();
		}
	}
}
