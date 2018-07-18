using System;

namespace MasterGame.World
{
    public class World
    {
        private BaseTile [,] m_map;

        public World()
        {
        }

        public void LoadWorld()
        {
            m_map = new BaseTile [4,4]
            {
                { new GrassTile(1,1), new LavaTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new LavaTile(1, 1), new LavaTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new GrassTile(1, 1), new LavaTile(1, 1), new GrassTile(1, 1) },
                { new GrassTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1), new GrassTile(1, 1) }   
            };
        }
    }
}
