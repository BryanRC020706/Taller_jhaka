using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using System.Text;
using waTallerJhaka.Models;

namespace waTallerJhaka.Controllers
{
    public class RepuestoController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
        private readonly HttpClient httpClient;

        public RepuestoController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }

        public List<Repuesto> listarRepuestos()
        {
            List<Repuesto> repuestos = new List<Repuesto>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Repuesto/listarRespuestos").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            repuestos = JsonConvert.DeserializeObject<List<Repuesto>>(data);
            return repuestos;
        }
        

        [HttpGet]
        public IActionResult nuevoRepuesto()
        {
            return View(new Repuesto());
        }
        [HttpPost]
        public async Task<IActionResult> nuevoRepuesto(Repuesto obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            httpClient.PostAsync("/api/Repuesto/nuevoRepuesto", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Repuesto registrado correctamente..!!!";
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult editarRepuesto(int id)
        {
            Repuesto repuesto = new Repuesto();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Repuesto/buscarRepuesto/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                repuesto = JsonConvert.DeserializeObject<Repuesto>(data);
            }
            return View(repuesto);
        }

        [HttpPost]
        public async Task<IActionResult> editarRepuesto(Repuesto obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/Repuesto/actualizarRepuesto", content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Repuesto actualizado correctamente..!!!";
                return RedirectToAction("listadoRepuesto");
            }
            else
            {
                ViewBag.mensaje = "Error al actualizar el repuesto";
                return View(obj);
            }
        }

        public IActionResult GenerarPDF()
        {
            DateTime hoy = DateTime.Now;
            return new ViewAsPdf("GenerarPDF", listarRepuestos())
            {
                FileName = $"INVENTARIO-{hoy}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        public IActionResult listadoRepuesto()
        {
            return View(listarRepuestos());
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
