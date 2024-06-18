using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sala7ly.Core;
using Sala7ly.Core.Consts;
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
		private readonly IUnitOfWork _unitOfWork;
		public AdminsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("GetAdminById")]
		public async Task<IActionResult> GetAdminById(int id)
		{
			return Ok(await _unitOfWork.Admins.GetByIdAsync(id));
		}

		[HttpGet("GetAllAdmins")]
		public async Task<IActionResult> GetAllAdmins()
		{
			return Ok(await _unitOfWork.Admins.GetAllAsync());
		}

		[HttpGet("GetAdminByAge")]
		public async Task<IActionResult> GetAdminByAge(int age)
		{
			try
			{
				var admin = await _unitOfWork.Admins.FindAllAsync(b => b.Age == age);

				if (admin == null)
				{
					return NotFound($"No admin found with age {age}");
				}

				return Ok(admin);
			}
			catch (Exception)
			{
				return StatusCode(500, "An internal server error occurred.");
			}
		}

		[HttpGet("GetAdminByName")]
		public async Task<IActionResult> GetAdminByName(string name)
		{
			return Ok(await _unitOfWork.Admins.FindAllAsync(b => b.Name == name));
		}


		[HttpGet("GetAllAdminsWithDep")]
		public async Task<IActionResult> GetAllAdminsWithDep(string name, string department)
		{
			try
			{
				var admins = await _unitOfWork.Admins.FindAllAsync(a => a.Name == name, new[] { department });

				if (admins == null || !admins.Any())
				{
					return NotFound($"No admins found with age {department}.");
				}

				return Ok(admins);
			}
			catch (Exception)
			{
				return StatusCode(500, "An internal server error occurred.");
			}
		}

		[HttpGet("GetOrderAdmin")]
		public async Task<IActionResult> GetOrderAdmin(string name)
		{
			return Ok(await _unitOfWork.Admins.FindAllAsync(a => a.Name == name, null, null, a => a.Id, OrderBy.Descending));
		}

		[HttpPost("AddAdmin")]
		public async Task<IActionResult> AddAdmin()
		{
			var homeAddress = new Address
			{
				Id = 25,
				Street = "Cairo",
				City = "Cairo",
				Country = "Cairo",
				State = "Cairo",
				PostalCode = "165498"
			};
			var admin = await _unitOfWork.Admins.AddOneAsync(new Admin { Name = "Ahmed", Age = 30, Phone = "01788888888", HomeAddress = homeAddress , DepartmentId = 2 });
			_unitOfWork.Complete();
			return Ok(admin);
		}
	}
}
