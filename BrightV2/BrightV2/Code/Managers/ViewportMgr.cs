using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Entities;
using BrightV2.Code.Managers.Interfaces;
using BrightV2.Code.Viewport;
using BrightV2.Code.Input;


namespace BrightV2.Code
{
    class ViewportMgr : IViewportMgr , IDedicatedListener
    {

        //DECLARE a IEntity that the viewport will act apon, call it '_mActiveTarget'

        private IEntity _mActiveTarget;

        //DECLARE a camera that will act as th viewport of the game, call it _mCamera
        private Camera _mCamera;

        //DECLARE a list of players to hold the players that the camera will center on 
        private List<IEntity> _mTargets;

        //declare an int that will chold the value of the currently viewed player, call it _intActive
        private int _intActive;

        private int _intMax;
        public ViewportMgr()
        {
            //initalise instance variabvles
            _mCamera = new Camera();
            _mTargets = new List<IEntity>();
            _intActive = 0;
            _intMax = 0;
        }



        public Camera Update()
        {
            _mActiveTarget = (IEntity)_mTargets[_intActive];
            _mCamera.Follow(_mActiveTarget);  //Player needs to be insertd into here)
            return _mCamera;
        }


        //Add Target - This method adds an IEntity that will allow the camera to allocate the target.
        public void AddTarget(IEntity pEntity)
        {
            //create a temporary IEntity to store pEntity
            IEntity tempEnt = pEntity;

            //Check if tempEnt is an IPlayer 

            if(tempEnt is IPlayer)
            {
                _mTargets.Add(tempEnt);
            }
                

        }

        public void RemoveTarget(int pID)
        {
            foreach(IEntity tempEnt in _mTargets)
            {
                if(tempEnt.eID == pID)
                {
                    _mTargets.Remove(tempEnt);
                    
                    _intMax++;
                    _intActive = 0;
                    break;
                }
            }

            if(_mTargets.Count <= 0)
            {
                _mTargets = new List<IEntity>();
            }
        }

        //InputEvent - This method will take in a string and perform a reaction to the Event
        public void InputEvent(string keyEvent)
        {
            switch (keyEvent)
            {
                case "Tab":
                    _intActive++;

                    if(_intActive >= _mTargets.Count)
                    {
                        _intActive = 0;
                    }
                    break;
            }
               
        }
    }

}

