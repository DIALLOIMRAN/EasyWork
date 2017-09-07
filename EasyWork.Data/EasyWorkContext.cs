using EasyWork.Data.Config;
using EasyWork.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

namespace EasyWork.Data
{
    public class EasyWorkContext : DbContext
    {
        public IDbSet <Pays> Pays { get; set; }
        public IDbSet <Ville> Villes { get; set; }
        public IDbSet <Recruteur> Recruteurs { get; set; }
        public IDbSet <Candidat> Candidats { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        public EasyWorkContext () : base("EasyWorkDatabse")
        {
            //initialize database
            //Database.SetInitializer<EasyWorkContext>(new DatabaseInitializer());
            // Provider Name could not be loaded Error Fixer
            var type = typeof(SqlProviderServices);
            // 
            ConfigureContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove <PluralizingTableNameConvention> ();
            modelBuilder.Conventions.Remove <OneToManyCascadeDeleteConvention> ();
            modelBuilder.Conventions.Remove <ManyToManyCascadeDeleteConvention> ();

            modelBuilder.Configurations.Add (new PaysConfiguration());
            modelBuilder.Configurations.Add (new VilleConfiguration());
            modelBuilder.Configurations.Add (new RecruteurConfiguration());
            modelBuilder.Configurations.Add (new CandidatConfiguration());
        }

        public virtual void ConfigureContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            //Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.UseDatabaseNullSemantics = false;
        }
    }

    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<EasyWorkContext>
    {
        protected override void Seed(EasyWorkContext context)
        {
            //var numberGenerator = new RandomGenerator();
            
            //var payss = Builder<Pays>.CreateListOfSize(3)
            //   .All()
            //       .With(a => a.Nom = Faker.Address.Country())
            //   .Build();

            //context.Pays.AddOrUpdate(c => c.Id, payss.ToArray());

            //var villes = Builder<Ville>.CreateListOfSize(5)
            //   .All()
            //       .With(a => a. = Faker.Address.City())
            //       .With(m => m.Pays = Pick<Pays>.RandomItemFrom(payss))
            //   .Build();

            //context.Villes.AddOrUpdate(c => c.Id, villes.ToArray());

            //var candidats = Builder<Candidat>.CreateListOfSize(10)
            //   .All()
            //       .With(a => a.Nom = Faker.Name.First())
            //       .With(a => a.Prenom = Faker.Name.Last())
            //       .With(a => a.Email = Faker.Internet.Email())
            //       .With(a => a.Telephone = Faker.Phone.Number())
            //       .With(a => a.Naissance = DateTime.Now.AddDays(numberGenerator.Next(10, 25)))
            //       .With(a => a.Password = "B*nheur$!17/*-m@tin" + numberGenerator.Next(100, 900))
            //       .With(a => a.Photo = "photo" + numberGenerator.Next(1, 25))
            //       .With(a => a.Urlcv = "cv" + numberGenerator.Next(1, 25))
            //       .With(a => a.Adresse = Faker.Address.StreetAddress())
            //       .With(a => a.Civilite = numberGenerator.NextString(1, 2))
            //       .With(a => a.Ville = Pick<Ville>.RandomItemFrom(villes))
            //   .Build();

            //context.Candidats.AddOrUpdate(c => c.Id, candidats.ToArray());

            //var recruteurs = Builder<Recruteur>.CreateListOfSize(10)
            //   .All()
            //       .With(r => r.Nom = Faker.Name.First())
            //       .With(r => r.Prenom = Faker.Name.Last())
            //       .With(r => r.Email = Faker.Internet.Email())
            //       .With(r => r.Telephone = Faker.Phone.Number())
            //       .With(r => r.Password = "B*nheur$!17/*-m@tin" + numberGenerator.Next(100, 900))
            //       .With(r => r.Poste = "poste" + numberGenerator.Next(1, 25))
            //       .With(r => r.Adresse = Faker.Address.StreetAddress())
            //       .With(r => r.Civilite = Faker.Extensions.ArrayExtensions.Random(new string[] { "M", "F" }))
            //       .With(r => r.Ville = Pick<Ville>.RandomItemFrom(villes))
            //   .Build();

            //context.Recruteurs.AddOrUpdate(r => r.Id, recruteurs.ToArray());
        }
    }

    
}
