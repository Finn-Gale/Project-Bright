using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BrightV2.Code
{
    interface IRigidCollide : ICollidable
    {
        /**
         *  IRigidCollide is an object that will have a physicalality and will not allow other rigid objects to pass through it
         * 
         */

        //Each collidable will require a vector2 for the location of the object. This  point will be used to calculate 
        //bounding boxes and bounding circles, call it 'ColPos'
       new Vector2 ColPos
        {
            get;
        }

        //each collidable must have a value for its height in order to calculate a bounding box
        new float Height
        {
            get;
        }

        //each collidable must have a value for its width in order to calculate a bounding box
        new float Width
        {
            get;
        }

        //Each rigid collider will require a Collision Reaction method
        //the method will take in the magnitude of the collision as a vector 2 and the position of the object it collided into 
        void Collide(Vector2 collVec, Vector2 collPos);
   
    }
}
