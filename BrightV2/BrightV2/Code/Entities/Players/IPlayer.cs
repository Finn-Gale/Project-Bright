using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BrightV2.Code.Entities
{
    interface IPlayer : ICollidable
    {
        /**
         *  The IPlayer Interface is an object that will be controlled by the User,   
         */

        //DECLARE a float value for the for a detection radius of the Player, call it 'radValue'
        float radValue { get; }

        //DECLARE a Vector2 to hold the central location of the player, call it 'centrePos'
        Vector2 centrePos { get; }

        // a colliision method to be called when the Player collides with a PlayerColidable
        void Collide(IPlayCollide pCollider);
       
    }
}
