using RpgHBAnnals.data;
using RpgHBAnnals.Model.Npc;
using RpgHBAnnals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Service
{
    public class NpcService
    {
        private readonly Guid _userId;
        private readonly int _game;

        public NpcService(Guid userid)
        {
            _userId = userid;
        }
        public NpcService(int gameid)
        {
            _game = gameid;
        }

        public bool CreateNpc(NpcCreate model)
        {
            var entity = new Npc()
            {

                CreatorId = _userId,
                GameId = _game,
                CreatedUtc = DateTimeOffset.Now,
                Name = model.Name,
                Race = model.Race,
                Notes = model.Notes
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Npcs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<NpcListItem> GetNpc()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx
                                .Npcs
                                //.Where(e => e.CreatorId == _userId)
                                .Select(e => new NpcListItem()
                                {
                                    NpcId = e.NpcId,
                                    CreatedUtc = e.CreatedUtc,
                                    Name = e.Name,
                                    Race = e.Race,
                                });
                return quary.ToArray();
            }
        }
        public NpcDetail GetNpcById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Npcs
                                .Single(e => e.NpcId == id);//&& e.CreatorId == _userId);
                return new NpcDetail()
                {
                    NpcId = entity.NpcId,
                    CreatorId = entity.CreatorId,
                    GameId = entity.GameId,
                    CreatedUtc = entity.CreatedUtc,
                    Name = entity.Name,
                    Race = entity.Race,
                    Notes = entity.Notes
                };
            }
        }
        public bool UpdateNpc(NpcEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Npcs
                                .Single(e => e.NpcId == model.NpcId && e.CreatorId == _userId);
                entity.Name = model.Name;
                entity.Race = model.Race;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNpc(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Npcs
                                .Single(e => e.NpcId == id && e.CreatorId == _userId);
                ctx.Npcs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
