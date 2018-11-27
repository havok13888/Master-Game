using System.Collections.Generic;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class EntityManager
    {
        List<BaseEntity> EntityList = new List<BaseEntity>();

        public void Initialize()
        {
            EntityList.Add(new PlayerEntity("PlayerOne", 100.0f, 100.0f));
        }

        public BaseEntity GetPlayer()
        {
            //Todo: try this return EntityList.FirstOrDefault(e => e.IsPlayerControlled);
            foreach (BaseEntity entity in EntityList)
            {
                if (entity.PlayerControlled)
                {
                    return entity;
                }
            }
            return null;
        }

        public void SetPlayer(PlayerEntity newPlayer)
        {
            for(int i = 0; i < EntityList.Count; i++)
            {
                BaseEntity entity = EntityList[i];
                if (entity.PlayerControlled)
                {
                    newPlayer.Position = new System.Drawing.Point(0, 0);
                    EntityList[i] = newPlayer;
                }
            }
        }
    }
}
