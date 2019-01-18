using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI.Behaviours;
using BrightV2.Code.AI;
using Microsoft.Xna.Framework;

namespace BrightV2.Code.Entities.Players
{
    //This is the class for the Player May
    class May : Player
    {
        
        public May()
        {
            //Initalise 
            _typeName = "May";
            _mSpeed = 6;
            _jSpeed = 0;
        }

        //this method will be called on each loop of the update
        public override void Update()
        {

        }

        //this method updates the location of may
        public override void UpdatePos(Vector2 pNewPos)
        {
            _mPosition = pNewPos;
        }

        //This Input event reader checks the strign paramater and reacts accordingly
        public override void InputEvent(string keyEvent)
        {
            switch(keyEvent)
            {
                case "Right":
                    HorizontalMove(1);
                    break;

                case "Left":
                    HorizontalMove(-1);
                    break;
                case "Z":
                    //calls a jump behaviour
                    _mGrav.Jump(-15);
                    break;
            }
        }

        public override void Collide(IPlayCollide pCollider)
        {
           //this method will be used when the May collides with specific objects, such as enemies or pickups
        }

        //this method moves May on the Horizontal axis
        private void HorizontalMove(float direction)
        {
            _mPosition.X = _mPosition.X + (_mSpeed * direction);
        }

        

        
    }
}
