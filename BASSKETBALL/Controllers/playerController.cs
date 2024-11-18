using BASSKETBALL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BASSKETBALL.Models.DTOs;

namespace BASSKETBALL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class playerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> Post(playerPost newplayer)
        {
            Player player = new Player
            {
                Id = Guid.NewGuid(),
                Name = newplayer.name,
                Height = newplayer.height,
                Weight = newplayer.weight,
                CreatedTime = DateTime.Now,
            };
            using (var context = new BasketteamContext())
            {
                if (newplayer != null)
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                }
                return BadRequest();
            }
        }
        [HttpGet]
        public ActionResult<Player> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Players.Include(x=>x.Matchdata).ToList());
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Player> Get(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Players.Where(x => x.Id == id).Include(x => x.Matchdata).ToList());
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Player> Put(Guid id, playerPut updatedPlayer)
        {
            using (var context = new BasketteamContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(x => x.Id == id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = updatedPlayer.name;
                    existingPlayer.Height = updatedPlayer.height;
                    existingPlayer.Weight = updatedPlayer.weight;

                    context.Players.Update(existingPlayer);
                    context.SaveChanges();
                    return StatusCode(200, existingPlayer);
                }
                return BadRequest();
            }
        }
        [HttpDelete]
        public ActionResult<Player> Delete(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var deleteablePlayer = context.Players.FirstOrDefault(x => x.Id == id);
                var deleteData = context.Matchdata.FirstOrDefault(x => x.PlayerId == id);
                if (deleteablePlayer != null)
                {
                    context.Players.Remove(deleteablePlayer);
                    if (deleteData!=null)
                    {
                        context.Matchdata.Remove(deleteData);
                    }
                    context.SaveChanges();
                    return StatusCode(200, new { message = "sikeres törlés" });
                }
                return NotFound();
            }
        }
    }
}
