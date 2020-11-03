using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItemApi.Model;
using ToDoItemApi.Model.Configuration;
using Microsoft.Extensions.Configuration;


namespace ToDoItemApi.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly GetOptions _getOptions = new GetOptions();

        public ToDoListService(IConfiguration configuration)
        {
            configuration.Bind("GetOptions", _getOptions);
        }
        public List<ToDoItem> GetToDoItemById(long id)
        {

            return new List<ToDoItem>
            {
                new ToDoItem {Id = 123},
                new ToDoItem{Id = 456 }
            }.Where(item => item.Id==id).ToList();

        }

        public List<ToDoItem> GetToDoItems()
        {

            return new List<ToDoItem>
            {
                new ToDoItem {Id = 123},
                new ToDoItem{Id = 456 }
            }.Where(item => true).ToList();

        }
    }
}
