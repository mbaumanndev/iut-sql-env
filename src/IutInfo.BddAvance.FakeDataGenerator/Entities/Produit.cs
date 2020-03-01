namespace IutInfo.BddAvance.FakeDataGenerator.Entities
{
    public sealed class Produit
    {
        public long Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public decimal Prix { get; set; }

        public int Stock { get; set; }
    }
}