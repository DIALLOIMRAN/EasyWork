using EasyWork.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EasyWork.Data.Config
{
    public class VilleConfiguration : EntityTypeConfiguration <Ville>
    {
        public VilleConfiguration()
        {
            Property(p => p.Nom)
                .IsRequired()
                .HasColumnName("nom")
                .HasMaxLength(100)
                .HasColumnType("varchar");

            HasRequired(v => v.Pays)
                .WithMany(p => p.Villes)
                .HasForeignKey(k => k.RefPays)
                .WillCascadeOnDelete(true);

        }
    }
}
