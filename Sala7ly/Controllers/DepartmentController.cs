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
	public class DepartmentController : ControllerBase
	{
		private readonly IBaseRepository<Department> _departmentsRepository;
		public DepartmentController(IBaseRepository<Department> departmentsRepository)
		{
			_departmentsRepository = departmentsRepository;
		}

		[HttpGet]
		public IActionResult GetDepById()
		{
			return Ok(_departmentsRepository.GetById(1));
		}

		[HttpGet("GetDepByName")]
		public IActionResult GetDepByName()
		{
			return Ok(_departmentsRepository.Find(b => b.Name == "Manage"));
		}
	}
}
