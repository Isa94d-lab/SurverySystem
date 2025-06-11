using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    // Esta clase define como se configura la entidad Surveys en la base de datos
    public class SurveysConfiguration : IEntityTypeConfiguration<Surveys>
    {
        // Este metodo se llama automaticamente cuando se aplica el modelo
        public void Configure(EntityTypeBuilder<Surveys> builder)
        {
            // Le decimos que esta entidad se mapea a una tabla llamada "surveys"
            builder.ToTable("surveys");

            // Indicamos que la propiedad Id es la clave primaria
            builder.HasKey(s => s.Id);

            // Configuramos la propiedad Id:
            // - se mapea a la columna "id"
            // - es obligatoria (IsRequired)
            // - se genera automaticamente cuando se inserta (autoincremental)
            builder.Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            // Configuramos la propiedad Created_at:
            // - se mapea a la columna "created_at"
            // - por defecto, toma el timestamp actual del sistema
            builder.Property(s => s.Created_at)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Igual que Created_at pero para la actualizacion
            builder.Property(s => s.Updated_at)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Estas son propiedades simples que solo se renombran como columnas
            builder.Property(s => s.Componentreact).HasColumnName("componentreact");
            builder.Property(s => s.Componenthtml).HasColumnName("componenthtml");
            builder.Property(s => s.Description).HasColumnName("description");
            builder.Property(s => s.Instruction).HasColumnName("instruction");
            builder.Property(s => s.Name).HasColumnName("name");

            // Relacion uno-a-muchos: un survey tiene muchos chapters
            // - HasMany() indica la coleccion en Surveys
            // - WithOne() indica la propiedad de navegacion en Chapter
            // - HasForeignKey() indica la FK en Chapter que apunta al survey
            builder.HasMany(s => s.Chapters)
                   .WithOne(c => c.Surveys)
                   .HasForeignKey(c => c.Survey_id);
        }
    }
}