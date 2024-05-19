using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sala7ly.Core.Interfaces;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminsController : ControllerBase
	{
		private readonly IBaseRepository<Admin> _adminsRepository;
		public AdminsController(IBaseRepository<Admin> adminsRepository)
		{
			_adminsRepository = adminsRepository;
		}

		[HttpGet]
		public IActionResult GetById()
		{
			return Ok(_adminsRepository.GetById(3));
		}
		[HttpGet("GetByIdAsync")]
		public async Task<IActionResult> GetByIdAsync()
		{
			return Ok(await _adminsRepository.GetByIdAsync(3));
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			return Ok(_adminsRepository.GetAll());
		}

		[HttpGet("GetByAge")]
		public IActionResult GetByAge()
		{
			return Ok(_adminsRepository.Find(b => b.Age == 23));
		}

		[HttpGet("GetByName")]
		public IActionResult GetByName()
		{
			return Ok(_adminsRepository.Find(b => b.Name == "Michael"));
		}

		[HttpGet("GetAllWithDep")]
		public IActionResult GetAllWithDep()
		{
			return Ok(_adminsRepository.FindAll(a => a.Age == 23, new[] { "Department" }));
		}
	}
}
