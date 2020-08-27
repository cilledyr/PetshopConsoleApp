using Petshop.Core.DomainService;
using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Petshop.Infrastructure.Data
{
    public sealed class PetRepository : IPetRepository
    {
        private static PetRepository instance = null;
        private static readonly object padlock = new object();
        PetRepository()
        {

        }

        public static PetRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new PetRepository();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return PetDB.allThePets;
        }

        public Pet AddNewPet(Pet theNewPet)
        {
            return PetDB.AddNewPet(theNewPet);
        }

        public Pet DeletePetById(int theId)
        {
            return PetDB.DeletePetById(theId);
        }

        public IEnumerable<Pet> FindPetsByName(string theName)
        {
            IEnumerable<Pet> petsByName = PetDB.allThePets.Where(pet => pet.PetName.Contains(theName));
            return petsByName;
        }

        public Pet FindPetByID(int theId)
        {
            List<Pet> foundPets = (PetDB.allThePets.Where(pet => pet.PetId == theId)).ToList();
            if (foundPets.Count <= 0 || foundPets.Count > 1)
            {
                throw new Exception(message: "I am sorry wrong amonut of pets found by ID.");
            }
            else
            {
                return foundPets[0];
            }
        }

        public Pet UpdateNameOfPet(Pet updatedPet, string updateValue)
        {
            return PetDB.UpdateNameOfPet(updatedPet, updateValue);
        }

        public Pet UpdateColorOfPet(Pet updatedPet, string updateValue)
        {
            return PetDB.UpdateColourOfPet(updatedPet, updateValue);
        }

        public Pet UpdateSpeciesOfPet(Pet updatedPet, Pet.Species updateValue)
        {
            return PetDB.UpdateSpeciesOfPet(updatedPet, updateValue);
        }

        public Pet UpdateBirthdayOfPet(Pet updatedPet, DateTime updateValue)
        {
            return PetDB.UpdateBirthdayOfPet(updatedPet, updateValue);
        }

        public Pet UpdateSoldDateOfPet(Pet updatedPet, DateTime updateValue)
        {
            return PetDB.UpdateSoldDateOfPet(updatedPet, updateValue);
        }

        public Pet UpdatePreviousOwnerOfPet(Pet updatedPet, string updateValue)
        {
            return PetDB.UpdatePreviousOwnerOfPet(updatedPet, updateValue);
        }

        public Pet UpdatePriceOfPet(Pet updatedPet, long updateValue)
        {
            return PetDB.UpdatePriceOfPet(updatedPet, updateValue);
        }

        public IEnumerable<Pet> GetSortedPets()
        {
            IEnumerable<Pet> sortedPets = PetDB.allThePets.OrderBy(pet => pet.PetPrice);
            return sortedPets;
        }

        public IEnumerable<Pet> FindPetsByColor(string searchValue)
        {
            IEnumerable<Pet> coloredPets = PetDB.allThePets.Where(pet => pet.PetColor.Equals(searchValue));
            return coloredPets;
        }

        public IEnumerable<Pet> FindPetsBySpecies(Pet.Species theSearchCriteria)
        {
            IEnumerable<Pet> petsBySpecies = PetDB.allThePets.Where(pet => pet.PetSpecies == theSearchCriteria);
            return petsBySpecies;
        }

        public IEnumerable<Pet> SearchPetsByBirthYear(DateTime theDateValue)
        {
            IEnumerable<Pet> petsByBirthyear = PetDB.allThePets.Where(pet => pet.PetBirthday.Year == theDateValue.Year);
            return petsByBirthyear;
        }

        public IEnumerable<Pet> FindPetsBySoldDate(DateTime theSoldValue)
        {
            IEnumerable<Pet> petsBySoldyear = PetDB.allThePets.Where(pet => pet.PetSoldDate.Year == theSoldValue.Year);
            return petsBySoldyear;
        }

        public IEnumerable<Pet> FindPetsByPreviousOwner(string searchValue)
        {
            IEnumerable<Pet> petsByPreviousOwners = PetDB.allThePets.Where(pet => pet.PetPreviousOwner.Contains(searchValue));
            return petsByPreviousOwners;
        }

        public IEnumerable<Pet> FindPetsByPrice(long thePriceValue)
        {
            IEnumerable<Pet> petsByPrice = PetDB.allThePets.Where(pet => pet.PetPrice <= thePriceValue - 10 && pet.PetPrice <= thePriceValue + 10 );
            return petsByPrice;
        }

        public Pet UpdateOwnerOfPet(Pet updatedPet, Owner updatedOwner)
        {
            return PetDB.UpdateOwnerOfPet(updatedPet, updatedOwner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return PetDB.allTheOwners;
        }

        public IEnumerable<Owner> FindOwnerByName(string searchValue)
        {
            IEnumerable<Owner> ownerByName = PetDB.allTheOwners.Where(owner => owner.OwnerFirstName.Contains(searchValue) || owner.OwnerLastName.Contains(searchValue));
            return ownerByName;
        }

        public IEnumerable<Owner> FindOwnerByPhonenr(string searchValue)
        {
            IEnumerable<Owner> ownerByPhone = PetDB.allTheOwners.Where(owner => owner.OwnerPhoneNr.Contains(searchValue));
            return ownerByPhone;
        }

        public IEnumerable<Owner> FindOwnerByAddress(string searchValue)
        {
            IEnumerable<Owner> ownerByAddress = PetDB.allTheOwners.Where(owner => owner.OwnerAddress.Contains(searchValue));
            return ownerByAddress;
        }

        public IEnumerable<Owner> FindOwnerByEmail(string searchValue)
        {
            IEnumerable<Owner> ownerByEmail = PetDB.allTheOwners.Where(owner => owner.OwnerEmail.Contains(searchValue));
            return ownerByEmail;
        }

        public Owner FindOwnerByID(int searchId)
        {
            List<Owner> foundOwners = (PetDB.allTheOwners.Where(owner => owner.OwnerId == searchId)).ToList();
            if (foundOwners.Count <= 0 || foundOwners.Count > 1)
            {
                throw new Exception(message: "I am sorry wrong amonut of pets found by ID.");
            }
            else
            {
                return foundOwners[0];
            }
        }

        public Owner AddNewOwner(Owner theNewOwner)
        {
            return PetDB.addNewOwner(theNewOwner);
        }

        public Owner UpdateFirstNameOfOwner(Owner updatedOwner, string updateValue)
        {
            return PetDB.updateOwnerFirstName(updatedOwner, updateValue);
        }

        public Owner UpdateLastNameOfOwner(Owner updatedOwner, string updateValue)
        {
            return PetDB.updateOwnerLastName(updatedOwner, updateValue);
        }

        public Owner UpdateAddressOfOwner(Owner updatedOwner, string updateValue)
        {
            return PetDB.updateOwnerAddress(updatedOwner, updateValue);
        }

        public Owner UpdatePhoneNrOfOwner(Owner updatedOwner, string updateValue)
        {
            return PetDB.updateOwnerPhoneNr(updatedOwner, updateValue);
        }

        public Owner UpdateEmailOfOwner(Owner updatedOwner, string updateValue)
        {
            return PetDB.updateOwnerEmail(updatedOwner, updateValue);
        }

        public Owner DeleteOwnerById(int theId)
        {
            return PetDB.DeleteOwnerById(theId);
        }

        public IEnumerable<Pet> FindAllPetsByOwner(Owner theOwner)
        {
            IEnumerable<Pet> petsByOwner = PetDB.allThePets.Where(pet => pet.PetOwner == theOwner);
            return petsByOwner;
        }
    }
}
