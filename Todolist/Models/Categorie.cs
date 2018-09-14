using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todolist.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [StringLength(20)] // taille ds straing 20
        [Required]  // champ obligatoire ne peut pas être null
        public string Nom { get; set; }
    }
}