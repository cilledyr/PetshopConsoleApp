﻿using Petshop.Core.DomainService;
using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Petshop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {

        private IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Owner AddNewOwner(string firstname, string lastname, string address, string phonenr, string email)
        {
            Owner theNewOwner = new Owner();
            theNewOwner.OwnerFirstName = firstname;
            theNewOwner.OwnerLastName = lastname;
            theNewOwner.OwnerAddress = address;
            theNewOwner.OwnerPhoneNr = phonenr;
            theNewOwner.OwnerEmail = email;

            return _petRepo.AddNewOwner(theNewOwner);
        }

        public Pet AddNewPet(string thePetName, int theSelectedSpecies, string theColour, DateTime theSelectedBirthday, DateTime theSelectedPurchaseDate, string thePreviousOwner, long thePetPrice)
        {
            Pet theNewPet = new Pet();
            theNewPet.PetName = thePetName;
            switch (theSelectedSpecies)
            {
                case 1:
                    theNewPet.PetSpecies = Pet.Species.Dog;
                    break;
                case 2:
                    theNewPet.PetSpecies = Pet.Species.Cat;
                    break;
                case 3:
                    theNewPet.PetSpecies = Pet.Species.Fish;
                    break;
                case 4:
                    theNewPet.PetSpecies = Pet.Species.Horse;
                    break;
                case 5:
                    theNewPet.PetSpecies = Pet.Species.Hamster;
                    break;
                case 6:
                    theNewPet.PetSpecies = Pet.Species.Gerbil;
                    break;
                case 7:
                    theNewPet.PetSpecies = Pet.Species.Rabbit;
                    break;
           
                default:
                    throw new InvalidDataException(message: "You entered a Species out of bounds.");
            }
            theNewPet.PetColor = theColour;
            theNewPet.PetBirthday = theSelectedBirthday;
            theNewPet.PetSoldDate = theSelectedPurchaseDate;
            theNewPet.PetPreviousOwner = thePreviousOwner;
            theNewPet.PetPrice = thePetPrice;

            return  _petRepo.AddNewPet(theNewPet);

            
        }

        public Owner DeleteOwnerByID(int theId)
        {
            return _petRepo.DeleteOwnerById(theId);
        }

        public Pet DeletePetByID(int theId)
        {
            return _petRepo.DeletePetById(theId);
        }

        public List<Pet> FindAllPetsByOwner(Owner theOwner)
        {
            return _petRepo.FindAllPetsByOwner(theOwner).ToList();
        }

        public Owner FindOwnerByID(int theId)
        {
            return _petRepo.FindOwnerByID(theId);
        }

        public List<Owner> FindOwnersByName(string theName)
        {
            return _petRepo.FindOwnerByName(theName).ToList();
        }

        public Pet FindPetByID(int theNewId)
        {
            return _petRepo.FindPetByID(theNewId);
        }

        public List<Pet> FindPetsByName(string theName)
        {
            return _petRepo.FindPetsByName(theName).ToList();
        }

        public List<Owner> GetAllOwners()
        {
            return _petRepo.GetAllOwners().ToList();
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.GetAllPets().ToList();
        }

        public List<Pet> GetSortedPets()
        {
            return _petRepo.GetSortedPets().ToList();
        }

        public List<Owner> SearchForOwner(int toSearchInt, string searchValue)
        {
            switch (toSearchInt)
            {
                case 1:
                    return _petRepo.FindOwnerByName(searchValue).ToList();
                case 2:
                    return _petRepo.FindOwnerByAddress(searchValue).ToList();
                case 3:
                    return _petRepo.FindOwnerByPhonenr(searchValue).ToList();

                case 4:
                    return _petRepo.FindOwnerByEmail(searchValue).ToList();

                case 5:
                    int searchId;
                    if (int.TryParse(searchValue, out searchId))
                    {
                        return new List<Owner> { _petRepo.FindOwnerByID(searchId) };
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not given me a Nr to search the Id's for.");
                    }
               default:
                    throw new InvalidDataException(message: "Something unexpected went wrong.");
            }
        }

        public List<Pet> SearchForPet(int toSearchInt, string searchValue)
        {
            switch (toSearchInt)
            {
                case 1:
                    return _petRepo.FindPetsByName(searchValue).ToList();
                case 2:
                    return _petRepo.FindPetsByColor(searchValue).ToList();
                case 3:
                    int theSearch;
                    Pet.Species theSearchCriteria = Pet.Species.Dog;
                    if (int.TryParse(searchValue, out theSearch) && theSearch >= 1 && theSearch <= 7)
                    {
                        switch (theSearch)
                        {
                            case 1:
                                theSearchCriteria = Pet.Species.Dog;
                                break;
                            case 2:
                                theSearchCriteria = Pet.Species.Cat;
                                break;
                            case 3:
                                theSearchCriteria = Pet.Species.Fish;
                                break;
                            case 4:
                                theSearchCriteria = Pet.Species.Horse;
                                break;
                            case 5:
                                theSearchCriteria = Pet.Species.Hamster;
                                break;
                            case 6:
                                theSearchCriteria = Pet.Species.Gerbil;
                                break;
                            case 7:
                                theSearchCriteria = Pet.Species.Rabbit;
                                break;
                            default:
                                throw new InvalidDataException(message: "Index for species is out of bounds");
                        }
                    }
                    return _petRepo.FindPetsBySpecies(theSearchCriteria).ToList();

                case 4:
                    DateTime theDateValue = DateTime.Now;
                    if (DateTime.TryParse(searchValue, out theDateValue))
                    {
                        return _petRepo.SearchPetsByBirthYear(theDateValue).ToList() ;
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid date.");
                    }

                case 5:
                    DateTime theSoldValue = DateTime.Now;
                    if (DateTime.TryParse(searchValue, out theSoldValue))
                    {
                        return _petRepo.FindPetsBySoldDate(theSoldValue).ToList() ;
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid date.");
                    }
                case 6:
                    return _petRepo.FindPetsByPreviousOwner(searchValue).ToList();

                case 7:
                    long thePriceValue = 0;
                    if (long.TryParse(searchValue, out thePriceValue))
                    {
                        return _petRepo.FindPetsByPrice(thePriceValue).ToList();
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid price.");
                    }
                case 9:
                    int searchId;
                    if(int.TryParse(searchValue, out searchId))
                    {
                        return new List<Pet> { _petRepo.FindPetByID(searchId) };
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not given me a Nr to search the Id's for.");
                    }
                    

                default:
                    throw new InvalidDataException(message: "Something unexpected went wrong.");
            }
        }

        public Owner UpdateOwner(Owner updatedOwner, int toUpdateInt, string updateValue)
        {
            switch (toUpdateInt)
            {
                case 1:
                    return _petRepo.UpdateFirstNameOfOwner(updatedOwner, updateValue);
                case 2:
                    return _petRepo.UpdateLastNameOfOwner(updatedOwner, updateValue);
                case 3:
                    return _petRepo.UpdateAddressOfOwner(updatedOwner, updateValue);
                case 4:
                    return _petRepo.UpdatePhoneNrOfOwner(updatedOwner, updateValue);
                case 5:
                    return _petRepo.UpdateEmailOfOwner(updatedOwner, updateValue);
                default:
                    throw new InvalidDataException(message: "Something unexpected went wrong.");
            }
        }

        public Pet UpdatePet(Pet updatedPet, int toUpdateInt, string updateValue)
        {
            switch (toUpdateInt)
            {
                case 1:
                    return _petRepo.UpdateNameOfPet(updatedPet, updateValue);
                case 2:
                    return _petRepo.UpdateColorOfPet(updatedPet, updateValue);
                case 3:
                    int theUpdate;
                    Pet.Species theupdatedValue = Pet.Species.Dog;
                    if(int.TryParse(updateValue, out theUpdate) && theUpdate >=1 && theUpdate <=7)
                    {
                        switch (theUpdate)
                        {
                            case 1:
                                theupdatedValue = Pet.Species.Dog;
                                break;
                            case 2:
                                theupdatedValue = Pet.Species.Cat;
                                break;
                            case 3:
                                theupdatedValue = Pet.Species.Fish;
                                break;
                            case 4:
                                theupdatedValue = Pet.Species.Horse;
                                break;
                            case 5:
                                theupdatedValue = Pet.Species.Hamster;
                                break;
                            case 6:
                                theupdatedValue = Pet.Species.Gerbil;
                                break;
                            case 7:
                                theupdatedValue = Pet.Species.Rabbit;
                                break;
                            default:
                                throw new InvalidDataException(message: "Index for species is out of bounds");
                        }
                    }
                    return _petRepo.UpdateSpeciesOfPet(updatedPet, theupdatedValue);

                case 4:
                    DateTime theUpdateValue = DateTime.Now;
                    if(DateTime.TryParse(updateValue, out theUpdateValue))
                    {
                        return _petRepo.UpdateBirthdayOfPet(updatedPet, theUpdateValue);
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid date.");
                    }

                case 5:
                    DateTime theSoldUpdateValue = DateTime.Now;
                    if (DateTime.TryParse(updateValue, out theSoldUpdateValue))
                    {
                        return _petRepo.UpdateSoldDateOfPet(updatedPet, theSoldUpdateValue);
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid date.");
                    }
                case 6:
                    return _petRepo.UpdatePreviousOwnerOfPet(updatedPet, updateValue);
                case 7:
                    long thePriceValue = 0;
                    if (long.TryParse(updateValue, out thePriceValue))
                    {
                        return _petRepo.UpdatePriceOfPet(updatedPet, thePriceValue);
                    }
                    else
                    {
                        throw new InvalidDataException(message: "You have not entered a valid price.");
                    }

                default:
                    throw new InvalidDataException(message: "Something unexpected went wrong.");
            }
        }
    }
}