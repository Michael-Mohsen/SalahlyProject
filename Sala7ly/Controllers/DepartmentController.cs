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
		//private readonly IBaseRepository<Department> _departmentsRepository;
		private readonly IUnitOfWork _unitOfWork;
		//public DepartmentController(IBaseRepository<Department> departmentsRepository)
		public DepartmentController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult GetDepById()
		{
			//return Ok(_departmentsRepository.GetById(1));
			return Ok(_unitOfWork.Departments.GetById(1));
		}

		[HttpGet("GetDepByName")]
		public IActionResult GetDepByName()
		{
			//return Ok(_departmentsRepository.Find(b => b.Name == "Manage"));
			return Ok(_unitOfWork.Departments.Find(b => b.Name == "Manage"));
		}

		public IActionResult AddOne()
		{
			//return Ok(_adminsRepository.Add(new Admin {Name = "Ahmed", Age = 30, Phone = "01788888888", DepartmentId = 2 }));
			var department = _unitOfWork.Departments.Add(new Department {Name = "Sales"});
			_unitOfWork.Complete();
			return Ok(department);
			//return Ok(_unitOfWork.Admins.SpecialMethod());
		}
	}
}
