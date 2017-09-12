using System;

namespace EasyWork.Models
{
    public class CandidatViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Civilite { get; set; }
        public DateTime Naissance { get; set; }
        public string Avatar { get; set; }
        public string Cv { get; set; }
        public string Ville { get; set; }
        public int RefVille { get; set; }
    }
}