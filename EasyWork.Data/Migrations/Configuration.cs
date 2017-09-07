namespace EasyWork.Data.Migrations
{
    using EasyWork.Entities;
    using FizzWare.NBuilder;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyWorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EasyWorkContext context)
        {
            // géntration des pays
            var payss = Builder<Pays>.CreateListOfSize(3)
               .All()
                   .With(p => p.Nom = Faker.Address.Country())
               .Build();

            context.Pays.AddOrUpdate(p => p.Id, payss.ToArray());

            // géntration des villes
            var villes = Builder<Ville>.CreateListOfSize(5)
               .All()
                   .With(v => v.Nom = Faker.Address.City())
                   .With(v => v.Pays = Pick<Pays>.RandomItemFrom(payss))
               .Build();

            context.Villes.AddOrUpdate(v => v.Id, villes.ToArray());

            // géntration des candidats
            var candidats = Builder<Candidat>.CreateListOfSize(5)
               .All()
                   .With(c => c.Nom = Faker.Name.First())
                   .With(c => c.Prenom = Faker.Name.Last())
                   .With(c => c.Email = Faker.Internet.Email())
                   .With(c => c.Telephone = Faker.Phone.Number())
                   .With(c => c.Naissance = DateTime.Now.AddDays(Faker.RandomNumber.Next(10, 25)))
                   .With(c => c.Password = "B*nheur$!17/*-m@tin")
                   .With(c => c.Avatar = "photo" + Faker.RandomNumber.Next(1,10))
                   .With(c => c.Cv = "cv" + Faker.RandomNumber.Next(1, 25))
                   .With(c => c.Adresse = Faker.Address.StreetAddress())
                   .With(c => c.Civilite = "M")
                   .With(c => c.Ville = Pick<Ville>.RandomItemFrom(villes))
               .Build();

            context.Candidats.AddOrUpdate(c => c.Id, candidats.ToArray());

            // géntration des recruteurs
            var recruteurs = Builder<Recruteur>.CreateListOfSize(5)
               .All()
                   .With(r => r.Nom = Faker.Name.First())
                   .With(r => r.Prenom = Faker.Name.Last())
                   .With(r => r.Email = Faker.Internet.Email())
                   .With(r => r.Telephone = Faker.Phone.Number())
                   .With(r => r.Password = "B*nheur$!17/*-m@tin")
                   .With(r => r.Poste = "poste" + Faker.RandomNumber.Next(1, 25))
                   .With(r => r.Adresse = Faker.Address.StreetAddress())
                   .With(r => r.Civilite = "M")
                   .With(r => r.Ville = Pick<Ville>.RandomItemFrom(villes))
               .Build();

            context.Recruteurs.AddOrUpdate(r => r.Id, recruteurs.ToArray());
        }
    }
}
