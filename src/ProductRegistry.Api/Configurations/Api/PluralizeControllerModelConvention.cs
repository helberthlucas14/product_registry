using Humanizer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ProductRegistry.Api.Configurations.Api
{
    public class PluralizeControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.Pluralize();
            foreach (var selector in controller.Selectors)
            {
                selector.AttributeRouteModel.Template = $"api/[controller]";
            }
        }
    }
}
