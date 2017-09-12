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
            
        }
    }
}
