using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _car;
        private readonly Iimage _image;


        public CitiesController(MiniprojectContext context, Icity icity, Icar car, Iimage image)
        {
            _context = context;
            _city = icity;
            _car = car;
            _image = image;

        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            try
            {

            var city = _city.GetAll();
            var ci = from x in city
                     select new
                     {
                         x.Cityid,
                         x.Cityname
                     };
            return Ok(ci);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("car")]
        public IActionResult GetCity()
        {
            var x = _car.GetAll();
            var z = _image.GetAll();

            var y = _city.GetAll();


           
            return Ok(y);
        }



        // GET: api/Cities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<City>> GetCity(int id)
        //{
        //    if (_context.Cities == null)
        //    {
        //        return NotFound();
        //    }
        //    var city = await _context.Cities.FindAsync(id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return city;
        //}

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCity(int id, City city)
        //{
        //    if (id != city.Cityid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(city).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<City>> PostCity(City city)
        //{
        //    if (_context.Cities == null)
        //    {
        //        return Problem("Entity set 'MiniprojectContext.Cities'  is null.");
        //    }
        //    _context.Cities.Add(city);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCity", new { id = city.Cityid }, city);
        //}

        // DELETE: api/Cities/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCity(int id)
        //{
        //    if (_context.Cities == null)
        //    {
        //        return NotFound();
        //    }
        //    var city = await _context.Cities.FindAsync(id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cities.Remove(city);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CityExists(int id)
        {
            return (_context.Cities?.Any(e => e.Cityid == id)).GetValueOrDefault();
        }

     
    }
}
