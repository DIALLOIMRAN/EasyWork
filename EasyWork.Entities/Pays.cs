using System.Collections.Generic;

namespace EasyWork.Entities
{
    public class Pays
    {
        private int _id;
        private string _nom;

        public virtual IList<Ville> Villes { get; set; }
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
    }
}