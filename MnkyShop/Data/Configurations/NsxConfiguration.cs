namespace MinkyShop.Data.Configurations
{
    public class NsxConfiguration : IEntityTypeConfiguration<Nsx>
    {
        public void Configure(EntityTypeBuilder<Nsx> builder)
        {
            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);
        }
    }
}
