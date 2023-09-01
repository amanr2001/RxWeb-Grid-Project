﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication2.Models;

//namespace WebApplication2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly MiniprojectContext _context;

//        public ImagesController(MiniprojectContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Images
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
//        {
//            if (_context.Images == null)
//            {
//                return NotFound();
//            }
//            return await _context.Images.ToListAsync();
//        }

//        // GET: api/Images/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Image>> GetImage(int id)
//        {
//            if (_context.Images == null)
//            {
//                return NotFound();
//            }
//            var image = await _context.Images.FindAsync(id);

//            if (image == null)
//            {
//                return NotFound();
//            }

//            return image;
//        }

//        // PUT: api/Images/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutImage(int id, Image image)
//        {
//            if (id != image.Imageid)
//            {
//                return BadRequest();
//            }

//            _context.Entry(image).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ImageExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Images
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Image>> PostImage(Image image)
//        {
//            if (_context.Images == null)
//            {
//                return Problem("Entity set 'MiniprojectContext.Images'  is null.");
//            }
//            _context.Images.Add(image);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetImage", new { id = image.Imageid }, image);
//        }

//        // DELETE: api/Images/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteImage(int id)
//        {
//            if (_context.Images == null)
//            {
//                return NotFound();
//            }
//            var image = await _context.Images.FindAsync(id);
//            if (image == null)
//            {
//                return NotFound();
//            }

//            _context.Images.Remove(image);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ImageExists(int id)
//        {
//            return (_context.Images?.Any(e => e.Imageid == id)).GetValueOrDefault();
//        }
//    }
//}
