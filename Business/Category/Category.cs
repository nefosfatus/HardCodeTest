using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Category
{
    internal class Category
    {
        public Category()
        {
            AdditionalFields = new List<string>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string>? AdditionalFields { get; set; }
    }
}
