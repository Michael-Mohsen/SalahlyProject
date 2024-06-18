using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sala7ly.Core;
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
		private readonly IUnitOfWork _unitOfWork;
		public DepartmentController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> GetDepById()
		{
			return Ok(await _unitOfWork.Departments.GetByIdAsync(1));
		}

		[HttpGet("GetAllDep")]
		public async Task<IActionResult> GetAllDep()
		{
			return Ok(await _unitOfWork.Departments.GetAllAsync());
		}
		[HttpGet("GetDepByName")]
		public async Task<IActionResult> GetDepByName()
		{
			return Ok(await _unitOfWork.Departments.FindAllAsync(b => b.Name == "Manage"));
		}

		[HttpPost("AddDep")]
		public async Task<IActionResult> AddDep()
		{
			var department = await _unitOfWork.Departments.AddOneAsync(new Department {Name = "Sales"});
			_unitOfWork.Complete();
			return Ok(department);
		}
	}
}
