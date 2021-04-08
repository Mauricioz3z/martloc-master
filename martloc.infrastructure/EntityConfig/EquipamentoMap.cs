using martloc.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.infrastructure.EntityConfig
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {

            builder.HasKey(e => e.Id);

            //builder.Property(e => e.ValorDiario).HasColumnType("decimal(5,2)");
                
            




        }
    }
}
