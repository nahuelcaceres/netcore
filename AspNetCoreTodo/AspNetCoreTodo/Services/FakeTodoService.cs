using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoService : ITodoItemService
    {

        public Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser currentUser){
            return null;
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser currentUser)
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


        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser currentUser){
            return false;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser currentUser)
        {
            return false;
        }

        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser){
            return false;
        }
        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
        {
            return false;
        }

    }
}