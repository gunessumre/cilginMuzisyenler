using cilginMuzisyenler.Models;
using cilginMuzisyenler.Repositories;
using cilginMuzisyenler.Models;
using cilginMuzisyenler.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cilginMuzisyenler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly MusicianRepository _repository = new();

        // GET: api/musicians
        [HttpGet]
        public IActionResult GetAllMusicians() => Ok(_repository.GetAll());

        // GET: api/musicians/{id}
        [HttpGet("{id}")]
        public IActionResult GetMusicianById(int id)
        {
            var musician = _repository.GetById(id);
            if (musician == null) return NotFound();
            return Ok(musician);
        }

        // GET: api/musicians/search?name={name}
        [HttpGet("search")]
        public IActionResult SearchMusicians([FromQuery] string name)
        {
            var results = _repository.SearchByName(name);
            return Ok(results);
        }

        // POST: api/musicians
        [HttpPost]
        public IActionResult AddMusician([FromBody] Musician musician)
        {
            _repository.Add(musician);
            return CreatedAtAction(nameof(GetMusicianById), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician musician)
        {
            _repository.Update(id, musician);
            return NoContent();
        }

        // PATCH: api/musicians/{id}/funfeature
        [HttpPatch("{id}/funfeature")]
        public IActionResult PatchFunFeature(int id, [FromBody] string funFeature)
        {
            _repository.PatchFunFeature(id, funFeature);
            return NoContent();
        }

        // DELETE: api/musicians/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMusician(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}