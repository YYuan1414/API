using System.Collections.Generic;
using ToDoItemApi.Model;

namespace ToDoItemApi.Services
{
    public interface IToDoListService
    {
        List<ToDoItem> GetToDoItemById(long id);
        List<ToDoItem> GetToDoItems();
    }
}