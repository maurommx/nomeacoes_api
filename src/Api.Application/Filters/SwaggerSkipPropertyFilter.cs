using Microsoft.OpenApi.Models;
using Api.Domain.swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Linq;
using System;

namespace Api.Application.Filters
{
    public class SwaggerSkipPropertyFilter: ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // if (schema?.Properties == null)
            // {
            //     return;
            // }
            // int qtd = context.Type.GetProperties().Count();
            // if (qtd > 0) {
            //     var aa = context.Type.GetProperties();
            //     foreach (var skipProperty in aa) {
            //         // skipProperties
            //         //Console.WriteLine(skipProperty.Attributes);
            //         // var pppp = skipProperty.get.GetCustomAttribute();
            //         // foreach (var pp in pppp) {
            //         //     Console.WriteLine(pp);
            //         // }

            //     }
            // }

            // var skipProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerIgnoreAttribute>() != null);

            // foreach (var skipProperty in skipProperties)
            // {
            //     var propertyToSkip = schema.Properties.Keys.SingleOrDefault(x => string.Equals(x, skipProperty.Name, StringComparison.OrdinalIgnoreCase));

            //     if (propertyToSkip != null)
            //     {
            //         schema.Properties.Remove(propertyToSkip);
            //     }
            // }
        }
    }
}