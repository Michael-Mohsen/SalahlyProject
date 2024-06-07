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

		// Get Admin by Id
		[HttpGet]
		[HttpGet("GetAdminById")]
		public async Task<IActionResult> GetAdminById()
		{
			return Ok(await _unitOfWork.Admins.GetByIdAsync(3));
		}

		//Get All Admins
		[HttpGet("GetAllAdmins")]
		public async Task<IActionResult> GetAllAdmins()
		{
			return Ok(await _unitOfWork.Admins.GetAllAsync());
		}

		//Get Admin by Age
		[HttpGet("GetAdminByAge")]
		public async Task<IActionResult> GetAdminByAge()
		{
			try
			{
				var admin = await _unitOfWork.Admins.FindAllAsync(b => b.Age == 23);

				if (admin == null)
				{
					return NotFound("No admin found with age 23");
				}

				return Ok(admin);
			}
			catch (Exception)
			{
				return StatusCode(500, "An internal server error occurred.");
			}
		}

		// Get Admin by name
		[HttpGet("GetAdminByName")]
		public async Task<IActionResult> GetAdminByName()
		{
			return Ok(await _unitOfWork.Admins.FindAllAsync(b => b.Name == "Michael Mohsen"));
		}

		// Get all admins with department
		[HttpGet("GetAllAdminsWithDep")]
		public async Task<IActionResult> GetAllAdminsWithDep()
		{
			try
			{
				var admins = await _unitOfWork.Admins.FindAllAsync(a => a.Name == "Michael Mohsen", new[] { "Department" });

				if (admins == null || !admins.Any())
				{
					return NotFound("No admins found with age 23.");
				}

				return Ok(admins);
			}
			catch (Exception)
			{
				return StatusCode(500, "An internal server error occurred.");
			}
		}

		[HttpGet("GetOrderAdmin")]
		public async Task<IActionResult> GetOrderAdmin()
		{
			return Ok(await _unitOfWork.Admins.FindAllAsync(a => a.Age == 23, null, null, a => a.Id, OrderBy.Descending));
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
			var admin = await _unitOfWork.Admins.AddAsync(new Admin { Name = "Ahmed", Age = 30, Phone = "01788888888", HomeAddress = homeAddress , DepartmentId = 2 });
			_unitOfWork.Complete();
			return Ok(admin);
		}
	}
}
