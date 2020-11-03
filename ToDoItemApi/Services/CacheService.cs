using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using ToDoItemApi.Model;

namespace ToDoItemApi.Services
{
    public class CacheService: IToDoListService
    {
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(30) });
        private const string _cacheKey = "todolist";
        private readonly IToDoListService _toDoListService;

        public CacheService(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        public List<ToDoItem> GetToDoItems()
        {
            if (_cache.TryGetValue(_cacheKey, out List<ToDoItem> value)) return value;
            var toDoList = _toDoListService.GetToDoItems();
            _cache.Set(_cacheKey, toDoList);
            return toDoList;
        }
    }
}
