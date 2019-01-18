using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.AI
{
    interface IAIFactory
    {
        //this Interface is an object that creates AI Components

            //this method uses generics to create behaviour objects
        IBehaviour CreateBehaviour<T>() where T : IBehaviour, new();
    }
}
