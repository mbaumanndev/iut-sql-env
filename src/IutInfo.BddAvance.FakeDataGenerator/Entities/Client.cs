using System;

namespace IutInfo.BddAvance.FakeDataGenerator.Entities
{
    public sealed class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Addresse { get; set; }
        public DateTime Naissance { get; set; }
    }
}