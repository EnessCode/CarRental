using CarRental.Application.Interfaces.TagCloudInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.TagCloudRepositories
{
	public class TagCloudRepository(CarRentalContext context) : ITagCloudRepository
	{
		public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
		{
			return await context.TagClouds.Where(x => x.BlogId == id).ToListAsync();
		}
	}
}
