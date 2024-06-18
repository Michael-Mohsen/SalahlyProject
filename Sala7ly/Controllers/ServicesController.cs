using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sala7ly.Core;
using Sala7ly.Core.DTOs;
using Sala7ly.Core.Models;
using Sala7ly.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly Sala7lyDbContext _context;
		private readonly IMapper _mapper;
		//private readonly List<Services> _services;

		public ServicesController(Sala7lyDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServicesDTO>> GetServiceByIdAsync(int id)
		{
			var service = await _context.Services.FindAsync(id);
			if (service == null)
			{
				return NotFound();
			}

			var serviceDTO = _mapper.Map<ServicesDTO>(service);
			return Ok(serviceDTO);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ServicesDTO>>> GetAllServicesAsync()
		{
			var services = await _context.Services.ToListAsync();
			var servicesDTO = _mapper.Map<List<ServicesDTO>>(services);
			return Ok(servicesDTO);
		}

		[HttpPost]
		public async Task<IActionResult> AddService([FromBody]ServicesDTO service)
		{
			if (ModelState.IsValid)
			{
				Services mdl = new()
				{
					ServiceName = service.ServiceName
				};
				await _context.Services.AddAsync(mdl);
				await _context.SaveChangesAsync();
				return Ok(service);
			}
			return BadRequest();
		}

	}
}
