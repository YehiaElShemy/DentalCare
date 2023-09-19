using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.AspNet.SignalR;

namespace selfhosting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080"; // Specify the base address for your server
            using (WebApp.Start(url))
            {
                Console.WriteLine($"Server running at {url}");
                Console.ReadLine();
            }
        }
    }
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); // Enable cross-origin requests if needed
            app.MapSignalR(); // Map SignalR hub
        }
    }

    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.broadcastMessage(message);
        }
    }
}
