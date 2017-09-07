using System;

namespace EasyWork.Entities
{
    public class Candidat : Person
    {
        private DateTime _naissance;
        private string _avatar;
        private string _cv;

        public DateTime Naissance { get => _naissance; set => _naissance = value; }
        public string Avatar { get => _avatar; set => _avatar = value; }
        public string Cv { get => _cv; set => _cv = value; }
    }
}