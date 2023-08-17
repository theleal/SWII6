using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SW_TP01.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_TP01
{
    // Rodrigo Rebelo da Costa - CB3016871
    // Luiz Gustavo - CB3015386

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            var builder = new RouteBuilder(app);

            var controller = new BookController();

            builder.MapRoute("livro/nome", controller.GetNameBook);
            builder.MapRoute("livro", controller.GetBook);
            builder.MapRoute("livro/autores", controller.GetAuthorsBook);
            builder.MapRoute("livro/ApresentarLivro", controller.GetHtmlBook);

            var routes = builder.Build();

            app.UseRouter(routes);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
    }
}
