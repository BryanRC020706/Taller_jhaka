using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using waTallerJhaka.Models;

namespace waTallerJhaka.Controllers
{
    public class VehiculoController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
        private readonly HttpClient httpClient;

        public VehiculoController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }
        public List<Vehiculo> listarVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Vehiculo/listarVehiculos").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(data);
            return vehiculos;
        }

        public List<VehiculoBox> listarVehiculosBOX()
        {
            List<VehiculoBox> vehiculos = new List<VehiculoBox>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Vehiculo/listarVehiculosBox").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            vehiculos = JsonConvert.DeserializeObject<List<VehiculoBox>>(data);
            return vehiculos;
        }

        [HttpGet]
        public IActionResult nuevoVehiculo()
        {
            ClienteController clienteController = new ClienteController();
            ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
            return View(new VehiculoO());
        }
        [HttpPost]
        public async Task<IActionResult> nuevoVehiculo(VehiculoO obj)
        {
            ClienteController clienteController = new ClienteController();
            if (!ModelState.IsValid)
            {
                ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            httpClient.PostAsync("/api/Vehiculo/nuevoVehiculo", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Vehiculo registrado correctamente..!!!";
            }
            ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
            return View(obj);
        }

        [HttpGet]
        public IActionResult editarVehiculo(int id)
        {
            ClienteController clienteController = new ClienteController();
            VehiculoO vehiculo = new VehiculoO();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Vehiculo/buscarVehiculo/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
                vehiculo = JsonConvert.DeserializeObject<VehiculoO>(data);
            }
            return View(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> editarVehiculo(VehiculoO obj)
        {
            ClienteController clienteController = new ClienteController();
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/Vehiculo/actualizarVehiculo", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
                ViewBag.mensaje = "Vehiculo actualizado correctamente..!!!";
                return RedirectToAction("listadoVehiculos");
            }
            else
            {
                ViewBag.clientes = new SelectList(clienteController.listarClientes(), "ide_cli", "nom_cli");
                ViewBag.mensaje = "Error al actualizar el vehiculo";
                return View(obj);
            }
        }


        public IActionResult listadoVehiculos()
        {
            return View(listarVehiculos());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
