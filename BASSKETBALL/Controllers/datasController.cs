using BASSKETBALL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BASSKETBALL.Models.DTOs;

namespace BASSKETBALL.Controllers
{
    [Route("Matchdatum")]
    [ApiController]
    public class datasController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Matchdatum> Post(matchData newData)
        {
            var ujdata= new Matchdatum()
            {
                Id = Guid.NewGuid(),
                Be = newData.be,
                Ki = newData.ki,
                Try = newData.proba,
                Goal = newData.goal,
                Fault = newData.fault,
                Createdtime=DateTime.Now,
                Updatedtime=DateTime.Now,
                PlayerId=newData.playerId,
            };
            using (var context = new BasketteamContext())
            {
                context.Matchdata.Add(ujdata);
                context.SaveChanges();
                return StatusCode(200, ujdata);
            }
        }
        [HttpGet]
        public ActionResult<Matchdatum> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Matchdata.ToList());
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Matchdatum> Get(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Matchdata.Where(x => x.Id == id).ToList());
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Matchdatum> Put(Guid id, updateData data)
        {
            using(var context = new BasketteamContext())
            {
                var updatedData=context.Matchdata.FirstOrDefault(x=> x.Id == id);
                if (updatedData != null)
                {
                    updatedData.Updatedtime = DateTime.Now;
                    updatedData.Try = data.proba;
                    updatedData.Be=data.be;
                    updatedData.Ki=data.ki;
                    updatedData.Try = data.proba;
                    updatedData.Goal=data.goal;
                    updatedData.Fault=data.fault;

                    context.Update(updatedData);
                    context.SaveChanges();
                    return StatusCode(200, updatedData);
                }
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult<Matchdatum> Delete(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var deletingData= context.Matchdata.FirstOrDefault(x=>x.Id == id);
                if (deletingData!=null)
                {
                    context.Remove(deletingData);
                    context.SaveChanges();
                    return StatusCode(200, new {message="Sikeres törlés"});
                }
                return BadRequest(new {message="sikertelen törlés"});
            }
        }
    }
}
