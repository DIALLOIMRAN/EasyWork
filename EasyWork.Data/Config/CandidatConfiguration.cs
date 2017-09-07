using System.Data.Entity.ModelConfiguration;

namespace EasyWork.Data.Config
{
    public class CandidatConfiguration : EntityTypeConfiguration<Entities.Candidat>
    {
        public CandidatConfiguration()
        {
            Property(c => c.Nom)
                .HasColumnName("nom")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(c => c.Prenom)
                .HasColumnName("prenom") 
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(c => c.Password)
                .HasColumnName("password")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(c => c.Telephone)
                .HasColumnName("telephone")
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(c => c.Adresse)
                .HasColumnName("adresse")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(c => c.Civilite)
                .HasColumnName("civilite")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(c => c.Avatar)
                .HasColumnName("photo")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(c => c.Cv)
                .HasColumnName("cv")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            HasOptional(c => c.Ville)
                .WithMany(v => v.Candidats)
                .HasForeignKey(k => k.RefVille)
                .WillCascadeOnDelete(false);
        }
    }
}
