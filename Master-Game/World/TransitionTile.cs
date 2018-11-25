using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGame.World
{
    class TransitionTile: BaseTile
    {
        private bool IsOpenForTransition { get; set; }

        public TransitionTile(bool isOpenForTransition): base(TileType.Transition,true,0.0f)
        {
            IsOpenForTransition = isOpenForTransition;
        }

        // TODO: Need a method that was hold/pass the information and data needed for the next map. For example, if the player's health is 85 in the previousl map, it should be 80 in the next map
        /// <summary>
        /// This method will set the attribute for if the transition tile is open (i.e., = true)
        /// </summary>
        /// <param name="newCondition"></param>
        public void SetIsOpenForTransition(bool newCondition)
        {
            IsOpenForTransition = newCondition;
        }
    }
}
