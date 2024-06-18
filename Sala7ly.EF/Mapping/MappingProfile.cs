using Sala7ly.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sala7ly.Core.DTOs;

namespace Sala7ly.EF.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Define the mapping configuration
			CreateMap<Services, ServicesDTO>().ReverseMap();
		}
	}
}
