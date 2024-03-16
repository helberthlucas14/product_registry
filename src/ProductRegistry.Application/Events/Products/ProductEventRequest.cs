using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Domain.Models;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions;


namespace ProductRegistry.Application.Events.Products
{
    public class ProductEventRequest : EventRequest, IDisposable
    {
        public Product Product { get; private set; }

        public static ProductEventRequest SetProduct(Product product) =>
        new() { Product = product };

        public string Message => Product.ToJson();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) { }
    }
}
