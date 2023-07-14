using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Threading.Tasks;

public static class ViewRenderer
{
    public static async Task<string> RenderViewToStringAsync(Controller controller, string viewName, object model)
    {
        var viewEngine = controller.HttpContext.RequestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
        var view = viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true).View;

        if (view == null)
            throw new ArgumentException($"The view '{viewName}' could not be found.");

        var tempDataFactory = controller.HttpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
        var tempData = tempDataFactory.GetTempData(controller.HttpContext);
        var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = model };

        using (var writer = new StringWriter())
        {
            var viewContext = new ViewContext(controller.ControllerContext, view, viewData, tempData, writer, new HtmlHelperOptions());
            await view.RenderAsync(viewContext);
            return writer.ToString();
        }
    }
}
