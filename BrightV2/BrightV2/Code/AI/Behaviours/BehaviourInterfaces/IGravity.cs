using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.AI.Behaviours
{
    interface IGravity
        //this interface is for the gravity class
    {
        //this method will be used to perform a jump behaviour
        void Jump(float jumpval);
    }
}
