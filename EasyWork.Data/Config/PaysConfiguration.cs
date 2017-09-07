using System.Data.Entity.ModelConfiguration;

namespace EasyWork.Data.Config
{
    public class PaysConfiguration : EntityTypeConfiguration<Entities.Pays>
    {
        public PaysConfiguration()
        {
            Property(p => p.Nom)
                .IsRequired()
                .HasColumnName("nom")
                .HasMaxLength(100)
                .HasColumnType("varchar");
        }
    }
}
