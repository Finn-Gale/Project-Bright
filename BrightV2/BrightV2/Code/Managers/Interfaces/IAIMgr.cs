using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI;
namespace BrightV2.Code.Managers
{
    interface IAIMgr
    {
        //This Mgr is resposnable for managing the IBehaviour objects 
        //Add
        void AddBehaviour(IBehaviour pBehaviour);
        //Update
        void Update();
        //remove 1 
        void Remove(int pID);

        //remove all from one entity
        void Remove(IEntity pEntity);
    }
}
