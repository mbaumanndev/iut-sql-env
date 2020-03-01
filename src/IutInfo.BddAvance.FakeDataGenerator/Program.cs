using Bogus;
using Bogus.Extensions;
using CsvHelper;
using IutInfo.BddAvance.FakeDataGenerator.Dto;
using IutInfo.BddAvance.FakeDataGenerator.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IutInfo.BddAvance.FakeDataGenerator
{
    internal static class Program
    {
        private const int MAX_PRODUCT_PER_COMMAND = 10;
        private const int CLIENT_NUMBER = 8000;

        internal static void Main(string[] args)
        {
            int v_Seed;
            List<Produit> v_Produits = null;
            List<Client> v_Clients = null;
            List<Commande> v_Commandes = null;
            var prdIds = 0;
            var cliIds = 0;

            Console.WriteLine("Saisir un nombre (notez-le quelque part) :");

            while (!int.TryParse(Console.ReadLine(), out v_Seed)) ;

            Console.WriteLine($"Génération des données avec la seed {v_Seed}");

            Randomizer.Seed = new Random(v_Seed);

            try
            {
                var v_ProduitsFaker = new Faker<Produit>("fr")
                    .StrictMode(true)
                    .RuleFor(p => p.Id, f => ++prdIds)
                    .RuleFor(p => p.Nom, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Description, f => f.Commerce.ProductAdjective())
                    .RuleFor(p => p.Prix, f => decimal.Parse(f.Commerce.Price()))
                    .RuleFor(p => p.Stock, f => f.Random.Int(0, 5000));

                v_Produits = v_ProduitsFaker.Generate(10_000 * MAX_PRODUCT_PER_COMMAND);

                var v_ClientFaker = new Faker<Client>("fr")
                    .StrictMode(true)
                    .RuleFor(c => c.Id, f => ++cliIds)
                    .RuleFor(c => c.Nom, f => f.Name.LastName())
                    .RuleFor(c => c.Prenom, f => f.Name.FirstName())
                    .RuleFor(c => c.Addresse, f => f.Address.City())
                    .RuleFor(c => c.Naissance, f => f.Date.Past(65, DateTime.Now.AddYears(-20)));

                v_Clients = v_ClientFaker.Generate(CLIENT_NUMBER * MAX_PRODUCT_PER_COMMAND);

                var v_ProduitCommandeFaker = new Faker<ProduitDeCommande>("fr")
                    .StrictMode(false)
                    .CustomInstantiator(f => new ProduitDeCommande(f.PickRandom(v_Produits)))
                    .RuleFor(p => p.Id, f => f.Random.Guid())
                    .RuleFor(p => p.Prix, (f, p) => decimal.Parse(f.Commerce.Price(p.Prix * 0.15M, p.Prix)))
                    .RuleFor(p => p.Quantite, f => f.Random.Number(1, 20));

                var v_CommandeFaker = new Faker<Commande>("fr")
                    .StrictMode(true)
                    .RuleFor(c => c.Id, f => f.Random.Guid())
                    .RuleFor(c => c.Client, f => f.PickRandom(v_Clients))
                    .RuleFor(c => c.Produits, f => v_ProduitCommandeFaker.GenerateBetween(1, MAX_PRODUCT_PER_COMMAND))
                    .RuleFor(c => c.Statut, f => f.PickRandom<StatutCommande>())
                    .RuleFor(c => c.Date, f => f.Date.Past(-3, DateTime.Now));

                v_Commandes = v_CommandeFaker.Generate((int)(CLIENT_NUMBER * 2.5));

                using (var v_ClientsWritter = new StreamWriter("clients.csv"))
                using (var v_ClientsCsv = new CsvWriter(v_ClientsWritter, CultureInfo.InvariantCulture))
                {
                    v_ClientsCsv.WriteRecords(v_Clients.Select(c => new ClientDto
                    {
                        Nom = c.Nom,
                        Prenom = c.Prenom,
                        Addresse = c.Addresse,
                        Naissance = c.Naissance
                    }));
                }

                using (var v_ProduitsWritter = new StreamWriter("produits.csv"))
                using (var v_ProduitsCsv = new CsvWriter(v_ProduitsWritter, CultureInfo.InvariantCulture))
                {
                    v_ProduitsCsv.WriteRecords(v_Clients.Select(c => new ClientDto
                    {
                        Nom = c.Nom,
                        Prenom = c.Prenom,
                        Addresse = c.Addresse,
                        Naissance = c.Naissance
                    }));
                }

                using (var v_CommandesWritter = new StreamWriter("commandes.json"))
                {
                    var v_CommandesSerializer = new JsonSerializer();
                    v_CommandesSerializer.Serialize(v_CommandesWritter, v_Commandes.Select(c => new CommandeDto
                    {
                        Client = $"{c.Client.Prenom} {c.Client.Nom}",
                        Date = c.Date,
                        Statut = (short)c.Statut,
                        Produits = c.Produits
                    }));
                }

                Console.WriteLine("Données générées, appuyez sur une touche pour fermer l'application.");
            }
            finally
            {
                v_Clients?.Clear();
                v_Produits?.Clear();
            }

            Console.ReadKey();
        }
    }
}