using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.Input
{
    interface IInputListener
    {
       
        void Initialize(int pID);

        // each IInputListener will hold an ID which will allow for it to be identified
        int InputID
        {
            get;
        }

        //InputEvent - This method will take in a string and perform a reaction to the Event
        void InputEvent(string keyEvent);

        //a bool to identify if the EventListenerShould be removed from the game
        bool RemoveInput { get; }
    }
}
