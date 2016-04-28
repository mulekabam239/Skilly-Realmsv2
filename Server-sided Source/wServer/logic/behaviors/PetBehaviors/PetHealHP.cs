using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetHealHP : PetBehavior
    {
        //<Parameters>
        //   <MaxHeal min = "10" max="90" curve="exp_incr"/>
        //   <Cooldown min = "10" max="1" curve="dim_returns"/>
        //</Parameters>

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 1000;
            base.OnStateEntry(host, time, ref state);
        }

        protected override bool PlayerOwnerRequired => true;

        protected override void TickCore(Pet pet, RealmTime time, ref object state)
        {
            var cool = (int)state;
            if (cool <= 0)
            {
                Player player = pet.GetEntity(pet.PlayerOwner.Id) as Player;
                if (player == null) return;

                int maxHp = player.Stats[0] + player.Boost[0];
                int h = GetHP(pet, ref cool);
                if (h == -1) return;
                int newHp = Math.Min(maxHp, player.HP + h);
                if (newHp != player.HP)
                {
                    if (player.HasConditionEffect(ConditionEffectIndex.Sick))
                    {
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Trail,
                            TargetId = pet.Id,
                            PosA = new Position {X = player.X, Y = player.Y},
                            Color = new ARGB(0xffffffff)
                        }, null);
                        player.Owner.BroadcastPacket(new NotificationPacket
                        {
                            ObjectId = player.Id,
                            Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"No Effect\"}}",
                            Color = new ARGB(0xFF0000)
                        }, null);
                        state = cool;
                        return;
                    }
                    int n = newHp - player.HP;
                    player.HP = newHp;
                    player.UpdateCount++;
                    player.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        EffectType = EffectType.Potion,
                        TargetId = player.Id,
                        Color = new ARGB(0xffffffff)
                    }, null);
                    player.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        EffectType = EffectType.Trail,
                        TargetId = pet.Id,
                        PosA = new Position {X = player.X, Y = player.Y},
                        Color = new ARGB(0xffffffff)
                    }, null);
                    player.Owner.BroadcastPacket(new NotificationPacket
                    {
                        ObjectId = player.Id,
                        Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"+" + n + "\"}}",
                        Color = new ARGB(0xff00ff00)
                    }, null);
                }
            }
            else
                cool -= time.thisTickTimes;

            state = cool;
        }

        private int GetHP(Pet host, ref int cooldown)
        {
              for (var i = 0; i < 3; i++)
              {
                  switch (i)
                  {
                      case 0:
                          if (host.FirstPetLevel.Ability == Ability.Heal)
                          {
                              return CalculateHeal(host.FirstPetLevel.Level, ref cooldown);
                          }
                          break;
                      case 1:
                          if (host.SecondPetLevel.Ability == Ability.Heal)
                          {
                              return CalculateHeal(host.SecondPetLevel.Level, ref cooldown);
                          }
                          break;
                      case 2:
                          if (host.ThirdPetLevel.Ability == Ability.Heal)
                          {
                              return CalculateHeal(host.ThirdPetLevel.Level, ref cooldown);
                          }
                          break;
                  }
              }
              return -1;
        }

        private int CalculateHeal(int level, ref int cooldown)
        {
            if (Enumerable.Range(0, 10).Contains(level))
            {
                cooldown = 4500;
                return 10;
            }
            else if (Enumerable.Range(10, 10).Contains(level))
            {
                cooldown = 4500;
                return 12;
            }
            else if (Enumerable.Range(20, 10).Contains(level))
            {
                cooldown = 4500;
                return 14;
            }
            else if (Enumerable.Range(30, 6).Contains(level))
            {
                cooldown = 4500;
                return 16;
            }
            else if (Enumerable.Range(36, 6).Contains(level))
            {
                cooldown = 4500;
                return 18;
            }
            else if (Enumerable.Range(42, 4).Contains(level))
            {
                cooldown = 4500;
                return 20;
            }
            else if (Enumerable.Range(46, 4).Contains(level))
            {
                cooldown = 4500;
                return 22;
            }
            else if (Enumerable.Range(50, 4).Contains(level))
            {
                cooldown = 4500;
                return 24;
            }
            else if (Enumerable.Range(54, 8).Contains(level))
            {
                cooldown = 4500;
                return 26;
            }
            else if (Enumerable.Range(62, 6).Contains(level))
            {
                cooldown = 4500;
                return 28;
            }
            else if (Enumerable.Range(68, 2).Contains(level))
            {
                cooldown = 4500;
                return 30;
            }
            else if (Enumerable.Range(70, 5).Contains(level))
            {
                cooldown = 4500;
                return 32;
            }
            else if (Enumerable.Range(75, 5).Contains(level))
            {
                cooldown = 4500;
                return 34;
            }
            else if (Enumerable.Range(80, 5).Contains(level))
            {
                cooldown = 4500;
                return 36;
            }
            else if (Enumerable.Range(85, 5).Contains(level))
            {
                cooldown = 4500;
                return 38;
            }
            else if (Enumerable.Range(90, 5).Contains(level))
            {
                cooldown = 4500;
                return 40;
            }
            else if (Enumerable.Range(95, 5).Contains(level))
            {
                cooldown = 4500;
                return 42;
            }
            else if (Enumerable.Range(100, 4).Contains(level))
            {
                cooldown = 4500;
                return 44;
            }
            else if (Enumerable.Range(104, 6).Contains(level))
            {
                cooldown = 700;
                return 165;
            }
            else if (Enumerable.Range(110, 5).Contains(level))
            {
                cooldown = 650;
                return 198;
            }
            else if (Enumerable.Range(115, 5).Contains(level))
            {
                cooldown = 600;
                return 231;
            }
            if (!Enumerable.Range(120, 1).Contains(level)) throw new Exception("Invalid PetLevel");
            {
                cooldown = 550;
                return 282;
            }
            //switch (level)
            //{
            //    case 1:
            //        cooldown = 10000;
            //        return 10;
            //    case 2:
            //        cooldown = 9200;
            //        return 11;
            //    default:
            //        throw new Exception("Invalid PetLevel");
            //}
        }
    }
}
