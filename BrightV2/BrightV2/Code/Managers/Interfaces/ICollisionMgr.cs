using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.Managers
{
    interface ICollisionMgr
    {
        /**
         * This interface is an object that manages the collisions in the engine
         * The Collision manager needs to :
         * 
         * 1 Detect when a collision occurs
         * 2 Notify The Objects that are colliding
         * 3 store a list of all collidable objects 
         * 4 Detect collisions in a meaningfull efficient way
         * 
         * ////////////////////IMPORTANT/////////////////////////
         * 
         * 5 When a collision occurs, both parties need to be notified during the same response
         * 
         * //////////////////////////////////////////////////////
         * Types of collision:
         * 
         * Rigid Collision - collision with an object which will result in movment of one or both of the objects
         * 
         * Per Pixle Collision - Only objects with complex shapes will need a per pixle collision as their bounding box may not be representative of their actual shape
         * 
         * Player Collision - Collision of an object with the player, no other collisions are relevent to this object
         * 
         * Destructive collision - Collision that will result in the destruction of an object
         */

        //AddCollider - This method will add a collidable object to the ICollisionMgr's list of Collidables
        //It will take in an IEntity and check itself if the IEntity is a collidable and then store it in its list
        void AddCollider(IEntity pEntity);
        //RemoveCollider - This method will Remove a Collidable object from the ICollisionMgr's list of Collidables
        void RemoveCollider(int pID);
        //Check - This method will act as an update method and will be called on each itteration of the Update Loop, it will check for collisions
        void Check();
    }
}
