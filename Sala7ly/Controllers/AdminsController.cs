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

		//private readonly IBaseRepository<Admin> _adminsRepository;
		private readonly IUnitOfWork _unitOfWork;
		
		//public AdminsController(IBaseRepository<Admin> adminsRepository)
		public AdminsController(IUnitOfWork unitOfWork)
		{
			//_adminsRepository = adminsRepository;
			_unitOfWork = unitOfWork;
		}

		// Get one admin by Id
		[HttpGet]
		public IActionResult GetById()
		{
			//return Ok(_adminsRepository.GetById(3));
			return Ok(_unitOfWork.Admins.GetById(3));
		}

		[HttpGet("GetByIdAsync")]
		public async Task<IActionResult> GetByIdAsync()
		{
			//return Ok(await _adminsRepository.GetByIdAsync(3));
			return Ok(await _unitOfWork.Admins.GetByIdAsync(3));
		}

		//Get All Admins
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			//return Ok(_adminsRepository.GetAll());
			return Ok(_unitOfWork.Admins.GetAll());
		}

		//Get Admin by Age
		[HttpGet("GetByAge")]
		public IActionResult GetByAge()
		{
			//return Ok(_adminsRepository.Find(b => b.Age == 23));
			return Ok(_unitOfWork.Admins.Find(b => b.Age == 23));
		}

		// Get Admin by name
		[HttpGet("GetByName")]
		public IActionResult GetByName()
		{
			//return Ok(_adminsRepository.Find(b => b.Name == "Michael"));
			return Ok(_unitOfWork.Admins.Find(b => b.Name == "Michael"));
		}

		// Get all admins with department
		[HttpGet("GetAllWithDep")]
		public IActionResult GetAllWithDep()
		{
			//return Ok(_adminsRepository.FindAll(a => a.Age == 23, new[] { "Department" }));
			return Ok(_unitOfWork.Admins.FindAll(a => a.Age == 23, new[] { "Department" }));

		}

		[HttpGet("GetOrdered")]
		public IActionResult GetOrdered()
		{
			//return Ok(_adminsRepository.FindAll(a => a.Age == 23, null, null, a => a.Id));
			//OR
			//return Ok(_adminsRepository.FindAll(a => a.Age == 23, null, null, a => a.Id, OrderBy.Descending));
			return Ok(_unitOfWork.Admins.FindAll(a => a.Age == 23, null, null, a => a.Id, OrderBy.Descending));
		}

		[HttpPost("AddOne")]
		public IActionResult AddOne()
		{
			//return Ok(_adminsRepository.Add(new Admin {Name = "Ahmed", Age = 30, Phone = "01788888888", DepartmentId = 2 }));
			var admin = _unitOfWork.Admins.Add(new Admin { Name = "Ahmed", Age = 30, Phone = "01788888888", DepartmentId = 2 });
			_unitOfWork.Complete();
			return Ok(admin);
			//return Ok(_unitOfWork.Admins.SpecialMethod());
		}


	}
}
