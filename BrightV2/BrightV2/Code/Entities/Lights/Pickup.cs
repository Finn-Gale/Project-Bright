using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BrightV2.Code.AI;
namespace BrightV2.Code.Entities.Lights
{
    class Pickup : LightEntity, IPlayCollide
    {
        //DECLARE a int variable for the collider ID of the entity
        private int _mColliderID;

        //DECLARE a bool to identify if the playerLight collider needs to be removed form the game, call it '_mColliderRemove'
        private bool _mColliderRemove;


        public Pickup()
        {
            _Scale = 0.5f;
            _mColliderRemove = false;
            _typeName = "Pickup";

          
        }

        public Vector2 centrePos
        {
            get
            {
                Vector2 center = new Vector2(_mPosition.X + ((mTexture.Width) / 2), _mPosition.Y + ((mTexture.Height) / 2));
                return center;
            }
        }

        public int cID
        {
            get
            {
                return _mColliderID;
            }
        }

        public Vector2 ColPos
        {
            get
            {
                return _mPosition;
            }
        }

        public float Height
        {
            get
            {
                return mTexture.Height;
            }
        }

        public float radValue
        {
            get
            {
                return 10;
            }
        }

        public bool RemoveCollider
        {
            get
            {
                return _mColliderRemove;
            }
        }


        public float Width
        {
            get
            {
                return mTexture.Width;
            }
        }


        public override void AddBehaviour(IBehaviour pBehaviour)
        {

        }

        public void Collide(IPlayer pEntity)
        {

           
              
            _fullRemover = true;

        }

        public void Initialize(int pID)
        {
            _mColliderID = pID;
        }

        public override void Update()
        {


        }

        public override void UpdatePos(Vector2 pNewPos)
        {
            

        }
    }
}

  