using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenMVCAjax.Models;
using ExamenMVCAjax.Entities;

namespace ExamenMVCAjax.Controllers
{
    public class FacturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facturas
        public async Task<ActionResult> Index()
        {
            var factura = db.Factura.Include(f => f.Cliente);
            //return View(await factura.ToListAsync());
            return Json(factura, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            //return View(factura);
            return Json(factura, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Cedula");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FechaCreacion,ClienteId,Total,SubTotal,Impuesto")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(factura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Cedula", factura.ClienteId);
            //return View(factura);
            return Json(factura, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Cedula", factura.ClienteId);
            return View(factura);
            
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FechaCreacion,ClienteId,Total,SubTotal,Impuesto")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Cedula", factura.ClienteId);
            //return View(factura);
            return Json(factura, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Factura factura = await db.Factura.FindAsync(id);
            db.Factura.Remove(factura);
            await db.SaveChangesAsync();
            //return RedirectToAction("Index");
            return Json(factura, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, ActionName("AddProductFact")]
        public async Task<ActionResult> AddProductFact(FormCollection data)
        {
            // Obtiene el Id de la factura 
            Factura oFactura = await db.Factura.FindAsync(Convert.ToInt32(data["factura"]));

            IEnumerable<Producto> productos = await db.Producto.Where(x => x.Codigo == data["producto"]).ToListAsync();

            FacturaProducto oFacturaProducto = new FacturaProducto();
            oFacturaProducto.Factura = oFactura;
            oFacturaProducto.Productos = productos;

            return PartialView("_FactProdPartial", oFacturaProducto);

        }

    }
}
