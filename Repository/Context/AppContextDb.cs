using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class AppContextDb : DbContext
    {

       public AppContextDb(DbContextOptions<AppContextDb> options) : base(options)
       {

       }

        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<Elemento> Elementos {  get; set; }
    }
}
