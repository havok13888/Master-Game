﻿using System;
using MasterGame.Global;

namespace MasterGame.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public PlayerEntity(string name, float healthPoints, float maxHealthPoints)
           : base(EntityType.Player, name, healthPoints, maxHealthPoints, true, true, true, true)
        {
        }

        public void Reset()
        {
            HealthPoints = 100.0f;
            Position.X = 0;
            Position.Y = 0;
        }
    }
}
