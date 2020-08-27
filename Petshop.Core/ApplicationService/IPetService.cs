﻿using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();
        public Pet AddNewPet(string thePetName, int theSelectedSpecies, string theColour, DateTime theSelectedBirthday, DateTime theSelectedPurchaseDate, string thePreviousOwner, long thePetPrice);
        public Pet DeletePetByID(int theId);
        public List<Pet> FindPetsByName(string theName);
        public Pet FindPetByID(int theId);
        public Pet UpdatePet(Pet updatedPet, int toUpdateInt, string updateValue);
        public List<Pet> GetSortedPets();
        public List<Pet> SearchForPet(int toSearchInt, string searchValue);
        public List<Owner> GetAllOwners();
        public List<Owner> SearchForOwner(int toSearchInt, string searchValue);
        public Owner AddNewOwner(string firstname, string lastname, string address, string phonenr, string email);
        public List<Owner> FindOwnersByName(string theName);
        public Owner FindOwnerByID(int theId);
        public Owner UpdateOwner(Owner updatedOwner, int toUpdateInt, string updateValue);
        public Owner DeleteOwnerByID(int theId);
        public List<Pet> FindAllPetsByOwner(Owner theOwner);
    }
}