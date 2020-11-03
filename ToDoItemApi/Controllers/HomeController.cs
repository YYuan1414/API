using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToDoItemApi.Model;
using ToDoItemApi.Model.Configuration;
using ToDoItemApi.Services;

namespace ToDoItemApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase

    {
        private IConfiguration _configuration;
        private IToDoListService _toDoListService1;

        public ToDoListController(IConfiguration configuration, IToDoListService toDoListService)
        {
            _configuration = configuration;
            _toDoListService1 = toDoListService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetToDoItems()
        {
            var items = _toDoListService1.GetToDoItems();
            return Ok(items);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemById(long id)
        {
            var item = _toDoListService1.GetToDoItemById(id);
            if (item == null)
            {
                return NotFound($"No item match id: {id}");
            }

            return Ok(item);
        }
    }
}
