using System;
using MasterGame.Global;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class GameManager
    {
        WorldManager m_worldManager;
        EntityManager m_entityManager;

        public GameManager()
        {
            CreateManagers();
            LoadManagers();
        }

        protected void CreateManagers()
        {
            m_worldManager = new WorldManager();
            m_entityManager = new EntityManager();
        }

        protected void LoadManagers()
        {
            m_worldManager.LoadWorld();
            m_entityManager.LoadEntities();
        }

        public void ProcessGame()
        {
            if(m_entityManager.IsPlayerAlive())
            {
                
            }
        }
    }
}
