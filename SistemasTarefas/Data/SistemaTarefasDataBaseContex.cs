using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SistemasTarefas.Models;

namespace SistemasTarefas.Data
{
    public class SistemaTarefasDataBaseContex : DbContext
    {
        public SistemaTarefasDataBaseContex(DbContextOptions<SistemaTarefasDataBaseContex> options) :base(options)
        {
             
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
