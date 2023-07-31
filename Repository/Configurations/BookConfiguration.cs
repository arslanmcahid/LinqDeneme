using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(75).IsRequired();
            builder.Property(x =>x.CategoryId).IsRequired();


            builder.HasOne(x=>x.Category).WithMany(x=>x.Books).HasForeignKey(x=>x.CategoryId);
        }
    }
}
