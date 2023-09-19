using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mlbd_logistic_management.Services.EmailSender;
using mlbd_logistics_management.Models;
using mlbd_logistics_management.Services;
using mlbd_logistics_management.ViewModels.OutgoingRequests;
using mlbd_logistics_management.ViewModels.IncomingRequests;
using mlbd_logistics_management.ViewModels;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace mlbd_logistics_management.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public ItemController(ItemService itemService, IMapper mapper, HttpClient client)
        {
            _itemService = itemService;
            _mapper = mapper;
            _client = client;
        }

        // GET: api/item
       [HttpGet]
        public async Task<PaginatedList<ItemViewModel>> GetItems([FromQuery] ItemIndexRequestDto indexRequestDto)
        {
            var items = await _itemService.GetAllItems(indexRequestDto.PageNumber, indexRequestDto.PageSize);

            var mappedItems = _mapper.Map<PaginatedList<Item>, PaginatedList<ItemViewModel>>(items);
            
            return mappedItems;
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

        [HttpGet("random")]
        public async Task<IActionResult> RandomItems()
        {
            var address = "https://api.chucknorris.io/jokes/random";

            HttpResponseMessage response = await _client.GetAsync(address);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                // parsing from stringify json to string
                JsonDocument doc = JsonDocument.Parse(data);

                // accessing the array
                string value = doc.RootElement.GetProperty("value").ToString();

                // create a custom view model for your retrieved object
                ItemViewModel item = new ItemViewModel
                {
                    Name = value
                };

                return Ok(data);
            }   
            return NoContent();
        }

    }

}
