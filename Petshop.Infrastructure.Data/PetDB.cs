using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Petshop.Infrastructure.Data
{
    public static class PetDB
    {
        public static IEnumerable<Pet> allThePets { get; set; }
        public static IEnumerable<Owner> allTheOwners { get; set; }
        public static int thePetCount { get; set; }
        public static int theOwnerCount { get; set; }

        
        public static void CreateData()
        {
            thePetCount = 0;
            theOwnerCount = 0;
            allTheOwners = new List<Owner>
            {
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Lars", OwnerLastName = "Rasmussen", OwnerAddress = "SweetStreet 4, 6700 Esbjerg", OwnerPhoneNr = "+45 1234 5678", OwnerEmail = "lars@rasmussen.dk"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "John", OwnerLastName = "Jackson", OwnerAddress = "The Alley 6, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 2549 6254", OwnerEmail = "thesuper_awesome@hotmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Maria", OwnerLastName = "Saunderson", OwnerAddress = "Kongensgade 33, 6700 Esbjerg", OwnerPhoneNr = "+45 8761 1624", OwnerEmail = "suuper_sexy88@gmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Belinda", OwnerLastName = "Twain", OwnerAddress = "Nørregade 14, 6700 Esbjerg", OwnerPhoneNr = "+45 7365 5976", OwnerEmail = "blender_wizard@hotmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Roald", OwnerLastName = "Schwartz", OwnerAddress = "Lark Road 26, 6715 Esbjerg N", OwnerPhoneNr = "+45 7618 5234", OwnerEmail = "the_cool_roald@msnmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Shiela", OwnerLastName = "Jesperson", OwnerAddress = "Daniels Road 45, 6700 Esbjerg", OwnerPhoneNr = "+45 7831 2561", OwnerEmail = "shiela45@gmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Hansi", OwnerLastName = "Thompson", OwnerAddress = "Spooky Road 666, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 1465 2845", OwnerEmail = "theghost83@outlook.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Victoria", OwnerLastName = "Marks", OwnerAddress = "Birkelunden 8, 6705 Esbjerg Ø", OwnerPhoneNr = "+45 5956 4651", OwnerEmail = "vicmarks@hotmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Niels", OwnerLastName = "Billson", OwnerAddress = "Folevej 3, 6715 Esbjerg N", OwnerPhoneNr = "+45 7286 9435", OwnerEmail = "ne49billson@gmail.com"},
                new Owner{OwnerId = theOwnerCount++, OwnerFirstName = "Emanuelle", OwnerLastName = "Johnson", OwnerAddress = "Foldgårdsvej 17, 6715 Esbjerg N", OwnerPhoneNr = "+45 7315 4255", OwnerEmail = "emanuelle-actor@outlook.com"}
            };

            allThePets = new List<Pet> {
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-25), PetColor = "grey", PetName = "Hans", PetPreviousOwner = "Aniyah Chan", PetOwner= allTheOwners.ToList()[0], PetSoldDate = DateTime.Now.AddMonths(0), PetSpecies = Pet.Species.Gerbil, PetPrice = 10 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-400), PetColor = "black and white", PetName = "Katia", PetPreviousOwner = "Alison Melia", PetOwner= allTheOwners.ToList()[1], PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Cat, PetPrice = 235 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-320), PetColor = "brown", PetName = "Jellybelly", PetPreviousOwner = "Abdallah Dejesus", PetOwner= allTheOwners.ToList()[2], PetSoldDate = DateTime.Now.AddMonths(-5), PetSpecies = Pet.Species.Gerbil, PetPrice = 2 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-50), PetColor = "black", PetName = "Faithful", PetPreviousOwner = "Teegan Boyer", PetOwner= allTheOwners.ToList()[3], PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Dog, PetPrice = 41 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-81), PetColor = "orange striped", PetName = "Enigma", PetPreviousOwner = "Vinnie Odling", PetOwner= allTheOwners.ToList()[4], PetSoldDate = DateTime.Now.AddMonths(-2), PetSpecies = Pet.Species.Fish, PetPrice = 56 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-691), PetColor = "purple", PetName = "Bob", PetPreviousOwner = "Amina Brookes", PetOwner= allTheOwners.ToList()[4], PetSoldDate = DateTime.Now.AddMonths(-8), PetSpecies = Pet.Species.Fish, PetPrice = 98 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-259), PetColor = "silver tabby", PetName = "Linea", PetPreviousOwner = "Carmel Livingson", PetOwner= allTheOwners.ToList()[5], PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Cat, PetPrice = 59 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-856), PetColor = "caramel", PetName = "Tommy", PetPreviousOwner = "Nicole Jaramillo", PetOwner= allTheOwners.ToList()[6], PetSoldDate = DateTime.Now.AddMonths(-15), PetSpecies = Pet.Species.Hamster, PetPrice = 76 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-1576), PetColor = "black", PetName = "Beauty", PetPreviousOwner = "Hibah Bartlet", PetOwner= allTheOwners.ToList()[7], PetSoldDate = DateTime.Now.AddMonths(-21), PetSpecies = Pet.Species.Horse, PetPrice = 1090 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-10), PetColor = "white", PetName = "Beatrice", PetPreviousOwner = "Radhika Baird", PetOwner= allTheOwners.ToList()[8], PetSoldDate = DateTime.Now, PetSpecies = Pet.Species.Dog, PetPrice = 28 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-33), PetColor = "beige", PetName = "Jumpy", PetPreviousOwner = "Havin Boyle", PetOwner= allTheOwners.ToList()[0], PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Rabbit, PetPrice = 100 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-63), PetColor = "spotted brown", PetName = "Cujo", PetPreviousOwner = "Franklin Barajas", PetOwner= allTheOwners.ToList()[9], PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Dog, PetPrice = 346 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-18), PetColor = "merle", PetName = "Shenna", PetPreviousOwner = "Jovan Bloggs", PetOwner= allTheOwners.ToList()[1], PetSoldDate = DateTime.Now, PetSpecies = Pet.Species.Cat, PetPrice = 865 },
                new Pet {PetId = thePetCount++, PetBirthday = DateTime.Now.AddDays(-156), PetColor = "red", PetName = "Firehoof", PetPreviousOwner = "Aamna Atherton", PetOwner= allTheOwners.ToList()[7], PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Horse, PetPrice = 2096 }

            };

            

        }

        internal static Owner updateOwnerLastName(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerLastName = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerAddress(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerAddress = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner DeleteOwnerById(int theId)
        {
            List<Owner> deletedOwner = (allTheOwners.Where(owner => owner.OwnerId == theId)).ToList();

            if (deletedOwner.Count == 1)
            {
                allThePets = allThePets.Where(pet => pet.PetOwner != deletedOwner[0]);
                allTheOwners = allTheOwners.Where(owner => owner != deletedOwner[0]);
                return deletedOwner[0];
            }
            else
            {
                throw new InvalidDataException(message: "Wrong number of the id have been found.");
            }
        }

        internal static Owner updateOwnerPhoneNr(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerPhoneNr = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerEmail(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerEmail = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner updateOwnerFirstName(Owner updatedOwner, string updateValue)
        {
            List<Owner> foundOwners = (allTheOwners.Where(owner => owner == updatedOwner)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of owners found");
            }
            else
            {
                foundOwners[0].OwnerFirstName = updateValue;
                return foundOwners[0];
            }
        }

        internal static Owner addNewOwner(Owner theNewOwner)
        {
            theNewOwner.OwnerId = theOwnerCount;
            theOwnerCount++;
            List<Owner> newOwner = new List<Owner> { theNewOwner };
            allTheOwners = allTheOwners.Concat(newOwner);
            return theNewOwner;
        }

        internal static Pet UpdatePreviousOwnerOfPet(Pet updatedPet, string updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetPreviousOwner = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdatePriceOfPet(Pet updatedPet, long updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetPrice = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdateOwnerOfPet(Pet updatedPet, int ownerId)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count != 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                List<Owner> theOwner = allTheOwners.Where(owner => owner.OwnerId == ownerId).ToList();
                if(theOwner.Count == 1)
                {
                    foundPets[0].PetOwner = theOwner[0];
                    return foundPets[0];
                }
                else
                {
                    throw new InvalidDataException(message: "I am sorry the owner id seems invalid.");
                }
                
            }
        }

        internal static Pet UpdateSoldDateOfPet(Pet updatedPet, DateTime updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetSoldDate = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdateBirthdayOfPet(Pet updatedPet, DateTime updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetBirthday = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdateSpeciesOfPet(Pet updatedPet, Pet.Species updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetSpecies = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdateColourOfPet(Pet updatedPet, string updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetColor = updateValue;
                return foundPets[0];
            }
        }

        internal static Pet UpdateNameOfPet(Pet updatedPet, string updateValue)
        {
            List<Pet> foundPets = (allThePets.Where(pet => pet == updatedPet)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new InvalidDataException(message: "I am sorry wrong amonut of pets found");
            }
            else
            {
                foundPets[0].PetName = updateValue;
                return foundPets[0];
            }

        }

        internal static Pet DeletePetById(int theId)
        {
            List<Pet> deletedPets = (allThePets.Where(pet => pet.PetId == theId)).ToList();
            if(deletedPets.Count == 1)
            {
                allThePets = allThePets.Where(pet => pet != deletedPets[0]);
                return deletedPets[0];
            }
            else
            {
                throw new InvalidDataException(message: "Wrong amount of Id's located.");
            }
        }

        internal static Pet AddNewPet(Pet theNewPet)
        {
            theNewPet.PetId = thePetCount;
            thePetCount++;
            List<Pet> newPet = new List<Pet> { theNewPet };
            allThePets = allThePets.Concat(newPet);
            return theNewPet;
        }
    }

   
}
