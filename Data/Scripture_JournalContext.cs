using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scripture_Journal.Models;

namespace Scripture_Journal.Data
{
    public class Scripture_JournalContext : DbContext
    {
        public Scripture_JournalContext (DbContextOptions<Scripture_JournalContext> options)
            : base(options)
        {
        }

        public DbSet<Scripture_Journal.Models.Entry> Entry { get; set; }
    }
}
