using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {

        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this._todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            // Put items into a model
            // Render view using the model

            var items = await _todoItemService.GetIncompleteItemsAsync();

            TodoViewModel viewModel = new TodoViewModel()
            {
                Items = items
            };

            return View(viewModel);
        }

    }
}