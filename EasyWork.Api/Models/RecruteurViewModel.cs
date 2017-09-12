using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyWork.Models
{
    public class RecruteurViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Civilite { get; set; }
        public string Poste { get; set; }
        public string Ville { get; set; }
        public int RefVille { get; set; }
    }
}