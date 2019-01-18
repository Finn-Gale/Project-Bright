using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BrightV2.Code.Entities
{
    class Platform : GameEntity , IRigidCollide
    {
        //Instance Variables

        //DECLARE a int variable for the collider ID of the entity
        private int _mColliderID;

        //DECLARE a bool to identify if the Platform collider needs to be removed form the game, call it '_mRigidRemove'
        private bool _mRigidRemove;
        public Platform()
        {
            //constructor code

        }
        public override void UpdatePos(Vector2 pNewPos)
        {
            _mPosition = pNewPos;
            _mRigidRemove = false;
        }


        public override void Update()
        {

        }
        ///////////////////////////////////////////////////////////
        //ICollidable inmplementation
        ////////////////////////////////////////////////////////
        //a Initialize method will be used to deffine the Properties of the ICollidable
        public void Initialize(int pID)
        {
            _mColliderID = pID;
        }

        // each ICollidable will hold an ID wich will allow for it to be identified
        public int cID
        {
            get { return _mColliderID; }
        }

        /////////////////////////////////////////////////////
        //IRigidCollide implemeentation
        ////////////////////////////////////////////////////

        //this collidable will require a vector2 for the location of the object. This  point will be used to calculate 
        //bounding boxes and bounding circles, call it 'ColPos'
        public Vector2 ColPos
        {
            get { return _mPosition; }
        }

        //this collidable must have a value for its height in order to calculate a bounding box
        public float Height
        {
            get { return mTexture.Height; }
        }

        //this collidable must have a value for its width in order to calculate a bounding box
        public float Width
        {
            get { return mTexture.Width; }
        }

        //Each rigid collider will require a Collision Reaction method
        //the method will take in the magnitude of the collision as a vector 2 and the position of the object it collided into 
        public void Collide(Vector2 collVec, Vector2 collPos)
        {
            //This object does not react to the Collision, it is a static object
        }

        public bool RemoveCollider
        {
            get { return _mRigidRemove; }
        }
    }
}