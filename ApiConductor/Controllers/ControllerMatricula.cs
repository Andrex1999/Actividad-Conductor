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
    public class ControllerMatricula : ControllerBase
    {
        

        private readonly context _context;

        public ControllerMatricula(context context)
        {
            _context = context;
        }

        #region Metodos

        // Imprimir datos
        // GET: api/ControllerMatricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            try
            {
                var matriculas = await _context.matricula.Select(x =>
                new MatriculaDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    FechadeExpiracion = x.FechadeExpiracion,
                    Activo = x.Activo
                }).ToListAsync();
                if (matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        // Buscar por id
        // GET api/ControllerMatricula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDTO>> Get(int id)
        {
            try
            {
                var matriculas = await _context.matricula.Select(x =>
                new MatriculaDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    FechadeExpiracion = x.FechadeExpiracion,
                    Activo = x.Activo
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }








        // Insertar
        // POST api/ControllerMatricula
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTO matricula)
        {
            try
            {
                var entity = new Matricula()
                {
                    
                    Numero = matricula.Numero,
                    FechaExpedicion = matricula.FechaExpedicion,
                    FechadeExpiracion = matricula.FechadeExpiracion,
                    Activo = matricula.Activo
                };
                _context.matricula.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }


        //Actualizar
        
        // PUT api/<MatriculaController>/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matricula)
        {
            var entity = await _context.matricula.FirstOrDefaultAsync(v => v.Numero == matricula.Numero);
            
            entity.Numero = matricula.Numero;
            entity.FechaExpedicion = (DateTime)matricula.FechaExpedicion;
            entity.FechadeExpiracion = (DateTime)matricula.FechadeExpiracion;
            entity.Activo = matricula.Activo;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }





        // DELETE api/ControllerMatricula/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var matriculas = _context.matricula.Find(id);
            if (matriculas == null)
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                _context.Entry(matriculas).State = EntityState.Deleted;
                _context.SaveChanges();

            }
            return HttpStatusCode.OK;
        }
        #endregion Metodos
    }
}
