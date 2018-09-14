﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Todolist.Models
{
    public class Tache
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        public string Description { get; set; }

        public DateTime? DateFin { get; set; }
        public bool Statut { get; set; }
        public int? Priorite { get; set; }

        public int CategorieID { get; set; }

         [ForeignKey("CategorieID")]
        public Categorie Categorie { get; set; }

    }
}