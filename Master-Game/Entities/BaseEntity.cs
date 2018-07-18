using System;
using System.Drawing;

namespace MasterGame.Entities
{
    public class BaseEntity
    {
        public EntityType Type { get; internal set; }
        public string Name { get; internal set; }
        public float HealthPoints { get; internal set; }
        public bool CanCollide { get; internal set; }
        public bool CanMove { get; internal set; }
        public bool CanTakeDamage { get; internal set; }
        public bool PlayerControlled { get; internal set; }
        public Point Position;

        public BaseEntity(EntityType type, string name, float healthPoints, 
                          bool canCollide, bool canMove, bool canTakeDamage, bool isPlayerControlled)
        {
            Type = type;
            Name = name;
            HealthPoints = healthPoints;
            CanCollide = canCollide;
            CanMove = canMove;
            CanTakeDamage = canTakeDamage;
            PlayerControlled = isPlayerControlled;
            Position.X = 0;
            Position.Y = 0;
        }

        public bool isAlive()
        {
            return HealthPoints > 0.0f;
        }
    }
}
