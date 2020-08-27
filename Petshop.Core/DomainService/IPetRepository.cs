using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Core.DomainService
{
    public interface IPetRepository
    {
        public IEnumerable<Pet> GetAllPets();
        public Pet AddNewPet(Pet theNewPet);
        public Pet DeletePetById(int theId);
        public IEnumerable<Pet> FindPetsByName(string theName);
        public Pet FindPetByID(int theId);
        public Pet UpdateNameOfPet(Pet updatedPet, string updateValue);
        public Pet UpdateColorOfPet(Pet updatedPet, string updateValue);
        public Pet UpdateSpeciesOfPet(Pet updatedPet, Pet.Species updateValue);
        public Pet UpdateBirthdayOfPet(Pet updatedPet, DateTime updateValue);
        public Pet UpdateSoldDateOfPet(Pet updatedPet, DateTime updateValue);
        public Pet UpdatePreviousOwnerOfPet(Pet updatedPet, string updateValue);
        public Owner AddNewOwner(Owner theNewOwner);
        public Pet UpdatePriceOfPet(Pet updatedPet, long updateValue);
        public IEnumerable<Pet> GetSortedPets();
        public IEnumerable<Pet> FindPetsByColor(string searchValue);
        public IEnumerable<Pet> FindPetsBySpecies(Pet.Species theSearchCriteria);
        public IEnumerable<Pet> SearchPetsByBirthYear(DateTime theDateValue);
        public IEnumerable<Pet> FindPetsBySoldDate(DateTime theSoldValue);
        public IEnumerable<Pet> FindPetsByPreviousOwner(string searchValue);
        public IEnumerable<Pet> FindPetsByPrice(long thePriceValue);
        public IEnumerable<Owner> GetAllOwners();
        public Pet UpdateOwnerOfPet(Pet updatedPet, int ownerId);
        public IEnumerable<Owner> FindOwnerByName(string searchValue);
        public IEnumerable<Owner> FindOwnerByPhonenr(string searchValue);
        public IEnumerable<Owner> FindOwnerByAddress(string searchValue);
        public IEnumerable<Owner> FindOwnerByEmail(string searchValue);
        public Owner FindOwnerByID(int searchId);
        public Owner UpdateFirstNameOfOwner(Owner updatedOwner, string updateValue);
        public Owner UpdateLastNameOfOwner(Owner updatedOwner, string updateValue);
        public Owner UpdateAddressOfOwner(Owner updatedOwner, string updateValue);
        public Owner UpdatePhoneNrOfOwner(Owner updatedOwner, string updateValue);
        public Owner UpdateEmailOfOwner(Owner updatedOwner, string updateValue);
        public Owner DeleteOwnerById(int theId);
        public IEnumerable<Pet> FindAllPetsByOwner(Owner theOwner);
    }
}
