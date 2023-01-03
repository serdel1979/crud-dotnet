using CrudUdemy.Context;
using CrudUdemy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {

        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Gestor>>> Get()
        {
            try
            {
                return await context.gestores_bd.ToListAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Gestor>> GetGestor(int id)
        {
            try
            {
                var autor = await context.gestores_bd.FirstOrDefaultAsync(x => x.id == id);
                if (autor == null)
                {
                    return NotFound();
                }
                return autor;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult> Post(Gestor gestor)
        {
            try
            {
                var existe = await context.gestores_bd.AnyAsync(x => x.nombre == gestor.nombre);
                if (existe)
                {
                    return BadRequest($"El autor {gestor.nombre} ya existe!!!");
                }

                context.Add(gestor);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Gestor gestor, int id)
        {
            //try
            //{
                if (gestor.id != id)
                {
                    return BadRequest("Error de id");
                }
                var existe = await context.gestores_bd.AnyAsync(x => x.id == id);
                if (!existe)
                {
                    return NotFound();
                }
                context.Update(gestor);
                await context.SaveChangesAsync();
                return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existe = await context.gestores_bd.AnyAsync(x => x.id == id);
                if (!existe)
                {
                    return NotFound();
                }

                context.Remove(new Gestor() { id = id });
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
