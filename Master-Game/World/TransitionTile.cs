using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    class TransitionTile: BaseTile
    {
        private bool IsOpenForTransition;

        public TransitionTile(): base(TileType.Transition,true,0.0f)
        {            
        }

        /// <summary>
        /// This method will set the attribute for if the transition tile is open (i.e., = true)
        /// </summary>
        /// <param name="newCondition"></param>
        public void SetIsOpenForTransition(bool newCondition)
        {
            IsOpenForTransition = newCondition;
        }

        public bool GetIsOpenForTransition()
        {
            return IsOpenForTransition;
        }
    }
}
