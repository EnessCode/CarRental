using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Results.BrandResults
{
	public class GetBrandQueryResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
