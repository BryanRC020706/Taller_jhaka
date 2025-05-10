using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using waTallerJhaka.Models;

namespace waTallerJhaka.Controllers
{
    public class CotizacionController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
        private readonly HttpClient httpClient;

        public CotizacionController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }
        public List<DetalleServicioLista> obtenerDetallesServicios(int id)
        {
            List<DetalleServicioLista> detalleServicios = new List<DetalleServicioLista>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Cotizacion/listarDetalleServicio/"+id).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            detalleServicios = JsonConvert.DeserializeObject<List<DetalleServicioLista>>(data);
            return detalleServicios;
        }

        public List<DetalletRepuestoLista> obtenerDetallesRepuestos(int id)
        {
            List<DetalletRepuestoLista> detalleRepuestos = new List<DetalletRepuestoLista>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Cotizacion/listarDetalleRepuesto/"+id).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            detalleRepuestos = JsonConvert.DeserializeObject<List<DetalletRepuestoLista>>(data);
            return detalleRepuestos;
        }


        public List<Cotizacion> listarCotizacion()
        {
            List<Cotizacion> cotizacion = new List<Cotizacion>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Cotizacion/listarCotizacion").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            cotizacion = JsonConvert.DeserializeObject<List<Cotizacion>>(data);
            return cotizacion;
        }

        

        [HttpGet]
        public IActionResult nuevaCotizacion()
        {
            VehiculoController vehiculoController = new VehiculoController();
            ViewBag.vehiculos = new SelectList(vehiculoController.listarVehiculosBOX(), "IDE_VEH", "VEH");
            return View(new CotizacionO());
        }


        [HttpPost]
        public async Task<IActionResult> nuevaCotizacion(CotizacionO obj)
        {
            VehiculoController vehiculoController = new VehiculoController();
            if (!ModelState.IsValid)
            {
                ViewBag.vehiculos = new SelectList(vehiculoController.listarVehiculosBOX(), "IDE_VEH", "VEH");
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Cotizacion/nuevoCotizacion", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Cotización creada correctamente";
                return RedirectToAction("listadoCotizaciones");
            }
            ViewBag.vehiculos = new SelectList(vehiculoController.listarVehiculosBOX(), "IDE_VEH", "VEH");
            return View(obj);
        }

        [HttpGet]
        public IActionResult agregarRepuesto(int id)
        {
            ViewBag.listaRepuestos = obtenerDetallesRepuestos(id);
            RepuestoController repuestoController = new RepuestoController();
            ViewBag.repuestos = new SelectList(repuestoController.listarRepuestos(), "ide_rep", "nom_rep");
            ViewBag.idCotizacion = id;
            return View(new DetalleRepuesto());
        }

        [HttpPost]
        public async Task<IActionResult> agregarRepuesto(DetalleRepuesto obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Cotizacion/agregarRepuesto", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Repuesto agregado";
            }
            else
            {
                ViewBag.mensaje = "Error al agregar repuesto";
            }

            return RedirectToAction("agregarRepuesto", new { id = obj.IDE_COT });
        }

        [HttpGet]
        public IActionResult agregarServicio(int id)
        {
            ViewBag.detllaesServicios = obtenerDetallesServicios(id);
            ServicioController servicioController = new ServicioController();
            ViewBag.servicios = new SelectList(servicioController.listarServicios(), "ide_ser", "nom_ser");
            ViewBag.idCotizacion = id;
            return View(new DetalleServicio());
        }


        [HttpPost]
        public async Task<IActionResult> agregarServicio(DetalleServicio obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Cotizacion/agregarServicio", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Servicio agregado";
            }
            else
            {
                ViewBag.mensaje = "Error al agregar servicio";
            }

            return RedirectToAction("agregarServicio", new { id = obj.IDE_COT });
        }

        [HttpPost]
        public async Task<IActionResult> eliminarDetalleRepuesto(int id, int idCotizacion)
        {

            var response = await httpClient.PostAsync(httpClient.BaseAddress + "/Cotizacion/eliminarDetalleRepuesto/" + id, null);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Repuesto eliminado correctamente..!!!";
                return RedirectToAction("agregarRepuesto", new { id = idCotizacion });
            }
            else
            {
                ViewBag.mensaje = "Error al eliminar el repuesto";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> eliminarDetalleServicio(int id, int idCotizacion)
        {

            var response = await httpClient.PostAsync(httpClient.BaseAddress + "/Cotizacion/eliminarDetalleServicio/" + id, null);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Servicio eliminado correctamente..!!!";
                return RedirectToAction("agregarServicio", new { id = idCotizacion });
            }
            else
            {
                ViewBag.mensaje = "Error al eliminar el servicio";
                return View("Error");
            }
        }

        public IActionResult listadoCotizaciones()
        {
            return View(listarCotizacion());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

