using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApi_Autores.Utilidades
{
    public class SwaggerAgrupaPorVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namespaceController = controller.ControllerType.Namespace;  //Controllers.V1
            var versionAPI = namespaceController.Split(".").Last().ToLower(); //v1
            controller.ApiExplorer.GroupName = versionAPI;
        }
    }
}
