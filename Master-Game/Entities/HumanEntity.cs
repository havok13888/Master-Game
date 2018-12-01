using System;
namespace MasterGame.Entities
{
    public class HumanEntity : BaseEntity
    {
        public HumanEntity(string name, float healthPoints, float maxHealthPoints)
            : base (EntityType.Human, name, healthPoints, maxHealthPoints, true, true, true, false)
        {
        }
    }
}
