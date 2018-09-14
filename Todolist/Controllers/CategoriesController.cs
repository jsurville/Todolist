using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Todolist.Data;
using Todolist.Models;

namespace Todolist.Controllers
{
    public class CategoriesController : ApiController
    {
        private TodoDbContext db = new TodoDbContext();
        public IQueryable<Categorie> GetCategories()  // méthode associée à la méthode GET de l'API Web pour récupérer la liste des catégories
        {
            return db.Categories.OrderBy(x => x.Nom);
        }

        public IHttpActionResult PostCategories(Categorie categorie)
        {
            if (ModelState.IsValid)  // si l'état du modele est ok, càd que le tous les champs sont non nulls
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return Ok(categorie);
            }
            else
                return BadRequest(ModelState); // renvoie une errueur 400 
        }

        public IHttpActionResult PutCategories(int id, Categorie categorie)
        {
            if(id != categorie.ID)
            return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(db.Categories.Find(id) == null)
                return BadRequest();

            db.Entry(categorie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent); // renvoie une notification comme quoi ça s'est bien déroulé, mais sans contenu

        }

        protected override void Dispose(bool disposing) // pour libérer la connection du contexte avec la base de données
        {
            base.Dispose(disposing);
            db.Dispose();
        }
    }


}
