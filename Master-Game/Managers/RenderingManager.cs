using System;
namespace MasterGame.Manager
{
    public class RenderingManager
    {
        EntityManager MasterEntityManager;
        WorldManager MasterWorldManager;

        public RenderingManager(ref EntityManager entityManager, ref WorldManager worldManager)
        {
            MasterEntityManager = entityManager;
            MasterWorldManager = worldManager;
        }

        public void ProcessGraphics()
        {
            RenderMap();
        }

        protected void RenderMap()
        {
        }
    }
}
