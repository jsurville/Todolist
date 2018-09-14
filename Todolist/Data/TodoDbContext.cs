using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Todolist.Models;

namespace Todolist.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() : base("TodoListConnectionString")
        {

        }

        public DbSet<Categorie> Categories { get; set; }
    }
}