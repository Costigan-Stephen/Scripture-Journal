using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scripture_Journal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scripture_Journal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Scripture_JournalContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<Scripture_JournalContext>>()))
            {
                // Look for any movies.
                if (context.Entry.Any())
                {
                    return;   // DB has been seeded
                }

                context.Entry.AddRange(
                    new Entry
                    {
                        DateAdded = DateTime.Parse("2020-1-12"),
                        Book = "John",
                        Chapter = 3,
                        VerseRange = "16",
                        Notes = "God loved mankind enough to offer his beloved son to die for us."
                    },

                    new Entry
                    {
                        DateAdded = DateTime.Parse("2019-12-1"),
                        Book = "Jeremiah",
                        Chapter = 1,
                        VerseRange = "5",
                        Notes = "He knew Jeremiah before he was born, evidence of a pre-earth existence is demonstrated here."
                    },

                    new Entry
                    {
                        DateAdded = DateTime.Parse("2019-12-15"),
                        Book = "Matthew",
                        Chapter = 4,
                        VerseRange = "19",
                        Notes = "The simple charge of the savior to come and follow him"
                    },

                    new Entry
                    {
                        DateAdded = DateTime.Parse("2020-1-12"),
                        Book = "1 Nephi",
                        Chapter = 3,
                        VerseRange = "7",
                        Notes = "The lord will provide a way for us to accomplish his commands"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
