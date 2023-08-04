using Microsoft.AspNetCore.Mvc;
using mlbd_logistic_management.Data;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Services;

namespace mlbd_logistics_management.Controllers
{
    [ApiController]
    [Route("api/item-type")]
    public class ItemTypeController : ControllerBase
    {
        private readonly ItemTypeService _itemTypeService;
        private readonly MlbdLogisticManagementContext _context;

        public ItemTypeController(ItemTypeService itemTypeService, MlbdLogisticManagementContext context)
        {
            this._itemTypeService = itemTypeService;
            this._context = context;
        }

        // GET: api/item-type
        [HttpGet]
        public IActionResult GetItemTypes()
        {
            var itemTypes = _itemTypeService.GetAllItemTypes();
            return Ok(itemTypes);
        }

        // GET: api/item-type/5
        [HttpGet("{id}")]
        public IActionResult GetItemTypeById(int id)
        {
            var itemType = _itemTypeService.GetItemTypeById(id);
            if (itemType == null)
            {
                return NotFound();
            }

            return Ok(itemType);
        }

        // POST: api/item-type
        [HttpPost]
        public IActionResult CreateItemType(ItemType itemType)
        {
            //modelState validation with the model and incoming request 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Departments.Any(d => d.Id == itemType.DepartmentId))
            {
                return BadRequest("Invalid DepartmentId. The DepartmentId does not exist.");
            }
            _itemTypeService.CreateItemType(itemType);
            return CreatedAtAction(nameof(GetItemTypeById), new { id = itemType.Id }, itemType);
        }

        // PUT: api/item-type/5
        [HttpPut("{id}")]
        public IActionResult UpdateItemType(int id, ItemType itemType)
        {
            if (id != itemType.Id)
            {
                return BadRequest();
            }

            try
            {
                _itemTypeService.UpdateItemType(itemType);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/item-type/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItemType(int id)
        {
            try
            {
                _itemTypeService.DeleteItemType(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
