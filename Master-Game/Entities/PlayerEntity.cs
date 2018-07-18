using System;
using MasterGame.Global;

namespace MasterGame.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public PlayerEntity(string name, float healthPoints)
           : base(EntityType.Player, name, healthPoints, true, true, true, true)
        {
        }
    }
}
