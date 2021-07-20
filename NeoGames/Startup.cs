using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using NeoGames.Models;
using Newtonsoft.Json.Serialization;
using Owin;

namespace NeoGames
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // setting a JSON formatter instead of XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(new BrowserJsonFormatter());

            app.UseWebApi(config);
        }
    }
}