using System.Web.Http;
using Thinktecture.IdentityModel.Http.Cors.WebApi;

namespace PEW.Web.Api.App_Start
{
    public class CorsConfig
    {
        public static void RegisterCors(HttpConfiguration httpConfig)
        {
            var corsConfig = new WebApiCorsConfiguration();
 
            // this adds the CorsMessageHandler to the HttpConfiguration’s
            // MessageHandlers collection
            corsConfig.RegisterGlobal(httpConfig);
       
            // this allow all CORS requests to the Products controller
            // from the http://foo.com origin.
            corsConfig
                .ForResources("Stats")
                .ForOrigins("http://localhost:8080", "http://stats.pew.nu", "http://pew-ui.azurewebsites.net")
                .AllowAllMethodsAndAllRequestHeaders();

            corsConfig
                .ForResources("Profile")
                .ForOrigins("http://localhost:8080", "http://stats.pew.nu", "http://pew-ui.azurewebsites.net")
                .AllowAllMethodsAndAllRequestHeaders();

        } 
    }
}