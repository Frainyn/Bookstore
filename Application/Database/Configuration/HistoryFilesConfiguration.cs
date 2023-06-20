using Json.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database.Configuration;

public class HistoryFilesConfiguration : IEntityTypeConfiguration<HistoryFiles>
{
    public void Configure(EntityTypeBuilder<HistoryFiles> modelBuilder)
    {
        modelBuilder
            .HasIndex(c => c.Name)
            .IsUnique(true);
    }
}
