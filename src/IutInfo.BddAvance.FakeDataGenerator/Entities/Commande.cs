using System;
using System.Collections.Generic;

namespace IutInfo.BddAvance.FakeDataGenerator.Entities
{
    public sealed class Commande
    {
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public DateTime Date { get; set; }

        public StatutCommande Statut { get; set; }

        public IEnumerable<ProduitDeCommande> Produits { get; set; }
    }
}