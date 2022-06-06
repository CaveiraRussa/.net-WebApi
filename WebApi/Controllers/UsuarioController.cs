using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repository;
       public UsuarioController(IRepository repo)
        {
            this._repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult>Get() {

            try
            {
                var result = await _repository.GetAllUsuariosAsync();
                return Ok(result);
                
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int UsuarioId)
        {
            try
            {
                var result = await _repository.GetUsuarioAsyncById(UsuarioId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Usuario model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{UsuarioId}")]
        public async Task<IActionResult> put(int UsuarioId, Usuario model)
        {
            try
            {
                var Usuario = await _repository.GetUsuarioAsyncById(UsuarioId);
                if (Usuario == null) return NotFound();

                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{UsuarioId}")]
        public async Task<IActionResult> delete(int UsuarioId)
        {
            try
            {
                var Usuario = await _repository.GetUsuarioAsyncById(UsuarioId);
                if (Usuario == null) return NotFound();

                _repository.Delete(Usuario);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}