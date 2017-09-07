namespace EasyWork.Entities
{
    public class Recruteur : Person
    {
        private string _poste;

        public string Poste { get => _poste; set => _poste = value; }
    }
}