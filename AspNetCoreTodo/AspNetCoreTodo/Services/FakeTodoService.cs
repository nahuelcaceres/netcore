using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoService : ITodoItemService
    {

        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new TodoItem {
                Title = "item1",
                DueAt = DateTimeOffset.Now.AddDays(90)
            };

            var item2 = new TodoItem {
                Title = "item2",
                DueAt = DateTimeOffset.Now.AddDays(180)
            };

            return Task.FromResult(new TodoItem[]{ item1, item2});

        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            return false;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            return false;
        }

    }
}