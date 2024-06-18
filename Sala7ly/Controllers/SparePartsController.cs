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

		[HttpGet("GetItemById")]
		public async Task<IActionResult> GetItemById(int id)
		{
			
			return Ok(await _unitOfWork.SpareParts.GetByIdAsync(id));
		}

		[HttpGet("GetAllItems")]
		public async Task<IActionResult> GetAllItems()
		{
			return Ok(await _unitOfWork.SpareParts.GetAllAsync());
		}

		[HttpGet("GetItemByName")]
		public async Task<IActionResult> GetItemByName(string name)
		{
			var item = await _unitOfWork.SpareParts.FindAllAsync(i => i.Name == name);
			if (item == null)
			{
				return NotFound("No item found with that name");
			}
			return Ok(item);
		}

		[HttpGet("GetItemByPrice")]
		public async Task<IActionResult> GetItemByPrice(decimal price)
		{
			var items = await _unitOfWork.SpareParts.FindAllAsync(i => i.Price == price);
			if (items == null)
			{
				return NotFound("No items found with this price");
			}
			return Ok(items);
		}

		[HttpGet("GetItemByAmount")]
		public async Task<IActionResult> GetItemByAmount(int amount)
		{
			var items = await _unitOfWork.SpareParts.FindAllAsync(i => i.Amount == amount);
			if (items == null)
			{
				return NotFound("No items found with this amount");
			}
			return Ok(items);
		}

		[HttpPost("AddItem")]
		public async Task<IActionResult> AddItem()
		{
			var NewSpare = new SpareParts { Name = "lm;ljo", Price = 6954, Amount = 11, Date = DateTime.Now, MerchantId = 1 };
			var item = await _unitOfWork.SpareParts.AddOneAsync(NewSpare);
			_unitOfWork.Complete();
			return Ok(item);
		}
	}
}
