using DB1.AvaliacaoTecnica.CrossCutting;
using DB1.AvaliacaoTecnica.SharedKernel.Events;
using DB1.AvalicaoTecnica.Api.Helpers;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DB1.AvalicaoTecnica.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            ConfigureDependencyInjection(config, container);

            // Web API routes
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {

            DependencyRegister.Register(container);

            config.DependencyResolver = new UnityResolverHelper(container);
            DomainEvent.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}
