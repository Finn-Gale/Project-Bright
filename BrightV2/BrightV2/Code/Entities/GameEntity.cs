using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI;
namespace BrightV2
{
    //This Class is an abstract calss for entities that will be used within the game 
    abstract class GameEntity : Entity
    {
        //this method adds a beahviour to the gameentity
        public override void AddBehaviour(IBehaviour pBehaviour)
        {

            _mMind.Add(pBehaviour);
            
        }
    }
}
