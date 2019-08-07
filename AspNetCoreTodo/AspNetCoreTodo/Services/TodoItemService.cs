using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser currentUser)
        {
            return await _context.Items
                                 .Where(todoItem => todoItem.IsDone == false && todoItem.UserId == currentUser.Id)
                                 .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser currentUser)
        {
            newItem.Id = Guid.NewGuid();
            //newItem.IsDone = false;
            //newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);
            newItem.UserID = currentUser.Id;

            //var saveResult = await _context.Items.SaveChangesAsync();
            var saveResult = await _context.SaveChangesAsync();

            return (saveResult == 1);
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
        {
            var item = await _context.Items
                                    .Where(x => x.Id == id && x.userId == currentUser.Id)
                                    .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1; //One entity should have been updated
        }

    }
}