using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDAL.ViewModels
{
    public class VMBook
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateOnly? PublicationDate { get; set; }

        public int? CategoryId { get; set; }

        public int? AuthorId { get; set; }

    }
}
