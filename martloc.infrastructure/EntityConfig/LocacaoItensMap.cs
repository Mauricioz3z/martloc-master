using martloc.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.infrastructure.EntityConfig
{
   public class LocacaoItensMap : IEntityTypeConfiguration<LocacaoItens>
    {
        public void Configure(EntityTypeBuilder<LocacaoItens> builder)
        {



            builder
        .HasKey(bc => new { bc.EquipamentoId, bc.LocacaoId });


            builder
                .HasOne(bc => bc.Equipamento)
                .WithMany(b => b.LocacaoItens)
                .HasForeignKey(bc => bc.EquipamentoId);


            builder
               .HasOne(bc => bc.Locacao)
               .WithMany(b => b.LocacaoItens)
               .HasForeignKey(bc => bc.LocacaoId);

       



       


        }
    }
}
