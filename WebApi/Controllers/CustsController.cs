using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM.Data.Contexts;
using MyCRM.Entiities;
using System.Linq;

namespace MyCRM.Controllers
{
	[ApiController]
	[Route("api/custs")]
	public class CustsController : Controller
	{
		private CustsContext context;

		public CustsController(CustsContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IActionResult GetAll(CustTypes? typeID = null, string q = "")
		{
			var items = context.Custs
				.Include(x => x.Contacts)
				.Where(x => !typeID.HasValue || x.TypeID == typeID.Value)
				.Where(x => string.IsNullOrWhiteSpace(q) || x.Name.Contains(q) || x.Contacts.Any(c=> c.Name.Contains(q)))
				.ToList();
			return Ok(items);
		}

		[HttpGet("page/{page}")]
		public IActionResult GetPage(int page, int size = 2)
		{
			var skip = (page - 1) * size;

			var items = context.Custs
				.Skip(skip)
				.Take(size)
				.ToList();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public IActionResult GetByID(int id)
		{
			if (id <= 0)
				return NotFound($"Invalid ID = {id}");

			var item = context.Custs.FirstOrDefault(x => x.Id == id);
			if (item == null)
				return NotFound($"No cust for ID = {id}");

			return Ok(item);
		}

		[HttpPost]
		public IActionResult Add(Cust model)
		{
			context.Custs.Add(model);
			context.SaveChanges();
			return Ok(model.Id);
		}

		[HttpPut("{id}")]
		public IActionResult Update([FromRoute] int id, [FromBody] Cust model)
		{
			model.Id = id;
			context.Custs.Update(model);
			context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if (id <= 0)
				return NotFound();

			var item = context.Custs.Find(id);
			if (item == null)
				return Ok();

			context.Custs.Remove(item);
			context.SaveChanges();
			return Ok(id);
		}
	}
}
