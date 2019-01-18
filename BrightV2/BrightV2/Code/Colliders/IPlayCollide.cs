using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BrightV2.Code.Entities;
namespace BrightV2.Code
{
    interface IPlayCollide : ICollidable
    {
        /**
         *  IPlayCollide is a collidable object that is  concerned with collisions with the Player
         */

        //DECLARE a Vector2 to hold the central location of the playerCollider, call it 'centrePos'
        Vector2 centrePos { get; }

        //DECLARE a float value for the for a detection radius of the playerCollider, call it 'radValue'
        float radValue { get; }

        
        //Collision - This method will be called when the Object collides with the player
        void Collide(IPlayer pEntity);

    }
}
