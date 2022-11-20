using ApiConductor.DBContext;
using ApiConductor.DTO;
using ApiConductor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiConductor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerSancion : ControllerBase
    {
         private readonly context _context;

        public ControllerSancion(context context)
        {
            _context = context;
        }

        #region Metodos
        // Imprimir
        // GET: api/ControllerSancion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            try
            {
                var SAnciones = await _context.sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor

                }).ToListAsync();
                if (SAnciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return SAnciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        
        // Buscar por id
        // GET api/ControllerSancion/5
        [HttpGet("{id}")]


        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            try
            {
                var SAnciones = await _context.sanciones.Select(x =>
                new SancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (SAnciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return SAnciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        // Insertar
        // POST api/ControllerSancion
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            try
            {
                var entity = new Sanciones()
                {

                    FechaActual = sanciones.FechaActual,
                    ConductorId = sanciones.ConductorId,
                    Sancion = sanciones.Sancion,
                    Observacion = sanciones.Observacion,
                    Valor = sanciones.Valor
                };
                _context.sanciones.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }

        //Actualizar
        // PUT api/ControllerSancion/5
        [HttpPut("{conductorid}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sanciones)
        {
            var entity = await _context.sanciones.FirstOrDefaultAsync(v => v.ConductorId == sanciones.ConductorId);

            entity.ConductorId = sanciones.ConductorId;
            entity.FechaActual = (DateTime)sanciones.FechaActual;
            entity.Sancion = sanciones.Sancion;
            entity.Observacion = sanciones.Observacion;
            entity.Valor = sanciones.Valor;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }


        // DELETE api/ControllerSancion/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var sancionesS = _context.sanciones.Find(id);
            if (sancionesS == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(sancionesS).State = EntityState.Deleted;
                _context.SaveChanges();

            }
            return HttpStatusCode.OK;
        }

        #endregion Metodos


    }
}
