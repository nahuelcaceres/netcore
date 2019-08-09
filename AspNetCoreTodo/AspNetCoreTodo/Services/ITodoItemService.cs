using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
         Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser currentUser);
         Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser currentUser);
         Task<bool> AddItemAsync(TodoItem newItem, IdentityUser currentUser);
         Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser currentUser);
         Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser);
         Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser);
    }
}