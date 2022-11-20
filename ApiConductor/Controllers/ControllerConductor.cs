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
    public class ControllerConductor : ControllerBase
    {

        private readonly context _context;

        public ControllerConductor(context context)
        {
            _context = context;
        }


        #region Metodos
        // Imprimir datos
        // GET: api/ControllerConductor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            try
            {
                var conductores = await _context.conductor.Select(x =>
                new ConductorDTO
                {
                    Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Activo = x.Activo,
                    MatriculaId = x.MatriculaId




                }).ToListAsync();
                if (conductores == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        // Buscar por id
        // GET api/ControllerConductor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConductorDTO>> Get(int id)
        {
            try
            {
                var conductores = await _context.conductor.Select(x =>
                new ConductorDTO
                {
                    Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Activo = x.Activo,
                    MatriculaId = x.MatriculaId
               
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (conductores == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Insertar
        // POST api/ControllerConductor
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            
                var entity = new Conductor()
                {
                   
                    Identificacion = conductor.Identificacion,
                    Nombre = conductor.Nombre,
                    Direccion = conductor.Direccion,
                    Telefono = conductor.Telefono,
                     Email = conductor.Email,
                      FechaNacimiento = conductor.FechaNacimiento,
                       Activo = conductor.Activo,
                        
                };
                _context.conductor.Add(entity);
                await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
            
            
           
        




        // PUT api/ControllerConductor/5
        [HttpPut("{identificacion}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductor)
        {
            var entity = await _context.conductor.FirstOrDefaultAsync(v => v.Identificacion == conductor.Identificacion);

            entity.Identificacion = conductor.Identificacion;
            entity.Nombre = conductor.Nombre;
            entity.Direccion = conductor.Direccion;
            entity.Telefono = conductor.Telefono;
            entity.Email = conductor.Email;
            entity.FechaNacimiento = conductor.FechaNacimiento;
            entity.Activo = conductor.Activo;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        // DELETE api/<ControllerConductor>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var conductores = _context.conductor.Find(id);
            if (conductores == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(conductores).State = EntityState.Deleted;
                _context.SaveChanges();

            }
            return HttpStatusCode.OK;
        }


        #endregion Metodos

    }
}
