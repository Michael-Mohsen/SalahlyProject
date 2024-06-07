using Microsoft.AspNetCore.Mvc;
using Sala7ly.Core;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sala7ly.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SparePartsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public SparePartsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[HttpGet("GetItemById")]
		public async Task<IActionResult> GetItemById()
		{
			return Ok(await _unitOfWork.SpareParts.GetByIdAsync(5));
		}

		[HttpGet("GetAllItems")]
		public async Task<IActionResult> GetAllItems()
		{
			return Ok(await _unitOfWork.SpareParts.GetAllAsync());
		}

		[HttpGet("GetItemByName")]
		public async Task<IActionResult> GetItemByName()
		{
			var item = await _unitOfWork.SpareParts.FindAllAsync(i => i.Name == "Fan");
			if (item == null)
			{
				return NotFound("No item found with that name");
			}
			return Ok(item);
		}

		[HttpGet("GetItemByPrice")]
		public async Task<IActionResult> GetItemByPrice()
		{
			var items = await _unitOfWork.SpareParts.FindAllAsync(i => i.Price == 1000);
			if (items == null)
			{
				return NotFound("No items found with this price");
			}
			return Ok(items);
		}

		[HttpGet("GetItemByAmount")]
		public async Task<IActionResult> GetItemByAmount()
		{
			var items = await _unitOfWork.SpareParts.FindAllAsync(i => i.Amount == 5);
			if (items == null)
			{
				return NotFound("No items found with this amount");
			}
			return Ok(items);
		}
		[HttpPost("AddItem")]
		public async Task<IActionResult> AddItem()
		{
			var item = await _unitOfWork.SpareParts.AddAsync(new SpareParts {Name = "dsfhh", Price = 1000, Amount = 5, Date = DateTime.Now , MerchantId = 1});
			_unitOfWork.Complete();
			return Ok(item);
		}
	}
}
