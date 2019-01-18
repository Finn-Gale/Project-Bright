using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace BrightV2.Code.AI.Behaviours
{
    class Gravity : Behaviour , IGravity
    {
        //DECLARE a float value for the acceleration of gravity, call i t'_gravVal'
        private float _gravVal;

        //DECLARE a float value for the Vertical speed, call it '_vSpeed'
        private float _vSpeed;

        //DECLARE a float for the Mac spped an entity can have, call it '_mMax' 
        private float _mMax;

        //DECLARE a float for the Y value of the previous itteration, to messure if the entity has moved in the previous since the previous itterartion, call it '_preY'
        private float _preY;
        public Gravity()
        {
            _gravVal = 0.5f;
            _vSpeed = _gravVal;
            _mMax = 25;
            //set _preY to a unlikely number to begin on
            _preY = -5000000;
        }

        //this resets the value for _vSpeed so that the _vSpeed wont remain at max if it stops moving for some reason
        private void Reset()
        {
            _vSpeed = 0;
        }

        //this method will be used to call the behaviour 
        public override void Update()
        {
            //this retrives the possition of the entity
            Vector2 pos = _mEntity.mPosition;

            //this checks if the speed is at max, if not  the speed is increased
            if (_vSpeed <= _mMax)
                _vSpeed = _vSpeed + _gravVal;
            
            //this changes the position of the entity
            pos.Y = pos.Y + _vSpeed;
           
            //this checks if the entity has moved vertically since the last updat (to check if it is being blocked by somthign)
            if (_preY == pos.Y)
                Reset();

            _preY = pos.Y;
            //this updates the entities position
            _mEntity.UpdatePos(pos);
        }

        public void Jump(float jumpval)
        {
            //this retrives the possition of the entity
            Vector2 pos = _mEntity.mPosition;
            if (_preY != pos.Y)
                _vSpeed = jumpval;
            
        }

    }
}
