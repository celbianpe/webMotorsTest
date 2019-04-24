using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Contexts
{
    internal class AdvertisingModelMapper : IEntityTypeConfiguration<Models.AdvertisingModel>
    {
        public void Configure(EntityTypeBuilder<Models.AdvertisingModel> builder)
        {
            builder
                .ToTable("tb_AnuncioWebmotors")                
                .AddRequired(d => d.Make, "marca", "VARCHAR(45)")
                .AddRequired(d => d.Model, "modelo", "VARCHAR(45)")
                .AddRequired(d => d.Version, "versao", "VARCHAR(45)")
                .AddRequired(d => d.Year, "ano", "int")
                .AddRequired(d => d.Kilometers, "quilometragem", "int")
                .AddRequired(d => d.Annotations, "observacao", "text")
                .HasKey(d => d.Id);

        }
    }
}
