using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.AI.Behaviours
{
    
    //This abstract class is responsable used be behaviour classes and holds common methods that all behaviours will use
    abstract class Behaviour : IBehaviour
    {
        //DECLARE a IEntity that the behaviour will act apon, call it '_mEntity'
        protected IEntity _mEntity;

        //DECLARE a Int thgat will hold the ID of the Behaviour, call it '_mID'
        protected int _mID;

        //DECLARE a bool that will identify if the behaviour needs to be removed from the game, call it '_bevRemove'
        protected bool _bevRemove;
        //this method will be used to call the behaviour 
        public virtual void Update()
        {

        }

        //This method will  initalize the Behavioru and will provide the Behaviour with an entiy to act apon
        public void Initalize(IEntity pEntity, int pID)
        {
            _mEntity = pEntity;

            _mID = pID;

            _bevRemove = false;
        }

        //This property identifies  the behaviour with a unqie ID
        public int BehaviourID
        {
            get { return _mID; }
        }
        //This property identifies if the behaviour needs to be removed form the game
        public bool RemoveBehaviour
        {
            get { return _bevRemove; }
        }
    }
}
