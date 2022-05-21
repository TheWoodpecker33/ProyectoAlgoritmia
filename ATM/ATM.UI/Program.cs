using ATM.DataModel.Models;
using ATM.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace ATM.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuOpc = "1";
            while(menuOpc == "1")
            try
            {
                Console.WriteLine("Ingrese el nombre del archivo .in a leer (debe incluir la extension): ");
                string fileName = Console.ReadLine();
                CreditCardRepository repo = new CreditCardRepository(fileName);
                    Console.WriteLine("Tarjetas leidas: ");
                    foreach (var card in repo.Cards)
                    {
                        Console.WriteLine($"Id: {card.Id} - Card: {card.Card}");
                    }
                List<CreditCard> cardsAfterRemoval = repo.GetOrderedList(repo.Cards);
                    Console.WriteLine("Tarjetas despues de la eliminacion: ");
                    foreach (var card in cardsAfterRemoval)
                    {
                        Console.WriteLine($"Id: {card.Id} - Card: {card.Card}");
                    }
                    string outFileName = fileName.Split('.')[0] + ".out";
                repo.WriteToFile(outFileName, cardsAfterRemoval);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No existe el archivo, intentalo de nuevo");
            }
            finally
            {
                Console.WriteLine("Para volver a intentarlo escirba 1, de lo contrario escriba cualquier cosa: ");
                menuOpc =  Console.ReadLine();
            }
        }
    }
}
