namespace MinkyShop.Infrastructure.Data.Configurations
{
    public class DongSpConfiguration : IEntityTypeConfiguration<DongSp>
    {
        public void Configure(EntityTypeBuilder<DongSp> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);
        }
    }
}
