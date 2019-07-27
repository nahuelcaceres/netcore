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

        [ValidateAntiForgeryToken] //Middelware que directamente si no matchea el token hidden del input... sale con error
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            //Modelbinding (matchea por nombre de las propiedades)
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            
            if(!successful){
                return BadRequest("Could not add item");
            }

            return RedirectToAction("index");
        }
    }
}