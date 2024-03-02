using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ApointmentConfiguration : IEntityTypeConfiguration<Apointment>
    {
        public void Configure(EntityTypeBuilder<Apointment> builder)
        {
            builder.Property(x => x.StartDate).IsRequired(true).HasColumnType("datetime2");
        }
    }
}
