using IutInfo.BddAvance.FakeDataGenerator.Entities;
using System;
using System.Collections.Generic;

namespace IutInfo.BddAvance.FakeDataGenerator.Dto
{
    public sealed class CommandeDto
    {
        public Guid Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public short Statut { get; set; }
        public IEnumerable<ProduitDeCommandeDto> Produits { get; set; }
    }
}