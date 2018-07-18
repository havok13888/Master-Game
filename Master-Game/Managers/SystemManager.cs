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
        GameManager MasterGameManager;
        RenderingManager MasterRenderingManager;

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
            MasterGameManager = new GameManager(ref MasterEntityManager, ref MasterWorldManager, ref MasterInputManager);
            MasterRenderingManager = new RenderingManager(ref MasterEntityManager, ref MasterWorldManager);
        }

        protected void LoadManagers()
        {
            MasterWorldManager.Initialize();
            MasterEntityManager.Initialize();
        }

        public void ProcessInput()
        {
            MasterInputManager.ProcessInput();
        }

        public void ProcessGame()
        {
            MasterGameManager.ProcessGame();
        }

        public void ProcessGraphics()
        {
            MasterRenderingManager.ProcessGraphics();
        }
    }
}
