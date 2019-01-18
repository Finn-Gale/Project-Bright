using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI;
namespace BrightV2.Code.Managers
{
    class AIMgr : IAIMgr
    {
        //DECLARE a list of IBehaviours to hold all the behaviours that the Mgr will iterate through, call it '_mBehaviours'
        private List<IBehaviour> _mBehaviours;

        
        public AIMgr()
        {
            //initalize instance variables
            _mBehaviours = new List<IBehaviour>();
        }

        //This Mgr is resposnable for managing the IBehaviour objects 
        //Add
       public void AddBehaviour(IBehaviour pBehaviour)
        {
            //  this adds the behaviour to the _mBehaviours list
            _mBehaviours.Add(pBehaviour);
        }
        //Update
        public void Update()
        {
            //this loops theough the 
            foreach(IBehaviour tempBehaviour in _mBehaviours)
            {
                tempBehaviour.Update();
            }
        }
        //remove 1 
        public void Remove(int pID)
        {
            //this cycles through the list of behaviours and removes the behaviour if it has a mathcing ID
            foreach(IBehaviour tempB in _mBehaviours)
            {
                if(tempB.BehaviourID == pID)
                {
                    _mBehaviours.Remove(tempB);
                    break;
                }
            }
        }

        //remove all from one entity
        public void Remove(IEntity pEntity)
        {
            //creates a liost of behaviours of the entity
            List<IBehaviour> bevValues = pEntity.mMind;

            //this cycles through the list of behaviours and calls the remove(int) method to remove the behaviour 
            foreach(IBehaviour tempVal in bevValues)
            {
                int serchVal = tempVal.BehaviourID;
                Remove(serchVal);
            }
        }
    }
}
