using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Input;
using BrightV2.Code.Managers;

using Microsoft.Xna.Framework.Input;

namespace BrightV2.Code.Managers
{
    class InputMgr : IInputMgr
    {
        //DECLARE a List of IInputListeners to store all the input listeners, call it '_mInputs'
        private List<IInputListener> _mInputs;

        //DECLARE an List of IPlayerControllers to store all the player controllers, call it '_mPlayers
        private List<IPlayerControler> _mPlayers;

        //DECLARE an Int for the active player, call it '_mActive'
        private int _mActive;

        //DECLARE a list of IDedictaed listeners, call it _mDedListen
        private List<IDedicatedListener> _mDedListen;

        //DECLARE a Keyboard state for the old state of the keyborad, call it olstate
        KeyboardState oldState;

        public InputMgr()
        {
            //Constructor

            //initalize instance variables
            _mInputs = new List<IInputListener>();

            _mPlayers = new List<IPlayerControler>();

            _mDedListen = new List<IDedicatedListener>();
            _mActive = 0;
        }

        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

           
                PlayerControls(newState);

            DedicatedEvents(newState);
            oldState = newState;
        }


        //AddDedicatedListener - This method is used to add dedicet listeners
        public void AddDedicatedListener(IDedicatedListener plisten)
        {
            _mDedListen.Add(plisten);
        }

        public void AddInputListener(IEntity pEntity)
        {
            //Create a temporary IEntity that stores pEntity
            IEntity tempEnt = pEntity;

            //Check if tempEnt is an IInputListener

            if (tempEnt is IInputListener)
            {
                //This retrieves the Id of temp ent to be stored.
                int tempID = tempEnt.eID;

                //Casts tempent as an IInputlistener
                IInputListener newInput = (IInputListener)tempEnt;

                //Intialise Input
                newInput.Initialize(tempID);

                //the new input gets placed inside an array _mInputs
                _mInputs.Add(newInput);

                if (newInput is IPlayerControler)
                {
                    //cast the Input as anew IPlayerCollider
                    IPlayerControler newPlayer = (IPlayerControler)newInput;

                    //ad this to the Iplayer List
                    _mPlayers.Add(newPlayer);
                }
            }
        }

        public void RemoveInputListener(int pID)
        {
            //Search through the Inputs array to remove any IInputsliListeners

            foreach (IInputListener tempInput in _mInputs)
            {
                if (tempInput.InputID == pID)
                {
                    _mInputs.Remove(tempInput);
                    break;
                }

            }
        }

        private void DedicatedEvents(KeyboardState newState)
        {
            // Is the Tab key down
            if (newState.IsKeyDown(Keys.Tab))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.Tab))
                {
                    foreach(IDedicatedListener tempList in _mDedListen)
                    {
                        tempList.InputEvent("Tab");
                    }
                }
                else if (oldState.IsKeyDown(Keys.Tab))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released

                }
            }

            // Is the Tab key down
            if (newState.IsKeyDown(Keys.D1))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.D1))
                {
                    foreach (IDedicatedListener tempList in _mDedListen)
                    {
                        tempList.InputEvent("1");
                    }
                }
                else if (oldState.IsKeyDown(Keys.D1))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released

                }
            }

            // Is the Tab key down
            if (newState.IsKeyDown(Keys.D2))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.D2))
                {
                    foreach (IDedicatedListener tempList in _mDedListen)
                    {
                        tempList.InputEvent("2");
                    }
                }
                else if (oldState.IsKeyDown(Keys.D2))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released

                }
            }

            if(newState.IsKeyDown(Keys.D3))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.D3))
                {
                    foreach (IDedicatedListener tempList in _mDedListen)
                    {
                        tempList.InputEvent("3");
                    }
                }
                else if (oldState.IsKeyDown(Keys.D3))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released

                }
            }
        }
        private void PlayerControls(KeyboardState newState)
        {
            IPlayerControler tempCon = _mPlayers.ElementAt(_mActive);

            // Is the right arrow key down
            if (newState.IsKeyDown(Keys.Right))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    tempCon.InputEvent("Right");
                }
                else if (oldState.IsKeyDown(Keys.Right))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released
                    tempCon.InputEvent("Right");
                }
            }


            // Is the left arrow key down
            if (newState.IsKeyDown(Keys.Left))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    tempCon.InputEvent("Left");
                }

                else if (oldState.IsKeyDown(Keys.Left))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released
                    tempCon.InputEvent("Left");
                }
            }

            // Is the Z key down
            if (newState.IsKeyDown(Keys.Z))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.Z))
                {
                    tempCon.InputEvent("Z");
                }
                else if (oldState.IsKeyDown(Keys.Z))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released

                }
            }

            // Is the Tab key down
            if (newState.IsKeyDown(Keys.Tab))
            {
                // Check the new state against the old state, if its not equal to the new state, the key has been pressed
                if (!oldState.IsKeyDown(Keys.Tab))
                {
                    _mActive++;

                    if (_mActive >= _mPlayers.Count)
                    {
                        _mActive = 0;
                    }
                    
                }
                else if (oldState.IsKeyDown(Keys.Tab))
                {
                    //If they key was down in the last update but not down now (essentailly the oppoosite to before) the key has been released
                    
                }
            }
        }
    }
}
