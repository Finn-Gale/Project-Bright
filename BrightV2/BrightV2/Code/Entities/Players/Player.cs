using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using BrightV2.Code.Input;
using BrightV2.Code.AI;
using BrightV2.Code.AI.Behaviours;
namespace BrightV2.Code.Entities.Players
{
    abstract class Player : GameEntity, IPlayer , IPlayerControler , IRigidCollide
    {

        //DECLARE a variable for the Character, call it '_mSpeed'
        protected float _mSpeed;

        //Declare a Jump speed for the character, call it  '_jSpeed'
        protected float _jSpeed;

        //DECLARE a Gravity object, call it _mGrav;
        protected IGravity _mGrav;

        //DECLARE a bool to identify if the Rigid collider needs to be removed form the game, call it '_mRigidRemove'
        private bool _mRigidRemove;

        //DECLARE a bool to identify if the Iplayer collider needs to be removed form the game, call it '_mColliderRemove'
        private bool _mColliderRemove;

        //DECLARE a bool to identify if the input needs to be removed form the game
        private bool _mInputRemove;
        
        /// <summary>
        /// ////////////////////////COLLISION IMPLEMENTATION//////////////////////////////////////////////
        /// </summary>
        //DECLARE a float value for the for a detection radius of the Player, call it 'radValue'
        public float radValue
        {
            get { return (Math.Max(mTexture.Height, mTexture.Width) / 2); }
        }

        //DECLARE a Vector2 to hold the central location of the player, call it 'centrePos'
       public Vector2 centrePos
        {
            get
            {
                Vector2 center = new Vector2(_mPosition.X + ((mTexture.Width) / 2), _mPosition.Y + ((mTexture.Height) / 2));
                return center;
            }
        }

        // a colliision method to be called when the Player collides with a PlayerColidable
        public abstract void Collide(IPlayCollide pCollider);



        //a Initialize method will be used to deffine the Properties of the ICollidable
        public void Initialize(int pID)
        {

        }

        // each ICollidable will hold an ID wich will allow for it to be identified
        public int cID
        {
            get { return eID; }
        }

        //Each collidable will require a vector2 for the location of the object. This  point will be used to calculate 
        //bounding boxes and bounding circles, call it 'ColPos'
        public Vector2 ColPos
        {
            get { return _mPosition; }

        }

        //each collidable must have a value for its height in order to calculate a bounding box
        public float Height
        {
            get { return mTexture.Height; }
        }

        //each collidable must have a value for its width in order to calculate a bounding box
        public float Width
        {
            get { return mTexture.Width; }
        }

        //Each rigid collider will require a Collision Reaction method
        //the method will take in the magnitude of the collision as a vector 2 and the position of the object it collided into 
        public void Collide(Vector2 collVec, Vector2 collPos)
        {
            if (Math.Abs(collVec.X) <= Math.Abs(collVec.Y))
            {
                if (collPos.X > _mPosition.X)
                {
                    _mPosition.X = _mPosition.X + collVec.X;
                }
                else
                    _mPosition.X = _mPosition.X + (collVec.X * -1);
            }
            else
            {
                if (collPos.Y > _mPosition.Y)
                {
                    _mPosition.Y = _mPosition.Y + collVec.Y;
                }
                else
                {
                     _mPosition.Y = _mPosition.Y + (collVec.Y * -1);
                }

            }
        }

        ///////////////////////////////Player Controler Impleentation////////////////

        // each IInputListener will hold an ID which will allow for it to be identified
        public int InputID
        {
            get { return eID; }
        }

        //InputEvent - This method will take in a string and perform a reaction to the Event
        public abstract void InputEvent(string keyEvent);


        //this addbehaviour overide also stores the gravity behaviour in a seperate variable
        public override void AddBehaviour(IBehaviour pBehaviour)
        {

            _mMind.Add(pBehaviour);
            if (pBehaviour is IGravity)
            {
                _mGrav = (IGravity)pBehaviour;
            }
        }
        
        //this bool identifies if the input component needs to be removed form the game
        public bool RemoveInput
        {
            get { return _mInputRemove; }
        }

        //this bool identifies if the collision component of this player needs to be removed
        public bool RemoveCollider
        {
            get { return _mColliderRemove; }
        }

    }
}
