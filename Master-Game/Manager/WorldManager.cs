using System;

namespace MasterGame.Manager
{
    public class WorldManager
    {
        private World m_world;

        public WorldManager()
        {
        }

        public void LoadWorld()
        {
            m_world = new World();
            m_world.LoadWorld();
        }
    }
}
