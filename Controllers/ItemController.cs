using Microsoft.AspNetCore.Mvc;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Services;

namespace mlbd_logistics_management.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/item
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetAllItems();
            return Ok(items);
        }

        // GET: api/item/5
        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/item
        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _itemService.CreateItem(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        // PUT: api/item/5
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                _itemService.UpdateItem(item);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/item/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                _itemService.DeleteItem(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
