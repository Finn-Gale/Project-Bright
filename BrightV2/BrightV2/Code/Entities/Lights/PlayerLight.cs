using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.AI;
using BrightV2.Code.AI.Behaviours.BehaviourInterfaces;
using Microsoft.Xna.Framework;

namespace BrightV2.Code.Entities.Lights
{
    
    class PlayerLight : LightEntity, IPlayCollide, IFollower
    {

        //DECLARE a int variable for the collider ID of the entity
        private int _mColliderID;

        //DECLARE a bool to identify if the playerLight collider needs to be removed form the game, call it '_mColliderRemove'
        private bool _mColliderRemove;

        //DECLARE a private IPlayer to act as the player that the PlayerLights Target, call it _mPlayer
        private IPlayer _mPlayer;

        //DECLARE a bool to identify if the light has a target player, call it _playerFound
        private bool _playerFound;
        public PlayerLight()
        {
            _Scale = 0.5f;
            _mColliderRemove = false;
            _typeName = "Player_Light";

            _playerFound = false;
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

        public Vector2 FolPos
        {
            get
            {
                throw new NotImplementedException();
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
                  return (Math.Max(mTexture.Height, mTexture.Width) / 2); 
            }
        }

        public bool RemoveCollider
        {
            get
            {
                return _mColliderRemove;
            }
        }

        public bool TagFound
        {
            get
            {
                return _playerFound;
            }
        }

        public Vector2 TagPos
        {
            get
            {
                return _mPlayer.centrePos;
            }
        }

        public float Width
        {
            get
            {
                return mTexture.Width;
            }
        }

        public Vector2 _folPos
        {
            get
            {
               return _mPosition;
            }
        }

        public Vector2 _tagPos
        {
            get
            {
               return _mPlayer.centrePos;
            }
        }

        public override void AddBehaviour(IBehaviour pBehaviour)
        {
           
        }

        public void Collide(IPlayer pEntity)
        {
           
            if(!_playerFound)
            {
                _mPlayer = pEntity;
                _mColliderRemove = true;
                _Scale = 3;

                _playerFound = true;
            }
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
            _mPosition.X = (pNewPos.X -(mTexture.Width*1.5f));
            _mPosition.Y = (pNewPos.Y - (mTexture.Height * 1.5f));

        }
    }
}
