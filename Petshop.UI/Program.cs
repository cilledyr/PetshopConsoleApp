using Petshop.Core.Enteties;
using Petshop.Core;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Petshop.Core.ApplicationService;
using Petshop.Core.ApplicationService.Impl;
using Petshop.Core.DomainService;
using Petshop.Infrastructure.Data;

namespace Petshop.UI
{
    class Program
    {
        public static IPetRepository petRepository = PetRepository.Instance;
        public static IOwnerRepository ownerRepository = OwnerRepository.Instance;
        public static DataInitializer dataInit = new DataInitializer();
        public static IPetService _petService = new PetService(petRepository, ownerRepository);
        public static Printer printer = new Printer(_petService);
        static void Main(string[] args)
        {
            Console.WriteLine(dataInit.InitData());
            Console.WriteLine("Welcome to the Petshop please type your name:");
            var userName = Console.ReadLine();
            printer.DisplayMenu(userName);
        }

        

        
    }
}
