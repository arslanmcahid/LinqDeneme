using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class BookReaderConfiguration : IEntityTypeConfiguration<BookReader>
    {
        public void Configure(EntityTypeBuilder<BookReader> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(75).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(75).IsRequired();


            builder.HasMany(x => x.ReadedBooks).WithMany(x => x.Readers);
        }
    }
}
