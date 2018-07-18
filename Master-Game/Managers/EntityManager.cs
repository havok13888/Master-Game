using System;
using System.Collections.Generic;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class EntityManager
    {
        List<BaseEntity> EntityList = new List<BaseEntity>();

        public void Initialize()
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
    }
}
