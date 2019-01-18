using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace BrightV2
{
    interface IEntityMgr
    {
        //This interface will be used by the entity Manager 

        //A generic create new entity method to allow for entities to be created 
        IEntity CreateEntity<T>(string pTexture, string[] pAI) where T : IEntity, new();

        IEntity CreateEntity<T>(string pTexture, float pX, float pY, string[] pAI) where T : IEntity, new();

        //A terminate method that will remove an entity from the game
        void Terminate(int pID);
    }
}
