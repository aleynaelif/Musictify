using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlbumsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AlbumsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbum()
        {
            return await _context.Album.ToListAsync();
        }

        // GET: api/AlbumsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Album.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/AlbumsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumID)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AlbumsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Album.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.AlbumID }, album);
        }

        // DELETE: api/AlbumsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Album.Remove(album);
            await _context.SaveChangesAsync();

            return album;
        }

        private bool AlbumExists(int id)
        {
            return _context.Album.Any(e => e.AlbumID == id);
        }
    }
}
