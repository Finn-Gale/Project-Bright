using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.AI
{
    interface IMindBuilder
    {
        //The IMindBuilder is an object responsable for adding the correct Ibehaviours to an IEntity

        //The IMindBuilder takes in an IEntity and reads its Mindtype array for the behaviours the IEntity requires 
        //the IMindBuilder then creates a new Behaviour using an IAIFactory
        //The Behaviour is stored in the IEntity Mind array  and the AIMgr 

        void BuildMind(IEntity pEntity);
    }
}
