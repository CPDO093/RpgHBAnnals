using RpgHBAnnals.data;
using RpgHBAnnals.Model.Game;
using RpgHBAnnals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Service
{
    public class GameService
    {
        private readonly Guid _userId;
        public GameService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                Name = model.Name,
                Edition = model.Edition,
                CreatedUtc = DateTimeOffset.Now,
                CreatorId = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx
                                .Games
                                //.Where(e => e.CreatorId == _userId)
                                .Select(e => new GameListItem()
                                {
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    Edition = e.Edition,
                                    CreatedUtc = e.CreatedUtc,
                                    CreatorId = e.CreatorId
                                });
                return quary.ToArray();
            }
        }
        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Games
                                .Single(e => e.GameId == id); // && e.CreatorId == _userId);
                return new GameDetail()
                {
                    GameId = entity.GameId,
                    Name = entity.Name,
                    Edition = entity.Edition,
                    CreatorId = entity.CreatorId,
                    CreatedUtc = entity.CreatedUtc
                };
            }
        }
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Games
                                .Single(e => e.GameId == model.GameId && e.CreatorId == _userId);
                entity.Name = model.Name;
                entity.Edition = model.Edition;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Games
                                .Single(e => e.GameId == id && e.CreatorId == _userId);
                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
