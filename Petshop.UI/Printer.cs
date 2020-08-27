﻿using Petshop.Core.ApplicationService;
using Petshop.Core.Enteties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Petshop.UI
{
    public class Printer
    {
        public static IPetService _petService;
        public static List<string> menuItems = new List<string>
        {
            "1: List All Pets",
            "2: Add a new pet",
            "3: Delete a pet",
            "4: Update an existing pet",
            "5: Sort pets",
            "6: Cheapest 5 pets",
            "7: Search all pets",
            "8: Go to Owner Menu",
            "9: Exit Program"
        };

        public static List<string> ownerMenuItems = new List<string>
        {
            "1: Search all owners",
            "2: List all owners",
            "3: Add new Owner",
            "4: Delete Owner and all his pets",
            "5: Edit existing owner",
            "6: Find pets by owner",
            "7: Back to Pet Menu",
            "8: Exit the program"
        };
        public Printer (IPetService petservice)
        {
            _petService = petservice;
        }
        public void DisplayMenu(string userName)
        {
            Console.WriteLine("\n \n");
            Console.WriteLine($"Please make a selection from the menu, type the nr of the selection you want to make, {userName}");
            foreach (var menuItem in menuItems)
            {
                Console.WriteLine(menuItem);
            }
            Console.WriteLine("\n");
            var selection = Console.ReadLine();
            int menuItemSelected;
            if (int.TryParse(selection, out menuItemSelected))
            {
                switch (menuItemSelected)
                {
                    case 1:
                        ListAllPets(userName);
                        break;
                    case 2:
                        AddNewPet(userName);
                        break;
                    case 3:
                        DeletePet(userName);
                        break;
                    case 4:
                        UpdatePet(userName);
                        break;
                    case 5:
                        SortPets(userName);
                        break;
                    case 6:
                        Find5Cheapest(userName);
                        break;
                    case 7:
                        SearchPets(userName);
                        break;
                    case 8:
                        DisplayOwnerMenu(userName);
                        break;
                    case 9:
                        ExitProgram(userName);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("You entered a wrong menu selection, please try again.");
                DisplayMenu(userName);
            }
        }

        private void DisplayOwnerMenu(string userName)
        {
            Console.WriteLine("\n \n");
            Console.WriteLine($"Please make a selection from the menu, type the nr of the selection you want to make, {userName}");
            foreach (var menuItem in ownerMenuItems)
            {
                Console.WriteLine(menuItem);
            }
            Console.WriteLine("\n");
            var selection = Console.ReadLine();
            int menuItemSelected;
            if (int.TryParse(selection, out menuItemSelected))
            {
                switch (menuItemSelected)
                {
                    case 1:
                        SearchOwner(userName);
                        break;
                    case 2:
                        ListAllOwners(userName);
                        break;
                    case 3:
                        AddNewOwner(userName);
                        break;
                    case 4:
                        DeleteOwner(userName);
                        break;
                    case 5:
                        EditOwner(userName);
                        break;
                    case 6:
                        FindPetsByOwner(userName);
                        break;
                    case 7:
                        DisplayMenu(userName);
                        break;
                    case 8:
                        ExitProgram(userName);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("You entered a wrong menu selection, please try again.");
                DisplayMenu(userName);
            }
        }

        private void FindPetsByOwner(string userName)
        {
            Console.WriteLine($"Ok {userName}, please enter the name or the id of the owner whose pets you would like to see:");
            var theName = Console.ReadLine();
            int theId;
            Owner lookingFor = null;
            if(int.TryParse(theName, out theId))
            {
                lookingFor = _petService.FindOwnerByID(theId);
            }
            else
            {
                List<Owner> theLookedForOwners = _petService.FindOwnersByName(theName);
                if(theLookedForOwners.Count <= 0)
                {
                    Console.WriteLine($"I am sorry {userName}, I could not find any owners with that name, please start over.");
                    FindPetsByOwner(userName);
                }
                else if(theLookedForOwners.Count == 1)
                {
                    lookingFor = theLookedForOwners[0];
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName} i have found {theLookedForOwners.Count} Owners by that name:");
                    foreach (var owner in theLookedForOwners)
                    {
                        Console.WriteLine($"Owner Id: {owner.OwnerId}, Name: {owner.OwnerFirstName} {owner.OwnerLastName}, Address: {owner.OwnerAddress}, Phonenr: {owner.OwnerPhoneNr}, Email: {owner.OwnerEmail}");
                    }
                    Console.WriteLine($"Please enter the ID of the owner whose pets you want to see:");
                    if(int.TryParse(Console.ReadLine(), out theId))
                    {
                        lookingFor = _petService.FindOwnerByID(theId);
                    }
                    else
                    {
                        Console.WriteLine($"You have not given me a valid ID, please try again.");
                        FindPetsByOwner(userName);
                    }

                }
            }
            if(lookingFor != null)
            {
                List<Pet> allTheFoundPets = _petService.FindAllPetsByOwner(lookingFor);
                Console.WriteLine($"Here is your complete list of pets owned by {lookingFor.OwnerFirstName} {lookingFor.OwnerLastName}:");
                foreach ( var pet in allTheFoundPets)
                {
                    Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");
                }
                DisplayOwnerMenu(userName);
            }
        }

        private void DeleteOwner(string userName)
        {
            Console.WriteLine($"{userName}, please enter the Name, or ID of the owner you would like to delete: ");
            var theName = Console.ReadLine();
            int theId;
            Owner deletedOwner = null;
            if (int.TryParse(theName, out theId))
            {
                deletedOwner = _petService.DeleteOwnerByID(theId);
            }
            else
            {
                List<Owner> ownersByName = _petService.FindOwnersByName(theName);
                if (ownersByName.Count <= 0)
                {
                    Console.WriteLine($"I am sorry {userName}, i couldn't find any owners by that name, please start over.");
                    DeletePet(userName);
                }
                else if (ownersByName.Count == 1)
                {
                    deletedOwner = _petService.DeleteOwnerByID(ownersByName[0].OwnerId);
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName}, there is more than one owner with that name: \n");

                    foreach (var owner in ownersByName)
                    {
                        Console.WriteLine($"Owner Id: {owner.OwnerId}, Name: {owner.OwnerFirstName} {owner.OwnerLastName}, Address: {owner.OwnerAddress}, Phonenr: {owner.OwnerPhoneNr}, Email: {owner.OwnerEmail}");
                    }

                    Console.WriteLine($"Please enter the ID of the owner you want to delete:");
                    var newId = Console.ReadLine();
                    int theNewId;
                    if (int.TryParse(newId, out theNewId))
                    {
                        deletedOwner = _petService.DeleteOwnerByID(theNewId);
                    }
                    else
                    {
                        Console.WriteLine($" I am sorry {userName} have not entered a valid ID, starting over.");
                        DeletePet(userName);
                    }
                }
            }
            Console.WriteLine($"{userName}, you have successfully deleted {deletedOwner.OwnerFirstName} {deletedOwner.OwnerLastName}, from your database.");
            DisplayOwnerMenu(userName);
        }

        private void EditOwner(string userName)
        {
            Console.WriteLine($"{userName}, please enter the Name, or ID of the owner you would like to update: ");
            var theName = Console.ReadLine();
            int theId;
            Owner updatedOwner = null;
            if (int.TryParse(theName, out theId))
            {
                updatedOwner = _petService.FindOwnerByID(theId);
            }
            else
            {
                List<Owner> ownersByName = _petService.FindOwnersByName(theName);
                if (ownersByName.Count <= 0)
                {
                    Console.WriteLine($"I am sorry {userName}, i couldn't find any owner by that name, please start over.");
                    DeleteOwner(userName);

                }
                else if (ownersByName.Count == 1)
                {
                    updatedOwner = _petService.FindOwnerByID(ownersByName[0].OwnerId);
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName}, there is more than one owner with that name: \n");

                    foreach (var owner in ownersByName)
                    {
                        Console.WriteLine($"Owner Id: {owner.OwnerId}, Name: {owner.OwnerFirstName} {owner.OwnerLastName}, Address: {owner.OwnerAddress}, Phonenr: {owner.OwnerPhoneNr}, Email: {owner.OwnerEmail}");
                    }

                    Console.WriteLine($"Please enter the ID of the owner you want to update:");
                    var newId = Console.ReadLine();
                    int theNewId;
                    if (int.TryParse(newId, out theNewId))
                    {
                        updatedOwner = _petService.FindOwnerByID(theNewId);
                    }
                    else
                    {
                        Console.WriteLine($" I am sorry {userName}, you have not entered a valid ID, starting over.");
                        UpdatePet(userName);
                    }
                }
            }
            if (updatedOwner != null)
            {
                Console.WriteLine($"{userName}, you are updating ID: {updatedOwner.OwnerId} byt the name {updatedOwner.OwnerFirstName} {updatedOwner.OwnerLastName}. What would you like to update, of the following, Please type the nr only.?");
                Console.WriteLine(" 1: First Name \n 2: LastName \n 3: Address \n 4: Phonenr \n 5: Email \n ");
                var toUpdate = Console.ReadLine();
                int toUpdateInt = 0;
                string updateValue;
                if (int.TryParse(toUpdate, out toUpdateInt) && toUpdateInt <= 5 && toUpdateInt > 0)
                {
                    switch (toUpdateInt)
                    {
                        case 1:
                            Console.WriteLine($"What would you like to update the First Name to be? Current first name is: {updatedOwner.OwnerFirstName}.");
                            break;
                        case 2:
                            Console.WriteLine($"What would you like to update the Last Name to be? Current last name is: {updatedOwner.OwnerLastName}.");
                            break;
                        case 3:
                            Console.WriteLine($"What would you like to update the Address to be? Current address is: {updatedOwner.OwnerAddress}");
                            break;
                        case 4:
                            Console.WriteLine($"What would you like to update the Phonenr to be? Current phonenr is: {updatedOwner.OwnerPhoneNr}.");
                            break;
                        case 5:
                            Console.WriteLine($"What would you like to update the Email to be? Current email is: {updatedOwner.OwnerEmail}.");
                            break;
                        default:
                            break;
                    }
                    updateValue = Console.ReadLine();
                    updatedOwner = _petService.UpdateOwner(updatedOwner, toUpdateInt, updateValue);
                }
            }

            else
            {
                throw new InvalidDataException(message: "I am sorry i have found an error, could not find the owner to update.");
            }


            Console.WriteLine($"{userName}, you have successfully updated {updatedOwner.OwnerFirstName} {updatedOwner.OwnerLastName}, in your database.");
            DisplayOwnerMenu(userName);
        }

        private void AddNewOwner(string userName)
        {
            Console.WriteLine($"You are about to create a new owner {userName}, what is the first name of this owner?");
            var firstname = Console.ReadLine();
            Console.WriteLine($"Thank you {userName}, what is {firstname}'s last name?");
            var lastname = Console.ReadLine();
            Console.WriteLine($"Please enter {firstname}, {lastname}'s address:");
            var address = Console.ReadLine();
            Console.WriteLine($"We are almost done, please enter {firstname} {lastname}'s phonenr:");
            var phonenr = Console.ReadLine();
            Console.WriteLine($"Lastly we ´need {firstname} {lastname}'s email:");
            var email = Console.ReadLine();

            Owner theNewOwner = _petService.AddNewOwner(firstname, lastname, address, phonenr, email);
            Console.WriteLine($"Nice {userName}, you have successfully added {theNewOwner.OwnerFirstName} {theNewOwner.OwnerLastName} to the Database.");

            DisplayOwnerMenu(userName);
        }

        private void ListAllOwners(string userName)
        {
            List<Owner> allOwners = _petService.GetAllOwners();
            Console.WriteLine($"Here is a list of all the owners currently registered.");
            foreach (var owner in allOwners)
            {
                Console.WriteLine($"Owner Id: {owner.OwnerId}, Name: {owner.OwnerFirstName} {owner.OwnerLastName}, Address: {owner.OwnerAddress}, Phonenr: {owner.OwnerPhoneNr}, Email: {owner.OwnerEmail}");
            }
            DisplayOwnerMenu(userName);
        }

        private void SearchOwner(string userName)
        {
            {
                Console.WriteLine($"{userName}, which of the following would you like to search?, of the following, Please type the nr only.?");
                Console.WriteLine(" 1: Name \n 2: Address \n 3: Phonenr \n 4: Email \n 5: Id \n");
                var toSearch = Console.ReadLine();
                int toSearchInt = 0;
                string searchValue;
                if (int.TryParse(toSearch, out toSearchInt) && toSearchInt <= 5 && toSearchInt > 0)
                {
                    Console.WriteLine("Please enter what to search for below:");
                    searchValue = Console.ReadLine();

                    List<Owner> searchedOwner = _petService.SearchForOwner(toSearchInt, searchValue);
                    Console.WriteLine($"Here is your result {userName}.");
                    foreach (var owner in searchedOwner)
                    {
                        Console.WriteLine($"Owner Id: {owner.OwnerId}, Name: {owner.OwnerFirstName} {owner.OwnerLastName}, Address: {owner.OwnerAddress}, Phonenr: {owner.OwnerPhoneNr}, Email: {owner.OwnerEmail}");
                    }
                    DisplayOwnerMenu(userName);
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName}, it looks like i can't search for that, please try again.");
                    SearchOwner(userName);
                }
            }
        }

        private void ExitProgram(string userName)
        {
            Console.WriteLine($"Goodbye {userName}");
            Environment.Exit(0);
        }

        private void SearchPets(string userName)
        {
            Console.WriteLine($"{userName}, which of the following would you like to search?, of the following, Please type the nr only.?");
            Console.WriteLine(" 1: Name \n 2: Colour \n 3: Species \n 4: Birthday \n 5: Sold Date \n 6: PreviousOwner \n 7: Price \n 8: Id \n 9: Owner \n");
            var toSearch = Console.ReadLine();
            int toSearchInt = 0;
            string searchValue;
            if (int.TryParse(toSearch, out toSearchInt) && toSearchInt <= 9 && toSearchInt > 0)
            {
                if(toSearchInt == 3)
                {
                    Console.WriteLine($"Thank you {userName}, now please enter the species from one of the following, enter the nr only: \n");
                    int theSpeciesNr = 0;
                    foreach (var theSpecies in Enum.GetNames(typeof(Pet.Species)))
                    {
                        theSpeciesNr++;
                        Console.WriteLine(theSpeciesNr + ": " + theSpecies);
                    }
                }
                else if(toSearchInt == 9)
                {
                    Console.WriteLine($"Ok {userName}, sending you to search for a specific owner and their pets.");
                    FindPetsByOwner(userName);
                }
                else
                {
                    Console.WriteLine("Please enter what to search for below, if searching for a birthday or SoldDate, please use the format: dd-mm-yyyy, only the year will be used. \n Price searched for will be +- 10£, for price enter only a nr please.");
                }
                searchValue = Console.ReadLine();
                
                List<Pet> searchedPets = _petService.SearchForPet(toSearchInt, searchValue);
                Console.WriteLine($"Here is your result {userName}.");
                foreach (var pet in searchedPets)
                {
                    Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");
                }
                DisplayMenu(userName);
            }
            else
            {
                Console.WriteLine($"I am sorry {userName}, it looks like i can't search for that, please try again.");
                SearchPets(userName);
            }
        }

        private void Find5Cheapest(string userName)
        {
            Console.WriteLine($"Here you go {userName}, the list of the five cheapest pets currently: ");
            List<Pet> sortedPets = _petService.GetSortedPets();
            for(int i = 0; i<5; i++ )
            {
                Pet pet = sortedPets[i];
                Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");
            }
            DisplayMenu(userName);
        }

        private void SortPets(string userName)
        {
            List<Pet> sortedPets = _petService.GetSortedPets();
            Console.WriteLine($"Here is the list of pets sorted by price");
            foreach (var pet in sortedPets)
            {
                Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");
            }
            DisplayMenu(userName);
        }

        private void UpdatePet(string userName)
        {
            Console.WriteLine($"{userName}, please enter the Name, or ID of the pet you would like to update for: ");
            var theName = Console.ReadLine();
            int theId;
            Pet updatedPet = null;
            if (int.TryParse(theName, out theId))
            {
                updatedPet = _petService.FindPetByID(theId);
            }
            else
            {
                List<Pet> petsByName = _petService.FindPetsByName(theName);
                if (petsByName.Count <= 0)
                {
                    Console.WriteLine($"I am sorry {userName}, i couldn't find any pet by that name, please start over.");
                    UpdatePet(userName);

                }
                else if (petsByName.Count == 1)
                {
                    updatedPet = _petService.FindPetByID(petsByName[0].PetId);
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName}, there is more than one pet with that name: \n");

                    foreach (var pet in petsByName)
                    {
                        Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");

                    }

                    Console.WriteLine($"Please enter the ID of the pet you want to update:");
                    var newId = Console.ReadLine();
                    int theNewId;
                    if (int.TryParse(newId, out theNewId))
                    {
                        updatedPet = _petService.FindPetByID(theNewId);
                    }
                    else
                    {
                        Console.WriteLine($" I am sorry {userName}, you have not entered a valid ID, starting over.");
                        UpdatePet(userName);
                    }
                }
            }
            if(updatedPet != null)
            {
                Console.WriteLine($"{userName}, you are updating ID: {updatedPet.PetId} byt the name {updatedPet.PetName}. What would you like to update, of the following, Please type the nr only.?");
                Console.WriteLine(" 1: Name \n 2: Colour \n 3: Species \n 4: Birthday \n 5: Sold Date \n 6: Previous owner \n 7: Price \n");
                var toUpdate = Console.ReadLine();
                int toUpdateInt = 0;
                string updateValue;
                if(int.TryParse(toUpdate, out toUpdateInt) && toUpdateInt <= 7 && toUpdateInt > 0)
                {
                    switch (toUpdateInt)
                    {
                        case 1:
                            Console.WriteLine($"What would you like to update the Name to be? Current name is: {updatedPet.PetName}.");
                            break;
                        case 2:
                            Console.WriteLine($"What would you like to update the Coulour to be? Current colour is: {updatedPet.PetColor}.");
                            break;
                        case 3:
                            Console.WriteLine($"What would you like to update the Species to be? Current Species is: {updatedPet.PetSpecies}. Select a nr from the list please.");
                            int theSpeciesNr = 0;
                            foreach (var theSpecies in Enum.GetNames(typeof(Pet.Species)))
                            {
                                theSpeciesNr++;
                                Console.WriteLine(theSpeciesNr + ": " + theSpecies);
                            }
                            break;
                        case 4:
                            Console.WriteLine($"What would you like to update the Birthdate to be? Current birthday is: {updatedPet.PetBirthday}. Enter new value in the format dd-mm-yyyy.");
                            break;
                        case 5:
                            Console.WriteLine($"What would you like to update the Sold date  to be? Current sold date is: {updatedPet.PetSoldDate}.Enter new value in the format dd-mm-yyyy.");
                            break;
                        case 6:
                            Console.WriteLine($"What would you like to update the Previous owner to be? Current Previous owner is: {updatedPet.PetPreviousOwner}.");
                            break;
                        case 7:
                            Console.WriteLine($"What would you like to update the Price to be? Current Price is: {updatedPet.PetPrice}£. Please enter the price in £, nr only.");
                            break;
                        default:
                            break;
                    }
                    updateValue = Console.ReadLine();
                    updatedPet = _petService.UpdatePet(updatedPet, toUpdateInt, updateValue);
                }
            }

            else
            {
                throw new InvalidDataException(message: "I am sorry i have found an error, could not find the pet to update.");
            }


            Console.WriteLine($"{userName}, you have successfully updated {updatedPet.PetName}, from your database.");
            DisplayMenu(userName);
        }

        private void DeletePet(string userName)
        {
            Console.WriteLine($"{userName}, please enter the Name, or ID of the pet you would like to delete: ");
            var theName = Console.ReadLine();
            int theId;
            Pet deletedPet = null;
            if(int.TryParse(theName, out theId))
            {
                deletedPet = _petService.DeletePetByID(theId);
            }
            else
            {
                List<Pet> petsByName = _petService.FindPetsByName(theName);
                if (petsByName.Count <= 0)
                {
                    Console.WriteLine($"I am sorry {userName}, i couldn't find any pet by that name.");
                    DeletePet(userName);
                }
                else if (petsByName.Count == 1)
                {
                    deletedPet = _petService.DeletePetByID(petsByName[0].PetId);
                }
                else
                {
                    Console.WriteLine($"I am sorry {userName}, there is more than one pet with that name: \n");

                    foreach (var pet in petsByName)
                    {
                        Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");

                    }

                    Console.WriteLine($"Please enter the ID of the pet you want to delete:");
                    var newId = Console.ReadLine();
                    int theNewId;
                    if(int.TryParse(newId, out theNewId))
                    {
                        deletedPet = _petService.DeletePetByID(theNewId);
                    }
                    else
                    {
                        Console.WriteLine($" I am sorry {userName} have not entered a valid ID, starting over.");
                        DeletePet(userName);
                    }
                }
            }
            Console.WriteLine($"{userName}, you have successfully deleted {deletedPet.PetName}, from your database.");
            DisplayMenu(userName);
        }

        private void AddNewPet(string userName)
        {
            Console.WriteLine($"Hi {userName}, please enter the name of the new pet:");
            var thePetName = Console.ReadLine();
            
            var selectedSpecies = SelectSpecies(userName);
            int theSelectedSpecies;
            if (!int.TryParse(selectedSpecies, out theSelectedSpecies))
            {
                Console.WriteLine("You didn't enter a Nr for species, starting over.");
                AddNewPet(userName);
            }

            Console.WriteLine($"{userName}, please enter the colour of the pet:");
            var theColour = Console.ReadLine();

            Console.WriteLine($"Please enter the date of the pet's birthday in the format dd-mm-yyyy, {userName}:");
            var selectedBirthday = Console.ReadLine();
            DateTime theSelectedBirthday;
            if (!DateTime.TryParse(selectedBirthday, out theSelectedBirthday))
            {
                Console.WriteLine("You didn't enter a propper date format, starting over.");
                AddNewPet(userName);
            }
            
            Console.WriteLine($"Please enter the date of purchase in the format dd-mm-yyyy, {userName}:");
            var selectedPurchaseDate = Console.ReadLine();
            DateTime theSelectedPurchaseDate;
            if (!DateTime.TryParse(selectedPurchaseDate, out theSelectedPurchaseDate))
            {
                Console.WriteLine("You didn't enter a propper date format, starting over.");
                AddNewPet(userName);
            }

            Console.WriteLine($"{userName}, please enter the name of the previous owner:");
            var thePreviousOwner = Console.ReadLine();

            Console.WriteLine($"{userName}, please enter the price of the pet in £, nr only:");
            var petPrice = Console.ReadLine();
            long thePetPrice;
            if(!long.TryParse(petPrice, out thePetPrice))
            {
                Console.WriteLine("You didn't enter a propper price, starting over.");
                AddNewPet(userName);
            }

            Pet theNewPet = _petService.AddNewPet(thePetName, theSelectedSpecies, theColour, theSelectedBirthday, theSelectedPurchaseDate, thePreviousOwner, thePetPrice);

            Console.WriteLine($"Congratulatons {userName}, you have successfully added {theNewPet.PetName}, with the ID: {theNewPet.PetId}. \n");
            DisplayMenu(userName);

        }

            private string SelectSpecies(string userName)
        {
            Console.WriteLine($"Thank you {userName}, now please enter the species from one of the following, enter the nr only: \n");
            int theSpeciesNr = 0;
            foreach (var theSpecies in Enum.GetNames(typeof(Pet.Species)))
            {
                theSpeciesNr++;
                Console.WriteLine(theSpeciesNr + ": " + theSpecies);
            }
            var selectedSpecies = Console.ReadLine();
            return selectedSpecies;
        }

        private void ListAllPets(string userName)
        {
            List<Pet> allPets = _petService.GetAllPets();
            Console.WriteLine($"Here are all the available pets, {userName}:\n");

            foreach (var pet in allPets)
            {
                Console.WriteLine($"Pet: ID: {pet.PetId}, Species: {pet.PetSpecies}, Name: {pet.PetName}, Colour: {pet.PetColor}, Birthday: {pet.PetBirthday}, Previous Owner: {pet.PetPreviousOwner}, PurchaseDate: {pet.PetSoldDate}, Price: {pet.PetPrice}£");
            }
            DisplayMenu(userName);
        }

    }
}
