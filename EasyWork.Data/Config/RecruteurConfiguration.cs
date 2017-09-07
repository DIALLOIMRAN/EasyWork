using System.Data.Entity.ModelConfiguration;
namespace EasyWork.Data.Config
{
    public class RecruteurConfiguration : EntityTypeConfiguration<Entities.Recruteur>
    {
        public RecruteurConfiguration()
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

            Property(c => c.Poste)
                .HasColumnName("poste")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            HasOptional(c => c.Ville)
                .WithMany(v => v.Recruteurs)
                .HasForeignKey(k => k.RefVille)
                .WillCascadeOnDelete(false);
        }
    }
}
