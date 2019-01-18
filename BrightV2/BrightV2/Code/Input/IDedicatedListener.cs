using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.Input
{
    interface IDedicatedListener
    {

        //InputEvent - This method will take in a string and perform a reaction to the Event
        void InputEvent(string keyEvent);
    }
}
