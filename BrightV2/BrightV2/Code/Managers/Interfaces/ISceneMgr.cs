using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
namespace BrightV2
{
    interface ISceneMgr
    {
        //The scene manager requires
        //an update loop to iterate apon items in the Scene graph
         void Update();

        //An add method to allow itesm to be added to the scene managers Scene graph
        void Add(IEntity pEntity);

        // a remove method that allows entitis to be removed fomr the scene 
        void Remove(int pID);

        //A method to render all the Entities on the scene
        void Draw(SpriteBatch mSprite);

        //A IEntity property to allow for the scene to be retried
        List<IEntity> mScene { get; }
        
    }
}
