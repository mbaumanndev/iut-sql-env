using IutInfo.BddAvance.FakeDataGenerator.Entities;
using System;
using System.Collections.Generic;

namespace IutInfo.BddAvance.FakeDataGenerator.Dto
{
    public sealed class CommandeDto
    {
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public short Statut { get; set; }
        public IEnumerable<ProduitDeCommande> Produits { get; set; }
    }
}