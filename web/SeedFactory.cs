using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web
{
    public class SeedFactory
    {
        public static void Initialize(Context context)
        {
            // This line ensures your database exists.
            context.Database.EnsureCreated();
            // If the class inside of the Set<> doesn't have any data, the following code will execute.
            if (!context.Set<Hasher>().Any())
            {
                // Create a new list of technologies (we'll be saving this later).
                var Hasher = new List<Hasher>()
                {
                    // Create a new technology specifying all properties except the Id which will be auto generated.
                    new Hasher
                    {
                        HashName = "Kotex",
                        FirstName = "Matt",
                        LastName = "Leddington",
                        City = "Louisville"

                      

                    },
                               new Hasher
                    {
                        HashName = "Cum On Down",
                        FirstName = "Kristin",
                        LastName = "Johnson",
                        City = "Louisville",


                    },
                               new Hasher
                    {
                        HashName = "Regina Gorge",
                        FirstName = "Steven",
                        LastName = "Carr",
                        City = "Louisville",


                    },
                               new Hasher
                    {
                        HashName = "Dank Basement",
                        FirstName = "David",
                        LastName = "Bannister",
                        City = "Louisville",

                        // TechnologyType is an Enum, that means it has a string value, but it's saved as an int. 

                    },
                               new Hasher
                    {
                        HashName = "Dopplewanker",
                        FirstName = "Aaron",
                        LastName = "Smith",
                        City = "Louisville",

                        // TechnologyType is an Enum, that means it has a string value, but it's saved as an int. 

                    },

                               new Hasher
                    {
                        HashName = "Gay Margaret's Chinese Ass Trap",
                        FirstName = "Rebecca",
                        LastName = "Street",
                        City = "Louisville",

                        // TechnologyType is an Enum, that means it has a string value, but it's saved as an int. 

                    },
                               new Hasher
                    {
                        HashName = "Arrowhead",
                        FirstName = "John",
                        LastName = "Grant",
                        City = "Louisville",

                        // TechnologyType is an Enum, that means it has a string value, but it's saved as an int. 

                    }
                };
                // Add technology list as a change to be saved in the database.
                context.AddRangeAsync(Hasher);
                // Save any changes to the database.
                context.SaveChangesAsync();
            }
        }
    }
}