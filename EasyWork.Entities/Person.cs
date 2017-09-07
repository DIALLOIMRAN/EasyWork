namespace EasyWork.Entities
{
    public abstract class Person
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _email;
        private string _password;
        private string _telephone;
        private string _adresse;
        private string _civilite;
        private int _refVille;
        public virtual Ville Ville { get; set; }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string Telephone { get => _telephone; set => _telephone = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Civilite { get => _civilite; set => _civilite = value; }
        public int RefVille { get => _refVille; set => _refVille = value; }
    }
}
