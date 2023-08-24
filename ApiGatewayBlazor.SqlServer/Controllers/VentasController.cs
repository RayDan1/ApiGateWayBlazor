using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiGatewayBlazor.SqlServer.Data;
using ApiGatewayBlazor.SqlServer.Models;
using System.Diagnostics;
using ApiGatewayBlazor.Shared;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> Index()
        {
            var ventas = await _context.Ventas.ToListAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var ventas = await _context.Ventas.FindAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        [HttpPost]
        public async Task<ActionResult<VentaDTO>> PostVenta([FromBody] VentaDTO ventas)
        {
            Venta venta = new Venta()
            {
                IdCliente = ventas.IdCliente,
                IdProducto = ventas.IdProducto,
                Cantidad = ventas.Cantidad
            };
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return Ok(ventas);
           // return ventas;
            //return CreatedAtAction("GetVentas", new { Id = ventas.IdVenta }, ventas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta ventas)
        {
            if (id != ventas.IdVenta)
            {
                return BadRequest();
            }

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.IdVenta == id);
        }
    }
}
