using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BrightV2.Code.AI;
namespace BrightV2
{
    //this Class Entity is an abstarct class that will be inherated by all Entities
    abstract class Entity : IEntity
    {


        //Instance variables
        //ID
        private int _mID = -1;

        //a strign name for the type
        protected String _typeName;

        //a strign for a unique name
        private String _mName;

        //an X location fo the Entity
        protected float _x;
        //a Y location for the Entity
        protected float _y;

        //A float vector to hold the scale of the Entity
        protected float _Scale = 1;

        //a bool to identify if the entity shopuld be removed form the sceene
        protected bool _sceneRemover = false;

        //a bool to identify if the entity needs to be removed form the game
        protected bool _fullRemover = false;

        //a texture2d to hold the texture of the Entity
        Texture2D _mTexture;

        //a Vector2 to hold the position of the Entity
        protected Vector2 _mPosition;

        //DECLARE a string array to hold the behaviours that the Entity will perform, call it '_mBehaviours'
        protected string[] _mBehaviours;

        protected List<IBehaviour> _mMind;
        //property for the Id of the entity, this gets the ID but does not allow it to be set
        public virtual int eID
        {
            get { return _mID; }
        }

        //a float property for the x location of the Entity
        public virtual float x
        {
            get { return _x; }
        }
        //a float property for the y location of the Entity
        public virtual float y
        {
            get { return _y; }
        }

        //a Texture2d property for the texture of the entity
        public virtual Texture2D mTexture
        {
            get { return _mTexture; }
        }

        //A float property to return the scale of the IEntity
        public float mScale
        {
            get { return _Scale; }
        }
        //a vector2 property for the position of the entity
        public virtual Vector2 mPosition
        {
            get { return _mPosition; }
        }

        //a string ary property to return the behaviours the entity will use
        public string[] mBehaviours
        {
            get { return _mBehaviours; }
        }

        //a IBehaviour array property is used so that the behaviours cna be accessed
        public List<IBehaviour> mMind
        {
            get { return _mMind; }
        }

        //A bool property that identifies if the entity is required to be removed form the SceneMgr, call it 'SceeneRemove'
        public bool SceneRemove
        {
            get { return _sceneRemover; }
        }


        //A bool property that identifies if the entity is required to be removed form the SceneMgr, call it 'SceeneRemove'
        public bool CompleteRemove
        {
            get { return _fullRemover; }
        }

        //this updatepos method will update the position of the entity
        public abstract void UpdatePos(Vector2 pNewPos);

        //this update method will be overiden by child class
        public abstract void Update();
        //a method to add Behaviours to the entity
        public abstract void AddBehaviour(IBehaviour pBehaviour); 
        
        //this method is used to remove behaviours form the mind
        public void RemoveBehaviour(int pID)
        {
            foreach(IBehaviour Bval in _mMind)
            {
                if (Bval.BehaviourID == pID)
                    _mMind.Remove(Bval);
            }
        }

        //An initalise Method so that the ID can be set
        // @Param pID - this int will be used to store a unquie id for each entity
        public void Initialize(int pID, Texture2D pTexture, float pX, float pY, string[] pBehaviours)
        {
            //this sets the Id to be the inputed value
            _mID = pID;

            //this sets a unique name for the Entity
            _mName = (_typeName + _mID.ToString());

            //Sets the location for the Entity to be placed
            _x = pX;
            _y = pY;

            //set the position vector x and y to the pX and pY
            _mPosition = new Vector2(pX, pY);

            //sets the texture of the Entity to the inputted texture
            _mTexture = pTexture;

            
            
            _mBehaviours = pBehaviours;

            _mMind = new List<IBehaviour>();
        }
    }
}
