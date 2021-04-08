using martloc.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace martloc.infrastructure.EntityConfig
{
   public class PessoaMap: IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {




            builder.HasDiscriminator<int>("Tipo");
       










        }
    
       
    }
}
