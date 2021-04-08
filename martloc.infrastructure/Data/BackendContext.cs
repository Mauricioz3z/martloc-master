
using martloc.ApplicationCore.Entity;
using martloc.infrastructure.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace martloc.infrastructure.Data
{
   public class BackendContext:IdentityDbContext<Usuario>
    {
        public BackendContext(DbContextOptions<BackendContext> options ):base(options)
        {
            

        }

        //public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        public DbSet<LocacaoItens> LocacaoItens { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Fisica> Fisica { get; set; }
        public DbSet<Juridica> Juridica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);// corrige :The entity type 'IdentityUserLogin<string>' requires a primary key to be defined
            //modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<Equipamento>().ToTable("Equipamento");
            modelBuilder.Entity<Locacao>().ToTable("Locacao");
            modelBuilder.Entity<LocacaoItens>().ToTable("LocacaoItens");

            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            //modelBuilder.Entity<Fisica>().ToTable("Fisica");
            //modelBuilder.Entity<Juridica>().ToTable("Juridica");


            //modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new LocacaoItensMap());



        }
    }
}
