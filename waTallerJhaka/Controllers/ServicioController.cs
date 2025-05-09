using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using waTallerJhaka.Models;

namespace waTallerJhaka.Controllers
{
    public class ServicioController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
        private readonly HttpClient httpClient;

        public ServicioController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }

        public List<Servicio> listarServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Servicio/listarServicios").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            servicios = JsonConvert.DeserializeObject<List<Servicio>>(data);
            return servicios;
        }

        [HttpGet]
        public IActionResult nuevoServicio()
        {
            return View(new Servicio());
        }
        [HttpPost]
        public async Task<IActionResult> nuevoServicio(Servicio obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            httpClient.PostAsync("/api/Servicio/nuevoServicio", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Servicio registrado correctamente..!!!";
            }
            return View(obj);
        }


        [HttpGet]
        public IActionResult editarServicio(int id)
        {
            Servicio servicio = new Servicio();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Servicio/buscarServicio/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                servicio = JsonConvert.DeserializeObject<Servicio>(data);
            }
            return View(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> editarServicio(Servicio obj)
        {
   
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/Servicio/actualizarServicio", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Servicio actualizado correctamente..!!!";
                return RedirectToAction("listadoServicios");
            }
            else
            {
                ViewBag.mensaje = "Error al actualizar el servicio";
                return View(obj);
            }
        }



        public IActionResult listadoServicios()
        {
            return View(listarServicios());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
