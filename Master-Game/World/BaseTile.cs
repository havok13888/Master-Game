using System;
namespace MasterGame
{
    public class BaseTile
    {
        private TileType m_type;
        private bool m_passable;
        private int m_length;
        private int m_height;

        public BaseTile(TileType type, bool passable, int length, int height)
        {
            m_type = type;
            m_passable = passable;
            m_length = length;
            m_height = height;
        }
    }
}
