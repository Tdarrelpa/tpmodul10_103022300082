using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300082.Models;

namespace tpmodul10_103022300082.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static readonly List<MahasiswaModel> _mahasiswaList = new List<MahasiswaModel>()
        {
            new MahasiswaModel { Id = 1, Name = "Timotius Darrel Putra Arma", Nim = "10302230082" },
            new MahasiswaModel { Id = 2, Name = "Fa Ainama Caldera Sudibyo", Nim = "103022300144" },
            new MahasiswaModel { Id = 3, Name = "Muhammad Abiyyu Al-Ghifahri", Nim = "103022300121"},
            new MahasiswaModel { Id = 4, Name = "Afriza Gilleon Ginting", Nim = "103022300154"}
        };

        // GET: api/<MahasiswaController>
        [HttpGet]
        public ActionResult<IEnumerable<MahasiswaModel>> Get()
        {
            return _mahasiswaList;
        }

        // GET api/<MahasiswaController>/5
        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            var mahasiswa = _mahasiswaList.FirstOrDefault(m => m.Id == id);

            if (mahasiswa == null)
            {
                return NotFound();
            }

            return mahasiswa;
        }

        // POST api/<MahasiswaController>
        [HttpPost]
        public ActionResult<MahasiswaModel> Post([FromBody] MahasiswaModel mahasiswa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mahasiswa.Id = _mahasiswaList.Any() ? _mahasiswaList.Max(m => m.Id) + 1 : 1;
            _mahasiswaList.Add(mahasiswa);

            return CreatedAtAction(nameof(Get), new { id = mahasiswa.Id }, mahasiswa);
        }

        /* PUT api/<MahasiswaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MahasiswaModel mahasiswa)
        {
            if (id != mahasiswa.Id)
            {
                return BadRequest("ID Mismatch");
            }

            var exists = _mahasiswaList.FirstOrDefault(m => m.Id == id);

            if (exists == null)
            {
                return NotFound();
            }

            exists.Name = mahasiswa.Name;
            exists.Nim = mahasiswa.Nim;

            return NoContent();
        }
        */

        // DELETE api/<MahasiswaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mahasiswa = _mahasiswaList.FirstOrDefault(m => m.Id == id);

            if (mahasiswa == null)
            {
                return NotFound();
            }

            _mahasiswaList.Remove(mahasiswa);
            return NoContent();
        }
    }
}