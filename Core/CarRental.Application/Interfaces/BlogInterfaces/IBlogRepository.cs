using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.BlogInterfaces
{
	public interface IBlogRepository
	{
		Task<List<Blog>> GetLast3BlogsWithAuthor();
		Task<List<Blog>> GetAllBlogsWithAuthor();
		Task<Blog> GetBlogWithAuthorAndCategoryByBlogId(int id);
		Task<List<Blog>> GetBlogsByCategoryId(int id);
	}
}
