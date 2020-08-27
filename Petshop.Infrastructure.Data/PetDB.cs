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
        public static int theCount = 0;

        
        public static void CreateData()
        {
            allThePets = new List<Pet> {
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-25), PetColor = "grey", PetName = "Hans", PetPreviousOwner= "John Marks", PetSoldDate = DateTime.Now.AddMonths(0), PetSpecies = Pet.Species.Gerbil, PetPrice = 10 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-400), PetColor = "black and white", PetName = "Katia", PetPreviousOwner= "Mark Johnson", PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Cat, PetPrice = 235 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-320), PetColor = "brown", PetName = "Jellybelly", PetPreviousOwner= "Ronald Jasperson", PetSoldDate = DateTime.Now.AddMonths(-5), PetSpecies = Pet.Species.Gerbil, PetPrice = 2 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-50), PetColor = "black", PetName = "Faithful", PetPreviousOwner= "Belinda Hansen", PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Dog, PetPrice = 41 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-81), PetColor = "orange striped", PetName = "Enigma", PetPreviousOwner= "Emanuelle Jackson", PetSoldDate = DateTime.Now.AddMonths(-2), PetSpecies = Pet.Species.Fish, PetPrice = 56 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-691), PetColor = "purple", PetName = "Bob", PetPreviousOwner= "Emanuelle Jackson", PetSoldDate = DateTime.Now.AddMonths(-8), PetSpecies = Pet.Species.Fish, PetPrice = 98 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-259), PetColor = "silver tabby", PetName = "Linea", PetPreviousOwner= "Shiela Sander", PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Cat, PetPrice = 59 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-856), PetColor = "caramel", PetName = "Tommy", PetPreviousOwner= "John Marks", PetSoldDate = DateTime.Now.AddMonths(-15), PetSpecies = Pet.Species.Hamster, PetPrice = 76 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-1576), PetColor = "black", PetName = "Beauty", PetPreviousOwner= "Jesper Marks", PetSoldDate = DateTime.Now.AddMonths(-21), PetSpecies = Pet.Species.Horse, PetPrice = 1090 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-10), PetColor = "white", PetName = "Beatrice", PetPreviousOwner= "Hans Jesperson", PetSoldDate = DateTime.Now, PetSpecies = Pet.Species.Dog, PetPrice = 28 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-33), PetColor = "beige", PetName = "Jumpy", PetPreviousOwner= "Vienna Jackson", PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Rabbit, PetPrice = 100 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-63), PetColor = "spotted brown", PetName = "Cujo", PetPreviousOwner= "Shanaya Saunderson", PetSoldDate = DateTime.Now.AddMonths(-1), PetSpecies = Pet.Species.Dog, PetPrice = 346 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-18), PetColor = "merle", PetName = "Shenna", PetPreviousOwner= "Marie Thompson", PetSoldDate = DateTime.Now, PetSpecies = Pet.Species.Cat, PetPrice = 865 },
                new Pet {PetId = theCount++, PetBirthday = DateTime.Now.AddDays(-156), PetColor = "red", PetName = "Firehoof", PetPreviousOwner= "Niels Schwartz", PetSoldDate = DateTime.Now.AddMonths(-3), PetSpecies = Pet.Species.Horse, PetPrice = 2096 }

            };

        }

        internal static Pet UpdatePriceOfPet(Pet updatedPet, long updateValue)
        {
            throw new NotImplementedException();
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
                foundPets[0].PetPreviousOwner= updateValue;
                return foundPets[0];
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
            Pet deletedPet = (allThePets.Where(pet => pet.PetId == theId)).ToList()[0];
            if(deletedPet != null)
            {
                allThePets = allThePets.Where(pet => pet != deletedPet);
                return deletedPet;
            }
            else
            {
                throw new InvalidDataException(message: "Id not found.");
            }
        }

        internal static Pet AddNewPet(Pet theNewPet)
        {
            theNewPet.PetId = theCount;
            theCount++;
            List<Pet> newPet = new List<Pet> { theNewPet };
            allThePets = allThePets.Concat(newPet);
            return theNewPet;
        }
    }

   
}
