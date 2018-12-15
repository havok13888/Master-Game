using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    class TransitionTile : BaseTile
    {
        private bool IsOpenForTransition { get; set;}

        public TransitionTile(): base(TileType.Transition,true,0.0f)
        {            
        }
    }
}
