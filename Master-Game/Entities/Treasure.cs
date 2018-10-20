using System;
namespace MasterGame.Entities
{
    public class Treasure : BaseEntity
    {
        public int TreasureValue {get;}

        public Treasure(int treasureValue) 
            : base (EntityType.Treasure, "Treasure", 999, true, false, false, false)
        {
            TreasureValue = treasureValue;
        }
    }
}
