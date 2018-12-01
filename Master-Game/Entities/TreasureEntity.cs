using System;
namespace MasterGame.Entities
{
    public class TreasureEntity : BaseEntity
    {
        public int TreasureValue {get;}

        public TreasureEntity(int treasureValue) 
            : base (EntityType.Treasure, "Treasure", 999, 999, true, false, false, false)
        {
            TreasureValue = treasureValue;
        }
    }
}
