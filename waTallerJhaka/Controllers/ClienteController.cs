using Microsoft.AspNetCore.Mvc;
using waTallerJhaka.Models;
using Newtonsoft.Json;

namespace waTallerJhaka.Controllers
{
    public class ClienteController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7284/api");
        private readonly HttpClient httpClient;

        public ClienteController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }

        public List<Cliente> listarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress +"/Cliente/listarClientes").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            clientes = JsonConvert.DeserializeObject<List<Cliente>>(data);
            return clientes;
        }

        public IActionResult listadoClientes() { 
            return View(listadoClientes());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
