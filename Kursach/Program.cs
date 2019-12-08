using System;
using System.Collections;
using System.Collections.Generic;
using PL;
namespace Kursach
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            int op;
            do
            {
                op = menu.menu();
                if (op == 1)
                {
                    menu.addClient();
                }
                if (op == 2)
                {
                    menu.printClientData();
                }
                if (op == 3)
                {
                    menu.editClient();
                }
                if (op == 4)
                {
                    menu.deleteClient();
                }
                if (op == 5)
                {
                    menu.addRealEstate();
                }
                if (op == 6)
                {
                    menu.editRealEstate();
                }
                if (op == 7)
                {
                    menu.deleteRealEstate();
                }
                if (op == 8)
                {
                    menu.printRealEstateData();
                }
                if (op == 9)
                {
                    menu.printClientByKeyWordInLastName();
                }
                if (op == 10)
                {
                    menu.printRealEstateByKeyWord();
                }
                if (op == 11)
                {
                    menu.addSuggestion();
                }
                if (op == 12)
                {
                    menu.printSuggestion();
                }
                if (op == 13)
                {
                    menu.editSuggestion();
                }
                if (op == 14)
                {
                    menu.deleteSuggestion();
                }

            } while (op != 99);
        }
    }
}
