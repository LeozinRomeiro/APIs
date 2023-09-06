using API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class FilmeContextcs : DbContext
    {
        public FilmeContextcs(DbContextOptions<FilmeContextcs> options) : base(options)
        {
            
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
