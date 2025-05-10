using Microsoft.AspNetCore.Mvc;
using waTallerJhaka.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace waTallerJhaka.Controllers
{
    public class ClienteController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
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

        [HttpGet]
        public IActionResult nuevoCliente()
        {
            return View(new ClienteO());
        }
        [HttpPost]
        public async Task<IActionResult> nuevoCliente(ClienteO obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            httpClient.PostAsync("/api/Cliente/nuevoCliente", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Cliente registrado correctamente..!!!";
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult detallesCliente(int id)
        {
            ClienteO cliente = new ClienteO();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Cliente/buscarCliente/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteO>(data);
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult editarCliente(int id)
        {
            ClienteO cliente = new ClienteO();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Cliente/buscarCliente/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteO>(data);
            }
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> editarCliente(ClienteO obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/Cliente/actualizarCliente", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Cliente actualizado correctamente..!!!";
                return RedirectToAction("listadoClientes");
            }
            else
            {
                ViewBag.mensaje = "Error al actualizar el cliente";
                return View(obj);
            }
        }

        public IActionResult listadoClientes() { 
            return View(listarClientes());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
