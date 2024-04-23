using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.net.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Diciplina> Diciplinas { get; set; }
        public DbSet<AlunoDiciplina> AlunoDiciplinas { get; set; } 

        protected override void OnModelCreating(ModelBuilder bulder) // essa tabela faz referencia da tabela alunos e tabela deciplinas
        {
            bulder.Entity<AlunoDiciplina>()
            .HasKey(a => new {a.AlunoId , a.DisiplinaId});
        }       

    }
}