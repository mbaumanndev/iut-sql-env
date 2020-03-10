using System;
using System.Collections.Generic;
using System.Text;

namespace IutInfo.BddAvance.FakeDataGenerator.Dto
{
    public sealed class ProduitDeCommandeDto
    {
        public Guid CmdId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }

        public int Quantite { get; set; }
    }
}
