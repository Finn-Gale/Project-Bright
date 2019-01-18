using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI.Behaviours;
namespace BrightV2.Code.AI
{
    class AIFactory : IAIFactory
    {
        
        public AIFactory()
        {
          
        }

        //this object is an object that creates AI Components

            //this method takes in behaviour types and creates behaviour objects 
       public  IBehaviour CreateBehaviour<T>() where T : IBehaviour, new()
        {
            IBehaviour newBehaviour = new T();

            return newBehaviour;
        }

    }
}
