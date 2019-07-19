using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items
                                 .Where(todoItem => todoItem.IsDone == false)
                                 .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResult = _context.Items.SaveChangesAsync();

            return (saveResult == 1);
        }

    }
}