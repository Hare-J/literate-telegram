using CanadaGames.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGames.Data
{
    public class CGSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new CanadaGamesContext(
                serviceProvider.GetRequiredService<DbContextOptions<CanadaGamesContext>>()))
            {
                if (!context.Contingents.Any())
                {
                    var contingents = new List<Contingent>
                    {
                        new Contingent { Code = "ON", Name = "Ontario"},
                        new Contingent { Code = "PE", Name = "Prince Edward Island"},
                        new Contingent { Code = "NB", Name = "New Brunswick"},
                        new Contingent { Code = "BC", Name = "British Columbia"},
                        new Contingent { Code = "NL", Name = "Newfoundland and Labrador"},
                        new Contingent { Code = "SK", Name = "Saskatchewan"},
                        new Contingent { Code = "NS", Name = "Nova Scotia"},
                        new Contingent { Code = "MB", Name = "Manitoba"},
                        new Contingent { Code = "QC", Name = "Quebec"},
                        new Contingent { Code = "YT", Name = "Yukon"},
                        new Contingent { Code = "NU", Name = "Nunavut"},
                        new Contingent { Code = "NT", Name = "Northwest Territories"},
                        new Contingent { Code = "AB", Name = "Alberta"}
                    };
                    context.Contingents.AddRange(contingents);
                    context.SaveChanges();
                }

                if (!context.Genders.Any())
                {
                    var genders = new List<Gender>
                    {
                        new Gender { Code = "W", Name = "Women"},
                        new Gender { Code = "M", Name = "Men"}
                    };
                    context.Genders.AddRange(genders);
                    context.SaveChanges();
                }
                //Add the Sports
                if (!context.Sports.Any())
                {
                    string[] sports = new string[] { "Athletics", "Baseball", "Basketball", "Canoe Kayak", "Cycling - Road Cycling", "Cycling - Mountain Bike", "Diving", "Golf", "Lacrosse", "Rowing", "Rugby Sevens", "Sailing", "Soccer", "Softball", "Swimming", "Tennis", "Triathlon", "Volleyball - Beach", "Volleyball - Indoor", "Wrestling" };
                    string[] sportCodes = new string[] { "ATH", "BAB", "BKB", "CKY", "CYR", "CYM", "DIV", "GLF", "LAC", "ROW", "RGS", "SAL", "SOC", "SBA", "SWM", "TEN", "TRA", "VBB", "VBI", "WRS" };
                    int NumSports = sports.Count();

                    //Loop through sports and add them
                    for (int i = 0; i < NumSports; i++)
                    {
                            //Construct some details
                            Sport s = new Sport()
                            {
                                Code=sportCodes[i],
                                Name=sports[i]
                            };
                            context.Sports.Add(s);

                    }
                    context.SaveChanges();
                }
                //Add the Coaches
                if (!context.Coaches.Any())
                {
                    string[] cfirstNames = new string[] { "Woodstock", "Violet", "Charlie", "Lucy", "Linus", "Franklin", "Marcie", "Schroeder" };
                    string[] clastNames = new string[] { "Hightower", "Broomspun", "Jones", "Bloggs", "Brown", "Smith", "Daniel" };

                    //Loop through names and Coaches
                    foreach (string lastName in clastNames)
                    {
                        foreach (string firstname in cfirstNames)
                        {
                            //Construct some details
                            Coach a = new Coach()
                            {
                                FirstName = firstname,
                                LastName = lastName,
                                MiddleName = lastName[1].ToString().ToUpper(),
                            };
                            context.Coaches.Add(a);
                        }
                    }
                    context.SaveChanges();
                }

                //To randomly generate data
                Random random = new Random();

                //Create collections of the primary keys
                int[] genderIDs = context.Genders.Select(a => a.ID).ToArray();
                //Note: for Gender we will alternate
                int[] sportIDs = context.Sports.Select(a => a.ID).ToArray();
                int sportIDCount = sportIDs.Count();
                int[] coachIDs = context.Coaches.Select(a => a.ID).ToArray();
                int coachIDCount = coachIDs.Count();
                int[] contingentIDs = context.Contingents.Select(a => a.ID).ToArray();
                int contingentIDCount = contingentIDs.Count();

                //Create 5 large strings from Bacon ipsum
                string[] baconNotes = new string[] { "Bacon ipsum dolor amet meatball corned beef kevin, alcatra kielbasa biltong drumstick strip steak spare ribs swine. Pastrami shank swine leberkas bresaola, prosciutto frankfurter porchetta ham hock short ribs short loin andouille alcatra. Andouille shank meatball pig venison shankle ground round sausage kielbasa. Chicken pig meatloaf fatback leberkas venison tri-tip burgdoggen tail chuck sausage kevin shank biltong brisket.", "Sirloin shank t-bone capicola strip steak salami, hamburger kielbasa burgdoggen jerky swine andouille rump picanha. Sirloin porchetta ribeye fatback, meatball leberkas swine pancetta beef shoulder pastrami capicola salami chicken. Bacon cow corned beef pastrami venison biltong frankfurter short ribs chicken beef. Burgdoggen shank pig, ground round brisket tail beef ribs turkey spare ribs tenderloin shankle ham rump. Doner alcatra pork chop leberkas spare ribs hamburger t-bone. Boudin filet mignon bacon andouille, shankle pork t-bone landjaeger. Rump pork loin bresaola prosciutto pancetta venison, cow flank sirloin sausage.", "Porchetta pork belly swine filet mignon jowl turducken salami boudin pastrami jerky spare ribs short ribs sausage andouille. Turducken flank ribeye boudin corned beef burgdoggen. Prosciutto pancetta sirloin rump shankle ball tip filet mignon corned beef frankfurter biltong drumstick chicken swine bacon shank. Buffalo kevin andouille porchetta short ribs cow, ham hock pork belly drumstick pastrami capicola picanha venison.", "Picanha andouille salami, porchetta beef ribs t-bone drumstick. Frankfurter tail landjaeger, shank kevin pig drumstick beef bresaola cow. Corned beef pork belly tri-tip, ham drumstick hamburger swine spare ribs short loin cupim flank tongue beef filet mignon cow. Ham hock chicken turducken doner brisket. Strip steak cow beef, kielbasa leberkas swine tongue bacon burgdoggen beef ribs pork chop tenderloin.", "Kielbasa porchetta shoulder boudin, pork strip steak brisket prosciutto t-bone tail. Doner pork loin pork ribeye, drumstick brisket biltong boudin burgdoggen t-bone frankfurter. Flank burgdoggen doner, boudin porchetta andouille landjaeger ham hock capicola pork chop bacon. Landjaeger turducken ribeye leberkas pork loin corned beef. Corned beef turducken landjaeger pig bresaola t-bone bacon andouille meatball beef ribs doner. T-bone fatback cupim chuck beef ribs shank tail strip steak bacon." };
                //Names for Athletes and Hometowns
                //WARNING - If you change the lastnames used you could break the code for seeding Hometowns
                //  That code assumes you have at least at least 26 unique names in the lastNames array
                string[] firstNames = new string[] { "Lyric", "Antoinette", "Kendal", "Vivian", "Ruth", "Jamison", "Emilia", "Natalee", "Yadiel", "Jakayla", "Lukas", "Moses", "Kyler", "Karla", "Chanel", "Tyler", "Camilla", "Quintin", "Braden", "Clarence" };
                string[] lastNames = new string[] { "Watts", "Randall", "Arias", "Weber", "Stone", "Carlson", "Robles", "Frederick", "Parker", "Morris", "Soto", "Bruce", "Orozco", "Boyer", "Burns", "Cobb", "Blankenship", "Houston", "Estes", "Atkins", "Miranda", "Zuniga", "Ward", "Mayo", "Costa", "Reeves", "Anthony", "Cook", "Krueger", "Crane", "Watts", "Little", "Henderson", "Bishop" };
                int firstNameCount = firstNames.Count();
                int lastNameCount = lastNames.Count();

                //Create the Hometowns
                if (!context.Hometowns.Any())
                {
                    int i = 0;
                    foreach (int c in contingentIDs)
                    {
                        //Warning - we assume you have at least at least 26 unique names in the lastNames array
                        var hometowns = new List<Hometown>
                        {
                            new Hometown { Name=lastNames[i], ContingentID=c},
                            new Hometown { Name=lastNames[i+1], ContingentID=c},
                        };
                        context.Hometowns.AddRange(hometowns);
                        context.SaveChanges();
                        i += 2;
                    }
                }
                //Create collection of the Hometown primary keys
                int[] hometownIDs = context.Hometowns.Select(a => a.ID).ToArray();
                int hometownIDCount = hometownIDs.Count();

                //Add the Athletes
                if (!context.Athletes.Any())
                {
                    // Birthdate for randomly produced Athletes 
                    // We will add a random number of days to the minimum date
                    DateTime startDOB = Convert.ToDateTime("1992-08-22");
                    int counter = 1; //Used to help add some Athletes to Coaches and set genders

                    foreach (string lastName in lastNames)
                    {
                        //Choose a random HashSet of 4 (Unique) first names
                        HashSet<string> selectedFirstNames = new HashSet<string>();
                        while (selectedFirstNames.Count() < 4)
                        {
                            selectedFirstNames.Add(firstNames[random.Next(firstNameCount)]);
                        }

                        foreach (string firstName in selectedFirstNames)
                        {
                            //Construct some Athlete details
                            Athlete athlete = new Athlete()
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                MiddleName = lastName[1].ToString().ToUpper(),
                                AthleteCode = random.Next(1111111, 9999999).ToString(),
                                HometownID = hometownIDs[random.Next(hometownIDCount)],
                                DOB = startDOB.AddDays(random.Next(60, 6500)),
                                Height = random.Next(170,200),
                                Weight = random.Next(80, 100),
                                YearsInSport = random.Next(12),
                                Affiliation = firstNames[random.Next(firstNameCount)],
                                Goals = "To win Gold",
                                MediaInfo = baconNotes[random.Next(5)],
                                ContingentID = contingentIDs[random.Next(contingentIDCount)],
                                SportID = sportIDs[random.Next(sportIDCount)],
                                GenderID = (counter % 2 == 0) ? genderIDs[0] : genderIDs[1]
                            };
                            if (counter % 3 == 0)//Every third Athlete gets assigned to a Coach
                            {
                                athlete.CoachID = coachIDs[random.Next(coachIDCount)];
                            }
                            counter++;
                            context.Athletes.Add(athlete);
                            try
                            {
                                //Could be duplicates
                                context.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                var m = e.Message;
                                //so skip it and go on to the next
                            }
                        }
                    }
                }
                int[] athleteIDs = context.Athletes.Select(a => a.ID).ToArray();
                int athleteIDCount = athleteIDs.Count();
                //Add some AthleteSports
                if (!context.AthleteSports.Any())
                {
                    //We will create an list of anonymous types with the Athletes' ID and SportID
                    var athletes = context.Athletes.Select(a => new { a.ID, a.SportID }).ToList();
                    int counter = 1;
                    foreach(var a in athletes)
                    {
                        if(counter % 3 == 0)
                        {
                            //Make sure you don't pick their main area of competition
                            var otherSportIDs = sportIDs.Where(s => s != a.ID).ToArray();
                            AthleteSport asport = new AthleteSport()
                            {
                                AthleteID = a.ID,
                                SportID = otherSportIDs[random.Next(sportIDCount - 1)]
                            };
                            context.AthleteSports.Add(asport);
                        }
                        counter++;
                    }
                    context.SaveChanges();
                }

                //Prepare Dictionaries of related values to avoid repeatedly hitting the database 
                //We need these becuase we are only supplied the names for Sport and Gender
                var SportDictionary = context.Sports.ToDictionary(x => x.Name, x => x.ID);
                var GenderDictionary = context.Genders.ToDictionary(x => x.Name, x => x.ID);
                if (!context.Events.Any())
                {
                    var theEvents = new List<Event>
                    {
                                                new Event
                        {
                            Name="100m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m Special Olympics",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="110m hurdles",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="1500m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="1500m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m Special Olympics",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="3000m steeplechase",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="400m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="400m hurdles",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="400m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="5000m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="800m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Decathlon",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Discus",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Hammer",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="High Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Javelin",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Long Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Para Discus",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Para Shot Put",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Pole Vault",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Shot Put",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Triple Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="100m hurdles",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="100m Special Olympics",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="100m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="1500m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="1500m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="200m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="200m Special Olympics",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="3000m steeplechase",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="400m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="400m hurdles",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="400m wheelchair",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="5000m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="800m",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Discus",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Hammer",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Heptathlon",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="High Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Javelin",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Long Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Para Discus",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Para Shot Put",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Pole Vault",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Shotput",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Triple Jump",
                            Type="Individual",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="4x100m relay",
                            Type="Team",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="4x400m relay",
                            Type="Team",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="4x100m relay",
                            Type="Team",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="4x400m relay",
                            Type="Team",
                            SportID=SportDictionary["Athletics"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Baseball",
                            Type="Team",
                            SportID=SportDictionary["Baseball"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Backetball",
                            Type="Team",
                            SportID=SportDictionary["Basketball"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Basketball",
                            Type="Team",
                            SportID=SportDictionary["Basketball"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-1, 1000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-1, 200m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-1, 5000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-1, 500m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-1, 1000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-1, 200m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-1, 5000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-1, 500m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-1, 1000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-1, 200m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-1, 5000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-1, 500m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-1, 1000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-1, 200m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-1, 5000m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-1, 500m",
                            Type="Individual",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-2, 1000m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-2, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-2, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="IC-4, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="IC-4, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-2, 1000m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-2, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-2, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-4, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="K-4, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="C-2, 1000m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-2, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="C-2, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="IC-4, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="IC-4, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-2, 1000m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-2, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-2, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-4, 200m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="K-4, 500m",
                            Type="Team",
                            SportID=SportDictionary["Canoe Kayak"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Cross Country",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Sprint",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Cross Country",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Sprint",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Relay",
                            Type="Team",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Mountain Bike Relay",
                            Type="Team",
                            SportID=SportDictionary["Cycling - Mountain Bike"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Road Cycling Criterium",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Road Cycling Individual Time Trial",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Road Cycling Road Race",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Road Cycling Criterium",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Road Cycling Individual Time Trial",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Road Cycling Road Race",
                            Type="Individual",
                            SportID=SportDictionary["Cycling - Road Cycling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="1m springboard",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="3m springboard",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Artistic",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Platform",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="1m springboard",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="3m springboard",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Artistic",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Platform",
                            Type="Individual",
                            SportID=SportDictionary["Diving"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Individual Golf",
                            Type="Individual",
                            SportID=SportDictionary["Golf"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Individual Golf",
                            Type="Individual",
                            SportID=SportDictionary["Golf"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Team Golf",
                            Type="Team",
                            SportID=SportDictionary["Golf"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Team Golf",
                            Type="Team",
                            SportID=SportDictionary["Golf"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Men's Lacrosse",
                            Type="Team",
                            SportID=SportDictionary["Lacrosse"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Women's Lacrosse",
                            Type="Team",
                            SportID=SportDictionary["Lacrosse"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Single (M1x)",
                            Type="Individual",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Single (W1x)",
                            Type="Individual",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Double (M2x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Eight (M8+)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Four (M4-)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Lightweight Double (LM2x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Pair (M2-)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Quad (M4x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Double (W2x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Eight (W8+)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Four (W4-)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Lightweight Double (LW2x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Pair (W2-)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Quad (W4x)",
                            Type="Team",
                            SportID=SportDictionary["Rowing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Rugby Sevens",
                            Type="Team",
                            SportID=SportDictionary["Rugby Sevens"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Single Handed Laser",
                            Type="Individual",
                            SportID=SportDictionary["Sailing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Single Handed Laser Radial",
                            Type="Individual",
                            SportID=SportDictionary["Sailing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Double Handed 29er",
                            Type="Team",
                            SportID=SportDictionary["Sailing"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Double Handed 29er",
                            Type="Team",
                            SportID=SportDictionary["Sailing"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Soccer",
                            Type="Team",
                            SportID=SportDictionary["Soccer"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Soccer",
                            Type="Team",
                            SportID=SportDictionary["Soccer"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Softball",
                            Type="Team",
                            SportID=SportDictionary["Softball"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Softball",
                            Type="Team",
                            SportID=SportDictionary["Softball"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="100m Backstroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m Breaststroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m Butterfly",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="100m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="1500m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m Backstroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m Breaststroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m Butterfly",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="200m IM",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="3000m Open Water",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="400m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="400m IM",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Backstroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Backstroke - SOC",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Breaststroke",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Breaststroke - SOC",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Butterfly",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="50m Freestyle - SOC",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="800m Freestyle",
                            Type="Individual",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="4 x 100m Freestyle relay",
                            Type="Team",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="4 x 100m Medley relay",
                            Type="Team",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="4 x 200m Freestyle relay",
                            Type="Team",
                            SportID=SportDictionary["Swimming"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Sprint",
                            Type="Individual",
                            SportID=SportDictionary["Triathlon"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Supersprint",
                            Type="Individual",
                            SportID=SportDictionary["Triathlon"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Sprint",
                            Type="Individual",
                            SportID=SportDictionary["Triathlon"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Supersprint",
                            Type="Individual",
                            SportID=SportDictionary["Triathlon"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Beach Vollyball",
                            Type="Team",
                            SportID=SportDictionary["Volleyball - Beach"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Beach Vollyball",
                            Type="Team",
                            SportID=SportDictionary["Volleyball - Beach"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Indoor Vollyball",
                            Type="Team",
                            SportID=SportDictionary["Volleyball - Indoor"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Indoor Vollyball",
                            Type="Team",
                            SportID=SportDictionary["Volleyball - Indoor"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="40-44kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="98 to 120kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 48kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 52kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 56kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 60kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 65kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 70kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 76kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 85kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="up to 98kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="38 to 40kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 44kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 48kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 52kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 56kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 60kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 64kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 69kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 74kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 79kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="up to 84kg",
                            Type="Individual",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        },
                        new Event
                        {
                            Name="Wrestling",
                            Type="Team",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Men"]
                        },
                        new Event
                        {
                            Name="Wrestling",
                            Type="Team",
                            SportID=SportDictionary["Wrestling"],
                            GenderID=GenderDictionary["Women"]
                        }
                    };
                    context.Events.AddRange(theEvents);
                    context.SaveChanges();
                }
                //Get info about the new events
                var events = context.Events.Select(e => new { e.ID, e.GenderID, e.SportID }).ToList();

                //Add Placements to each Event
                if (!context.Placements.Any())
                {
                    foreach (var e in events)
                    {

                        int i = 1;
                        var competitorIDs = from a in context.Athletes
                                            where a.GenderID == e.GenderID && a.SportID == e.SportID
                                            select new { a.ID };
                        foreach (var c in competitorIDs)
                        {
                            Placement p = new Placement()
                            {
                                Place = i,
                                Comments = baconNotes[random.Next(5)],
                                AthleteID = c.ID,
                                EventID = e.ID
                            };
                            context.Placements.Add(p);
                            i++;
                        }
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            //Go on to next
                        }
                    }
                }
            }
        }
    }
}
