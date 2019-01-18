using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace BrightV2
{
    class SceneMgr : ISceneMgr
    {
        //Instance variables
        //A list that allows all the Entities to be stored, call it '_SceneGraph'
        private List<IEntity> _SceneGraph;

        public SceneMgr()
        {
            //initalize instance variables
            _SceneGraph = new List<IEntity>();
        }

        //an update loop to iterate apon items in the _SceneGraph
        public void Update()
        {
            foreach (IEntity ie in _SceneGraph)
            {
                ie.Update();
            }
        }


        //An add method to allow itesm to be added to the scene managers _SceneGraph
        public void Add(IEntity pEntity)
        {
            _SceneGraph.Add(pEntity);

        }


        // a remove method that allows entitis to be removed fomr the scene 
        public void Remove(int pID)
        {
            //This will loop through the Entity array and find the entity which has the correct ID
            foreach (IEntity ie in _SceneGraph)
            {
                //this sets the temp entity to be the current entity being iterated on
                IEntity temp = ie;

                //this checks if the Id of the Entity maches the required ID
                if (temp.eID == pID)
                {
                    //rremoves the entity from the entity array
                    _SceneGraph.Remove(temp);

                    break;
                }
            }
        }

        //this method will render the Scene graph onto the scene
        public void Draw(SpriteBatch mSprite)
        {
            foreach (IEntity ie in _SceneGraph)
            {
                //This draws the  
                mSprite.Draw(ie.mTexture, ie.mPosition, null, Color.White, 0f, Vector2.Zero, ie.mScale, SpriteEffects.None, 0f);
            }
        }


        //A IEntity property to allow for the scene to be retried
        public List<IEntity> mScene
        {
            get { return _SceneGraph; }
        }

    }
}
