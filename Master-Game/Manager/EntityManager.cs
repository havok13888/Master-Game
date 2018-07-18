using System;
using System.Collections.Generic;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class EntityManager
    {
        List<BaseEntity> EntityList = new List<BaseEntity>();
        public EntityManager()
        {
        }

        public void LoadEntities()
        {
            EntityList.Add(new PlayerEntity("PlayerOne", 100.0f));
        }

        public BaseEntity GetPlayer()
        {
            foreach (BaseEntity entity in EntityList)
            {
                if (entity.PlayerControlled)
                {
                    return entity;
                }
            }
            return null;
        }

        public bool IsPlayerAlive()
        {
            BaseEntity entity = GetPlayer();
            if(entity is PlayerEntity && entity.HealthPoints > 0.0f)
            {
                return true;
            }
            return false;
        }
    }
}
