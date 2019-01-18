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
    interface IEntity
    {
        //All entities must have an id property
        int eID { get; }

        //a float property for the X position of the IEntity
        float x { get; }

        //a float value for the y position of the IEntity

        float y { get; }

        //a texture 2d to hold the texture of the IEntity
        Texture2D mTexture { get; }

        //a Vector2 to hold the location of the IEntity
        Vector2 mPosition { get; }

        //A float property to return the scale of the IEntity
        float mScale { get; }

        //a strign array to hold the types of behaviours the IEntity will need
        string[] mBehaviours { get; }

        //a IBehaviour array property is used so that the behaviours cna be accessed
        List<IBehaviour> mMind { get; }

        //A bool property that identifies if the entity is required to be removed form the SceneMgr, call it 'SceeneRemove'
        bool SceneRemove { get; }

        //a bool value, to remove the entity completley from the game
        bool CompleteRemove { get; }
        
        
        
        //a method to add Behaviours to the entity
        void AddBehaviour(IBehaviour pBehaviour);

        //a method to allow the removal of behaviours form the mind
        void RemoveBehaviour(int pID);
        //This initalizes the IEntity
        void Initialize(int pID, Texture2D pTexture, float pX, float pY, string[] pBehaviours);

        //an update loop for position and general application
        void UpdatePos(Vector2 pNewPos);

        void Update();
    }
}
