using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IutInfo.BddAvance.CoursOrm.Models
{
    public sealed class Article
    {
        public Guid Id { get; set; }

        public string Titre { get; set; }

        public DateTime Publication { get; set; }
        public string AuthorId { get; set; }
    }
}
