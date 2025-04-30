using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDotacion.Data;
using AppDotacion.Models;
using System.Linq;

namespace AppDotacion.Controllers
{
    public class DotacionesController : Controller
    {
        private readonly AppDotacionContext _context;

        public DotacionesController(AppDotacionContext context)
        {
            _context = context;
        }

        // GET: Dotaciones
        public async Task<IActionResult> Index(string Rut_DNI, string Agente, string Pais_Call_Center,
                                              string Area, string AreaGestion, string Contrato,
                                              string Tipos_de_agente, string Servicio, string search)
        {
            var query = _context.Dotaciones.AsQueryable();

            // Filtros individuales
            if (!string.IsNullOrEmpty(Rut_DNI))
                query = query.Where(d => d.Rut_DNI.Contains(Rut_DNI));
            if (!string.IsNullOrEmpty(Agente))
                query = query.Where(d => d.Agente.Contains(Agente));
            if (!string.IsNullOrEmpty(Pais_Call_Center))
                query = query.Where(d => d.Pais_Call_Center == Pais_Call_Center);
            if (!string.IsNullOrEmpty(Area))
                query = query.Where(d => d.Area == Area);
            if (!string.IsNullOrEmpty(AreaGestion))
                query = query.Where(d => d.AreaGestion == AreaGestion);
            if (!string.IsNullOrEmpty(Contrato))
                query = query.Where(d => d.Contrato.ToString() == Contrato);
            if (!string.IsNullOrEmpty(Tipos_de_agente))
                query = query.Where(d => d.Tipos_de_agente == Tipos_de_agente);
            if (!string.IsNullOrEmpty(Servicio))
                query = query.Where(d => d.Servicio == Servicio);

            // Búsqueda general
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d =>
                    (d.Rut_DNI != null && d.Rut_DNI.Contains(search)) ||
                    (d.Agente != null && d.Agente.Contains(search)) ||
                    (d.Pais_Call_Center != null && d.Pais_Call_Center.Contains(search)) ||
                    (d.Nombre_Call_Center != null && d.Nombre_Call_Center.Contains(search)) ||
                    (d.Area != null && d.Area.Contains(search)) ||
                    (d.AreaGestion != null && d.AreaGestion.Contains(search)) ||
                    (d.Tipos_de_agente != null && d.Tipos_de_agente.Contains(search)) ||
                    (d.Servicio != null && d.Servicio.Contains(search)) ||
                    (d.Usuarios_RcWeb != null && d.Usuarios_RcWeb.Contains(search)) ||
                    (d.Nombre_Jefatura != null && d.Nombre_Jefatura.Contains(search)) ||
                    (d.Rut_Ficticio != null && d.Rut_Ficticio.Contains(search)) ||
                    (d.Rut_DNI2 != null && d.Rut_DNI2.Contains(search)) ||
                    (d.Clasifica_Cargo != null && d.Clasifica_Cargo.Contains(search)) ||
                    (d.CARGO != null && d.CARGO.Contains(search)) ||
                    (d.Correo != null && d.Correo.Contains(search)));
            }

            await PopulateViewData();
            return View(await query.ToListAsync());
        }

        // GET: Dotaciones/Create
        public async Task<IActionResult> Create()
        {
            await PopulateViewData();
            return View();
        }

        // POST: Dotaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dotacion dotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dotacion);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Dotación creada exitosamente";
                return RedirectToAction(nameof(Index));
            }

            await PopulateViewData();
            return View(dotacion);
        }

        // GET: Dotaciones/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dotacion = await _context.Dotaciones.FindAsync(id);
            if (dotacion == null)
            {
                return NotFound();
            }

            await PopulateViewData();
            return View(dotacion);
        }

        // POST: Dotaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, Dotacion dotacion)
        {
            if (id != dotacion.ID)
            {
                return NotFound();
            }

            ModelState.Remove("Correo"); // Hacer el correo no obligatorio

            if (ModelState.IsValid)
            {
                try
                {
                    // Manejar conversión de fechas
                    if (dotacion.Fecha_Ingreso.HasValue)
                    {
                        dotacion.Fecha_Ingreso = dotacion.Fecha_Ingreso.Value.Date;
                    }

                    if (dotacion.Fecha_Baja.HasValue)
                    {
                        dotacion.Fecha_Baja = dotacion.Fecha_Baja.Value.Date;
                    }

                    _context.Update(dotacion);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Dotación actualizada exitosamente";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DotacionExists(dotacion.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            await PopulateViewData();
            return View(dotacion);
        }

        // GET: Dotaciones/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dotacion = await _context.Dotaciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dotacion == null)
            {
                return NotFound();
            }

            return View(dotacion);
        }

        // POST: Dotaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var dotacion = await _context.Dotaciones.FindAsync(id);
            if (dotacion != null)
            {
                _context.Dotaciones.Remove(dotacion);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Dotación eliminada exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DotacionExists(short id)
        {
            return _context.Dotaciones.Any(e => e.ID == id);
        }

        private async Task PopulateViewData()
        {
            var emptyList = new List<string> { "" };

            ViewData["Pais_Call_Center"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Pais_Call_Center)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["Area"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Area)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["AreaGestion"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.AreaGestion)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["Contrato"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Contrato.ToString())
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["Tipos_de_agente"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Tipos_de_agente)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["Servicio"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Servicio)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();

            ViewData["Nombre_Jefatura"] = emptyList.Concat(await _context.Dotaciones
                .Select(d => d.Nombre_Jefatura)
                .Distinct()
                .Where(d => d != null)
                .OrderBy(d => d)
                .ToListAsync()).ToList();
        }
    }
}