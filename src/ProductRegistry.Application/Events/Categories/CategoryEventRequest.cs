using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Domain.Models;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions;


namespace ProductRegistry.Application.Events.Categories
{
    public class CategoryEventRequest : EventRequest, IDisposable
    {
        public Category Category { get; private set; }

        public static CategoryEventRequest SetCategory(Category category) =>
        new() { Category = category };

        public string Message => Category.ToJson();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) { }
    }
}
