using Microsoft.AspNetCore.Hosting;
using SW_TP01;
using SW_TP01.Controller;
using Microsoft.AspNetCore.Server.Kestrel;


namespace YourNamespace
{
    // Rodrigo Rebelo da Costa - CB3016871
    // Luiz Gustavo - CB3015386

    class Program
    {
        static void Main(string[] args)
        {
            var controller = new BookController();
            controller.MostrarMetodos();

            Console.WriteLine("\n\n\n\n");

            CreateWebHostBuilder().Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>();
        }
    }


}