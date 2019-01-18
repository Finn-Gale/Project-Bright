using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI.Behaviours.BehaviourInterfaces;
namespace BrightV2.Code.AI.Behaviours
{
    class Follow : IBehaviour
    {
        //DECLARE an IFollower to act apon, call it _mFollower
        private IFollower _mFollower;

        //DECLARE an ID for the behaviour, call it _bevID
        private int _bevID;

        //DECLARE an bool for the removal of this behaviour, call it _removeBev
        private bool _removeBev;
        public int BehaviourID
        {
            get
            {
                return _bevID;
            }
        }

        public bool RemoveBehaviour
        {
            get
            {
                return _removeBev;
            }
        }

        public void Initalize(IEntity pEntity, int pID)
        {
            _mFollower = (IFollower)pEntity;
            _bevID = pID;
            _removeBev = false;
        }

        public void Update()
        {
           if(_mFollower.TagFound)
            {
                _mFollower.UpdatePos(_mFollower.TagPos);
            }
        }
    }
}
