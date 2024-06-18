using Microsoft.AspNetCore.Mvc;
using Knight.API.Models;
using Knight.API.Data;
using MongoDB.Driver;
using Knight.API.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using Knight.API.Helper;
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Expressions;
using MongoDB.Driver.Core.WireProtocol.Messages;
using Amazon.Runtime.Internal;

namespace Knight.API.Controllers
{
    [ApiController]
    [Route("api/Knight")]
    public class KnightController : ControllerBase
    {
        private readonly IMongoCollection<KnightHero>? _knightHero;

        public KnightController(MongoDbService mongoDbService)
        {
            _knightHero = mongoDbService.Database?.GetCollection<KnightHero>("KnightHero");   
        }

        [HttpGet()]
        public async Task<IEnumerable<KnightHeroViewModel>> Get()
        {
            var knight = await _knightHero.Find(FilterDefinition<KnightHero>.Empty).ToListAsync();

            var ret = knight.Select(x =>
            {
                int age = Utils.AgeCalculator(x.Birthday ?? DateTime.Now);

                int mod = 0;

                switch (x.KeyAttribute)
                {
                    case "strength":
                        mod = x.Attributes.Strenght ?? 0;
                        break;
                    case "dexterity":
                        mod = x.Attributes.Dexterity ?? 0;
                        break;
                    case "constitution":
                        mod = x.Attributes.Constitution ?? 0;
                        break;
                    case "intelligence":
                        mod = x.Attributes.Intelligence ?? 0;
                        break;
                    case "wisdom":
                        mod = x.Attributes.Wisdom ?? 0;
                        break;
                    case "charisma":
                        mod = x.Attributes.Charisma ?? 0;
                        break;
                }

                var attack = 10 + Utils.TableMod(mod) + x.Weapons.Where(w => w.Equipped == true).Select(w => w.Mod).Sum();

                double exp = (int)Math.Floor((decimal)age - 7) * Math.Pow(22, 1.45);

                return new KnightHeroViewModel(
                x.Name,
                age,
                x.Weapons.Count(),
                x.KeyAttribute,
                attack ?? 0,
                exp
                );
            });

            return ret;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<KnightHero?>> GetById(string id)
        {

            var filter = Builders<KnightHero>.Filter.Eq(x => x.Id, id);
            var knightHero = _knightHero.Find(filter).FirstOrDefault();
            return knightHero is not null ? Ok(knightHero) : NotFound();
        }


        [HttpPost]
        public async Task<ActionResult> Create(KnightHero knightHero)
        {
            await _knightHero.InsertOneAsync(knightHero);
            return CreatedAtAction(nameof(GetById), new { id = knightHero.Id }, knightHero);
        }


        [HttpPut]
        public async Task<ActionResult> Update(KnightHero knightHero)
        {
            var filter = Builders<KnightHero>.Filter.Eq(x => x.Id, knightHero.Id);
            await _knightHero.ReplaceOneAsync(filter, knightHero);
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<KnightHero>.Filter.Eq(x => x.Id, id);
            await _knightHero.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
