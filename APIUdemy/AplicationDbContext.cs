using System;
using APIUdemy.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIUdemy
{
    //AplicationDbContext, hereda Siempre de DbContext (se debe importar Microsoft.EntityFrameworkCore)
    public class AplicationDbContext : DbContext
    {
        //Constructor, AplicationDbContext(viene de DbContext)...
        //..al cual le puedo pasar distintas configuraciones, ej, el conecction string que apunta a la bd que utilizare.
        //El conecction string se configura en appsettings.Development.json
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet(viene de DbContext):
        //Crea una tabla a partir del esquema de 'Autor'. Nombre de la tabla: Autores
        public DbSet<Autor> Autores { get; set; }
    }
}

