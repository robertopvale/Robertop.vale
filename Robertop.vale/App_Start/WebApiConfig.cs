using Robertop.vale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Robertop.vale
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            if (ListaProdutos.produtos == null)
            {
                cinventory i = new cinventory();
                i.Lwarehouses = new List<warehouses>();
                i.Lwarehouses.Add(new warehouses { locality = "SP", quantity = 12, type = "ECOMMERCE" });
                i.Lwarehouses.Add(new warehouses { locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE" });

                ListaProdutos.produtos = new List<Produto>();
                Produto p = new Produto();
                p.sku = 43264;
                p.name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
                p.inventory = i;

                ListaProdutos.produtos.Add(p);
            }


        // Web API routes
        config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
