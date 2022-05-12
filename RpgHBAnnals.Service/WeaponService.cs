using RpgHBAnnals.data;
using RpgHBAnnals.Model.Weapon;
using RpgHBAnnals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Service
{
    public class WeaponService
    {
        private readonly Guid _userId;
        private readonly int _game;
        public WeaponService(Guid userid)
        {
            _userId = userid;
        }
        public WeaponService(int gameid)
        {
            _game = gameid;
        }

        public bool CreateWeapon(WeaponCreate model)
        {
            var entity = new Weapon()
            {

                CreatorId = _userId,
                GameId = _game,
                CreatedUtc = DateTimeOffset.Now,
                Type = model.Type,
                Name = model.Name,
                Damage = model.Damage,
                Properties = model.Properties
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Weapons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WeaponListItem> GetWeapon()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx
                                .Weapons
                                //.Where(e => e.CreatorId == _userId)
                                .Select(e => new WeaponListItem()
                                {
                                    WeaponId = e.WeaponId,
                                    GameId = e.GameId,
                                    CreatedUtc = e.CreatedUtc,
                                    Type = e.Type,
                                    Name = e.Name
                                });
                return quary.ToArray();
            }
        }
        public WeaponDetail GetWeaponById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Weapons
                                .Single(e => e.WeaponId == id);//&& e.CreatorId == _userId);
                return new WeaponDetail()
                {
                    WeaponId = entity.WeaponId,
                    CreatorId = entity.CreatorId,
                    GameId = entity.GameId,
                    CreatedUtc = entity.CreatedUtc,
                    Type = entity.Type,
                    Name = entity.Name,
                    Damage = entity.Damage,
                    Properties = entity.Properties
                };
            }
        }

        public bool UpdateWeapon(WeaponEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Weapons
                                .Single(e => e.WeaponId == model.WeaponId && e.CreatorId == _userId);
                entity.Type = model.Type;
                entity.Name = model.Name;
                entity.Damage = model.Damage;
                entity.Properties = model.Properties;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWeapon(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Weapons
                                .Single(e => e.WeaponId == id && e.CreatorId == _userId);
                ctx.Weapons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
