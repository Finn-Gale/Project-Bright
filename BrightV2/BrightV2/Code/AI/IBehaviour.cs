using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.AI
{
    interface IBehaviour
    {
        //This interface is an object that performs a specific behaviour and updates the state of an IEntity 

        //Each Behaviour will require a unique ID 

        //this method will be used to call the behaviour 
        void Update();

        //This method will  initalize the Behavioru and will provide the Behaviour with an entiy to act apon
        void Initalize(IEntity pEntity, int pID);

        //a bool to identify if the Behaviour needs to be removed
        bool RemoveBehaviour { get; }

        //this property is used to retrive the ID of the behaviour
        int BehaviourID
        {
            get;
        }
    }
}
