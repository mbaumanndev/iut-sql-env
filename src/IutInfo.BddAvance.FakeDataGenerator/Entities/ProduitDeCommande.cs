using System;

namespace IutInfo.BddAvance.FakeDataGenerator.Entities
{
    public sealed class ProduitDeCommande
    {
        public ProduitDeCommande(Produit p_Source)
        {
            Id = Guid.NewGuid();
            Nom = p_Source.Nom;
            Description = p_Source.Description;
            Prix = p_Source.Prix;
        }

        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }

        public int Quantite { get; set; }
    }
}