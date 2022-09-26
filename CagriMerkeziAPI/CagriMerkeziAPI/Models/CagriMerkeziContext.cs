using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CagriMerkeziAPI.Models
{
    public class CagriMerkeziContext : DbContext
    {
        
            public CagriMerkeziContext(DbContextOptions<CagriMerkeziContext> options) : base(options)
            {

            }

            public DbSet<CagriDetay> CagriDetays { get; set; }



        }
    }

