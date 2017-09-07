using System.Collections.Generic;

namespace EasyWork.Entities
{
    public class Ville
    {
        private int _id;
        private string _nom;
        private int _refPays;

        public virtual Pays Pays { get;set;}
        public IList<Recruteur> Recruteurs { get; set; }
        public IList<Candidat> Candidats { get; set; }
        public string Nom { get => _nom; set => _nom = value; }
        public int Id { get => _id; set => _id = value; }
        public int RefPays { get => _refPays; set => _refPays = value; }
    }
}