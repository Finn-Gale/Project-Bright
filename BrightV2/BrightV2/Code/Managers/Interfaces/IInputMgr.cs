using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Input;
namespace BrightV2.Code.Managers
{
    interface IInputMgr 
    {

        //An update method that is used to check input events
        void Update();

        //a method that will allow Input Listeners to be added to the INput listener array
        void AddInputListener(IEntity pEntity);

        //a method to remove InputListeners from the array
        void RemoveInputListener(int pID);

        //a methd to add dedicated listeners
        void AddDedicatedListener(IDedicatedListener plisten);
    }
}
