using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        //dotnet ef migrations add AddItems
        //Corriendo el migrador con la tarea AddItems (es una descripcion de lo que voy a ingresar en DB)

        //Ahora si planchamos la migracion a DB realmente
        //dotnet ef database update

        //Ahora Entity Framework Core sabe que voy a trabajar con  TodoItem
        public DbSet<TodoItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ...
        }

    }
}
