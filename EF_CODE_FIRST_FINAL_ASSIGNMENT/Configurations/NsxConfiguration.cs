﻿using System;
using System.Collections.Generic;
using System.Text;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Configurations
{
    public class NsxConfiguration : IEntityTypeConfiguration<Nsx>
    {
        public void Configure(EntityTypeBuilder<Nsx> builder)
        {
            builder.ToTable("Nsx");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(newid())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);
        }
    }
}
