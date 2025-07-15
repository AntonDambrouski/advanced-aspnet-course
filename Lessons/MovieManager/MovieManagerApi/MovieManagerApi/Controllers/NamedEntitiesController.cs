using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManagerApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NamedEntitiesController(INamedEntitiesRepository<Language> langRepo, INamedEntitiesRepository<Category> categRepo) : ControllerBase
{

    // GET: api/<NamedEntitiesController>
    [HttpGet("languages")]
    public async Task<IEnumerable<Language>> Get()
    {
        return await langRepo.GetAllAsync();
    }

    [HttpGet("categories")]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await categRepo.GetAllAsync();
    }

    // GET api/<NamedEntitiesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<NamedEntitiesController>
    [HttpPost]
    public async Task Post([FromBody] string value)
    {
        await langRepo.CreateAsync(new Language { Name = value });
        await categRepo.CreateAsync(new Category { Name = value });
    }

    // PUT api/<NamedEntitiesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<NamedEntitiesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
