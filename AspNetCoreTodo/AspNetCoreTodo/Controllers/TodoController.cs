using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            // Put items into a model
            // Render view using the model

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge(); //Forzar que se loguee.

            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);

            TodoViewModel viewModel = new TodoViewModel()
            {
                Items = items
            };

            return View(viewModel);
        }

        [ValidateAntiForgeryToken] //Middelware que directamente si no matchea el token hidden del input... sale con error
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge(); //Forzar que se loguee.

            //Modelbinding (matchea por nombre de las propiedades)
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.AddItemAsync(newItem, currentUser);
            
            if(!successful){
                return BadRequest("Could not add item");
            }

            return RedirectToAction("index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDoneAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            
            var successful = await _todoItemService
                .MarkDoneAsync(id, currentUser);
            
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }
            
            return RedirectToAction("Index");
        }

    }
}