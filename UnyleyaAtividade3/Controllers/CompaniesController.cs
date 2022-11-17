using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnyleyaAtividade3.Model;
using UnyleyaAtividade3.Repositories;

namespace UnyleyaAtividade3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICopaniesRespository _copaniesRespository;

        public CompaniesController(ICopaniesRespository copaniesRespository)
        {
            _copaniesRespository = copaniesRespository;
        }

        [HttpGet]
        public async Task<IEnumerable<Companies>> GetCompanies()
        {
            return await _copaniesRespository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompaniesById(int id)
        {
            return await _copaniesRespository.Get(id);
        }

        [HttpGet("GetCompaniesByName/{name}")]
        public async Task<ActionResult<List<Companies>>> GetCompaniesByName(string name)
        {
            return await _copaniesRespository.GetByName(name);
        }


        [HttpGet("GetCompaniesByAdress/{adress}")]
        public async Task<ActionResult<List<Companies>>> GetCompaniesByAdress(string adress)
        {
            return await _copaniesRespository.GetByAdress(adress);
        }

        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies([FromBody] Companies comp)
        {
            var newCompany = await _copaniesRespository.Create(comp);
            return CreatedAtAction(nameof(GetCompanies), new {id = newCompany.Id}, newCompany);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete (int Id)
        {
            var comp = await _copaniesRespository.Get(Id);
            if (comp == null)
                return NotFound();
           
            
            await _copaniesRespository.Delete(comp.Id);
            return NoContent();

            
        }

        [HttpPut]
        public async Task<ActionResult> PutCompanies(int id, [FromBody] Companies comp)
        {
            if (id != comp.Id)
                return NotFound();


                await _copaniesRespository.Update(comp);

            return Ok();
        }


    }
}
