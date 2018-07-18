using System;
using MasterGame.Global;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class SystemManager
    {
        EntityManager MasterEntityManager;
        WorldManager MasterWorldManager;
        InputManager MasterInputManager;

        public SystemManager()
        {
            CreateManagers();
            LoadManagers();
        }

        protected void CreateManagers()
        {
            MasterEntityManager = new EntityManager();
            MasterWorldManager = new WorldManager();
            MasterInputManager = new InputManager();
        }

        protected void LoadManagers()
        {
            MasterWorldManager.LoadWorld();
            MasterEntityManager.LoadEntities();
        }

        public void ProcessInput()
        {
            MasterInputManager.ProcessInput();
        }

        public void ProcessGame()
        {

        }
    }
}
