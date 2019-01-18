using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Entities;
using Microsoft.Xna.Framework;


namespace BrightV2.Code.Managers
{
    class CollisionMgr : ICollisionMgr
    {
        /**
        * This is an object that manages the collisions in the engine
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

        * Player Collision - Collision of an object with the player, no other collisions are relevent to this object
        * 
        */

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Instance Variables

        //DECLARE a private List of ICollidables, call it '_mColliders'
        private List<ICollidable> _mColliders;

        //DECLARE a Private list of IRigidColiders, call it '_rigidColliders'
        private List<IRigidCollide> _rigidColliders;

        //DECLare a Private list of IPlayerColliders, call it '_playColliders'
        private List<IPlayCollide> _playCollide;

        //DECLARE a private list of IPlayers, call it '_mPlayers'
        private List<IPlayer> _mPlayers;
        public CollisionMgr()
        {
            //Constructor

            //initalize instance variables
            _mColliders = new List<ICollidable>();

            _rigidColliders = new List<IRigidCollide>();

            _playCollide = new List<IPlayCollide>();

            _mPlayers = new List<IPlayer>();
        }

        //AddCollider - This method will add a collidable object to the CollisionMgr's list of Collidables
        //It will take in an IEntity and check itself if the IEntity is a collidable and then store it in its list


        public void AddCollider(IEntity pEntity)
        {
            //create a temporary IEntity to store pEntity
            IEntity tempEnt = pEntity;

            //Check if tempEnt is an ICollidable 

            if (tempEnt is ICollidable)
            {
                //this will retrive the ID of the tempEnt, so that it can be stored in the ICollideable
                int tempID = tempEnt.eID;

                //this casts the tempEnt as a ICollidable 
                ICollidable newCollidable = (ICollidable)tempEnt;

                //this initializes the ICollidable
                newCollidable.Initialize(tempID);

                //the new Collidable is stored in the '_mCollidersArray'
                _mColliders.Add(newCollidable);


                //this checks if the newCollidable is a Rigid Collider
                if (newCollidable is IRigidCollide)
                {
                    IRigidCollide newRigid = (IRigidCollide)newCollidable;
                    //this adds it to the _rigidCollide list
                    _rigidColliders.Add(newRigid);
                }

                //thi checks if the new Collidable is a IPlayCollider
                if (newCollidable is IPlayCollide)
                {
                    //this casts new collideable as a Player collider
                    IPlayCollide newPlayCollide = (IPlayCollide)newCollidable;

                    //this adds it to the _playCollide list
                    _playCollide.Add(newPlayCollide);
                }

                //this checks if the new Collider is an instanc eof IPlayer
                if (newCollidable is IPlayer)
                {
                    //this cast the new collider as a IPlayer
                    IPlayer newPlayer = (IPlayer)newCollidable;

                    //this adds it to the player list
                    _mPlayers.Add(newPlayer);
                }
            }
        }

        //RemoveCollider - This method will Remove a Collidable object from the CollisionMgr's list of Collidables
        public void RemoveCollider(int pID)
        {
            //Search trhough the Collidables array and remove the ICollidable

            foreach (ICollidable tempCol in _mColliders)
            {
                if (tempCol.cID == pID)
                {


                    //search through IRigidColliders to remove them form that list if it is present
                    if (tempCol is IRigidCollide)
                    {
                        foreach (IRigidCollide tempRig in _rigidColliders)
                        {
                            if (tempRig.cID == pID)
                            {
                                _rigidColliders.Remove(tempRig);
                                break;
                            }
                        }
                    }
                        //search through IPlayColliders to remove them form that list if it is present
                        if (tempCol is IPlayCollide)
                        {
                            foreach (IPlayCollide tempPlay in _playCollide)
                            {
                                if (tempPlay.cID == pID)
                                {
                                    _playCollide.Remove(tempPlay);
                                    break;
                                }
                            }
                        }

                        //search through IPlayers to remove them form that list if it is present
                        if (tempCol is IPlayer)
                        {
                            foreach (IPlayer tempPlayer in _mPlayers)
                            {
                                if (tempPlayer.cID == pID)
                                {
                                    _mPlayers.Remove(tempPlayer);
                                    break;
                                }
                            }
                        }

                    _mColliders.Remove(tempCol);
                    break;

                }


                }
            }


        //Check - This method will act as an update method and will be called on each itteration of the Update Loop, it will check for collisions
        public void Check()
        {
            //CECK if COLLIDERS NEED TO BE REMOVED

            foreach(ICollidable tempCol in _mColliders)
            {
                if(tempCol.RemoveCollider)
                {
                    RemoveCollider(tempCol.cID);
                    break;
                }
            }
            //CHECK FOR COLLISIONS
            //RIGID Collisions
            RigidCollide();
            //Player COllisions
            PlayCollide();
        }

        private void RigidCollide()
        {
            //RIGIDCOLLIDE

            if (_rigidColliders.Count > 0)
            {

                for (int i = 0; i <= (_rigidColliders.Count - 1); i++)
                {
                    
                  
                    //sets a new IRigidCollider to the current RCollider being itterated on
                    IRigidCollide tempRCol = _rigidColliders[i];

                    //create variables for the min and max value of x and y of the tempRCol
                    Vector2 min1 = tempRCol.ColPos;

                    Vector2 max1 = new Vector2(min1.X + tempRCol.Width, min1.Y + tempRCol.Height);

                    //this creates an int that will be used to chheck against other RColliders. 1 is added so that it will never check against itself or other R colliders that have already 
                    //run through the loop to revent multiple collisions being called by the same 2 objects

                    int checkInt = i + 1;

                    for (int ii = checkInt; ii <= (_rigidColliders.Count - 1); ii++)
                    {
                        //creates a new IRigid for the collidabel being checked against 
                        IRigidCollide checkRCol = _rigidColliders[ii];

                        //create variables for the min and max value of x and y of the checkRCol
                        Vector2 min2 = checkRCol.ColPos;

                        Vector2 max2 = new Vector2(min2.X + checkRCol.Width, min2.Y + checkRCol.Height);

                        //call the Axis alinged bounding box test
                        if (AABBCollision(min1, max1, min2, max2))
                        {
                            //The collision mgr, needs to identify by how much the objects have collided 
                            //declare a vector to send the two objects once their collision magnitude has been calculated 
                            Vector2 collMag = new Vector2();

                            //first determine the magnituted if the object overlap on the x axis

                            collMag.X = (Math.Min(Math.Abs(min1.X - max2.X), Math.Abs(max1.X - min2.X)));

                            collMag.Y = (Math.Min(Math.Abs(min1.Y - max2.Y), Math.Abs(max1.Y - min2.Y)));

                            collMag.X = collMag.X * -1;

                            collMag.Y = collMag.Y * -1;
                            //CollMag is then sent to both objects along with the posiiton of the oposite object

                            //the first collider
                            tempRCol.Collide(collMag, min2);
                            //the second collider
                            checkRCol.Collide(collMag, min1);
                        }
                    }
                }
            }
        }

        private void PlayCollide()
        {
            //this method is resposnable for the collisions between objects and the player

            //the method will loop through the players and identify if the object has collided with the player
            foreach (IPlayer tempPlayer in _mPlayers)
            {
                //this stores a radius value for the object to create a bouding circle, 
                float playerRad = tempPlayer.radValue;

                //this stores the central location of the player object
                Vector2 playerCenter = tempPlayer.centrePos;

                //this creates a vector2 for the origin of the player object
                Vector2 playerMin = tempPlayer.ColPos;

                //this creaets a vector 2 fro the maximum point of the player object
                Vector2 playerMax = new Vector2(playerMin.X + tempPlayer.Width, playerMin.Y + tempPlayer.Height);


                //for each of the colliders check against the player
                foreach (IPlayCollide tempCollider in _playCollide)
                {
                    float colliderRad = tempCollider.radValue;

                    Vector2 colliderCenter = tempCollider.centrePos;

                    //this checks if the distanc ebetween these two objects is less than their radui combined
                    if ((playerRad + colliderRad) >= CalculateDistance(playerCenter, colliderCenter))
                    {
                        //this creates a vector2 for the origin of the collider object
                        Vector2 ColliderMin = tempCollider.ColPos;

                        //this creates a vector2 for the maximum point of the collider object
                        Vector2 ColliderMax = new Vector2(ColliderMin.X + tempCollider.Width, ColliderMin.Y + tempCollider.Height);

                        //this checks if a AABBcollision has occured
                        if (AABBCollision(playerMin, playerMax, ColliderMin, ColliderMax))
                        {
                            //if so both parties are notified
                            tempPlayer.Collide(tempCollider);
                            tempCollider.Collide(tempPlayer);
                        }
                    }
                }
            }
        }

        //This method calculates the distanc ebetween two vectors
        private float CalculateDistance(Vector2 Vec1, Vector2 Vec2)
        {
            float distance;

            Vector2 distanceCalc;

            distanceCalc.X = (Vec1.X - Vec2.X);
            distanceCalc.Y = (Vec1.Y - Vec2.Y);

            return distance = (float)Math.Sqrt((distanceCalc.X * distanceCalc.X) + (distanceCalc.Y * distanceCalc.Y));
        }

        //this method checks if axis alinged bounding boxes overlap to see if a collision has occured
        private bool AABBCollision(Vector2 Min1, Vector2 Max1, Vector2 Min2, Vector2 Max2)
        {
            //this checks if there is an overlap o the x Axis  of the two collidables
            if ((Max1.X >= Min2.X) && (Min1.X <= Max2.X))
            {
                //if there is a overlap then the Y co-ordinates are checked

                if ((Max1.Y >= Min2.Y) && (Min1.Y <= Max2.Y))
                {
                    //if a second overlap is found then a collision has occured
                    return true;
                }
            }

            return false;
        }
    }
}
