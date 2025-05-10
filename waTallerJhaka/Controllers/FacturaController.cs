using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using System.Text;
using waTallerJhaka.Models;

namespace waTallerJhaka.Controllers
{
    public class FacturaController : Controller
    {
        Uri dir_ubicacion = new Uri("https://localhost:7110/api");
        private readonly HttpClient httpClient;

        public FacturaController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = dir_ubicacion;
        }

        public List<Factura> listarFactura()
        {
            List<Factura> facturas = new List<Factura>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Factura/listarFacturas").Result;
            var data = response.Content.ReadAsStringAsync().Result;
            facturas = JsonConvert.DeserializeObject<List<Factura>>(data);
            return facturas;
        }

        [HttpGet]
        public IActionResult nuevaFactura()
        {
            CotizacionController controller = new CotizacionController();
            ViewBag.cotizaciones = new SelectList(controller.listarCotizacion(), "ide_cot", "ide_cot");
            return View(new FacturaIngresar());
        }
        [HttpPost]
        public async Task<IActionResult> nuevaFactura(FacturaIngresar obj)
        {
            CotizacionController controller = new CotizacionController();
            if (!ModelState.IsValid)
            {
                ViewBag.cotizaciones = new SelectList(controller.listarCotizacion(), "ide_cot", "ide_cot");
                return View(obj);
            }
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseC = await
            httpClient.PostAsync("/api/Factura/nuevaFactura", content);
            if (responseC.IsSuccessStatusCode)
            {
                ViewBag.mensaje = "Factura registrado correctamente..!!!";
            }
            ViewBag.cotizaciones = new SelectList(controller.listarCotizacion(), "ide_cot", "ide_cot");
            return View(obj);
        }

        public Factura buscarFactura(int id) {
    
            Factura factura = new Factura();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Factura/buscarFactura/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<Factura>(data);
            }
            return factura;
        }


        [HttpGet]
        public IActionResult detallesFactura(int id)
        {
            CotizacionController cotizacionController = new CotizacionController();
            
            Factura factura = new Factura();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Factura/buscarFactura/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<Factura>(data);
                ViewBag.listaServicios = cotizacionController.obtenerDetallesServicios(factura.ide_cot);
                ViewBag.listaRepuestos = cotizacionController.obtenerDetallesRepuestos(factura.ide_cot);
            }
            return View(factura);
        }


        public IActionResult GenerarPdfFactura(int id)
        {
            DateTime hoy = DateTime.Now;

            CotizacionController cotizacionController = new CotizacionController();
            var factura = buscarFactura(id);

            ViewBag.listaServicios = cotizacionController.obtenerDetallesServicios(factura.ide_cot);
            ViewBag.listaRepuestos = cotizacionController.obtenerDetallesRepuestos(factura.ide_cot);

  
            return new ViewAsPdf("GenerarPdfFactura", factura) 
            {
                FileName = $"Factura-{id}-{hoy:yyyyMMdd}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }


        public IActionResult listadoFacturas()
        {
            return View(listarFactura());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
