using Microsoft.AspNetCore.Mvc;

namespace PetsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    // GET: api/Pets
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/Pets/{id}
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/Pets
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/Pets/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/Pets/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
