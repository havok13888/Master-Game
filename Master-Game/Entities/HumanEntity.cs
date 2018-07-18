using System;
namespace MasterGame.Entities
{
    public class HumanEntity : BaseEntity
    {
        public HumanEntity(string name, float healthPoints)
            : base (EntityType.Human, name, healthPoints, true, true, true, false)
        {
        }
    }
}
