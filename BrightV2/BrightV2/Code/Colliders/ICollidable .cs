using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BrightV2
{
    interface ICollidable
    {
        /**
         * This interface is an object that has the capability to collide with other collideable objects  
         * 
         * Types of collision:
         * 
         * Rigid Collision - collision with an object which will result in movment of one or both of the objects
         * 
         * Per Pixle Collision - Only objects with complex shapes will need a per pixle collision as their bounding box may not be representativ e of their actual shape
         * 
         * Player Collision - Collision of an object with the player, no other collisions are relevent to this object
         * 
         */


        //a Initialize method will be used to deffine the Properties of the ICollidable
        void Initialize(int pID);

        // each ICollidable will hold an ID wich will allow for it to be identified
        int cID
        {
            get;
        }

        //Each collidable will require a vector2 for the location of the object. This  point will be used to calculate 
        //bounding boxes and bounding circles, call it 'ColPos'
        Vector2 ColPos
        {
            get;
        }

        //each collidable must have a value for its height in order to calculate a bounding box
        float Height
        {
            get;
        }

        //each collidable must have a value for its width in order to calculate a bounding box
        float Width
        {
            get;
        }

        //a bool to identify if the collidable should be removed form the game
        bool RemoveCollider { get; }

    }
}
