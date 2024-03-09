using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Application.UseCases.Products.Response
{
    public class ProductResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public Guid? CategoryId { get; private set; } = Guid.Empty;
    }
}
