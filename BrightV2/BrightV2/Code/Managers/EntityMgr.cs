using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace BrightV2
{
    class EntityMgr : IEntityMgr
    {
        //Instance variables
        //A list that allows all the Entities to be stored, call it '_entityArray'
        private List<IEntity> _entityArray;

        // Create an int counter to generate unquie itegers to be used as the Entities ID, call it _IDCounter;
        private int _IDCounter;

        //DECLARE a content manager to load assets, callit '_mContent'
        private ContentManager _mContent;
        public EntityMgr(ContentManager pContent)
        {
            //Constructor code
            //Initalize instance variables 
            //_entityArray
            _entityArray = new List<IEntity>();

            //_IDCounter
            _IDCounter = 0;

            _mContent = pContent;
        }


        //This method creates a new object of a Generic type and returns to caller
        public IEntity CreateEntity<T>(string pTexture, float pX, float pY, string[] pAI) where T : IEntity, new()
        {
           Texture2D temptex =_mContent.Load<Texture2D>(pTexture);
            //The type (T) is used to create the new IEntity
            IEntity newEntity = new T();

            //adds the IEntity to the array
            _entityArray.Add(newEntity);

            //This calls the Initalize method of the newEntity
            newEntity.Initialize(_IDCounter, temptex, pX, pY, pAI);
            _IDCounter++;

            //returns rhe new entity
            return newEntity;
        }



        //This method creates a new object of a Generic type and returns to caller
        public IEntity CreateEntity<T>(string pTexture, string[] pAI) where T : IEntity, new()
        {
            Texture2D temptex = _mContent.Load<Texture2D>(pTexture);

            //The type (T) is used to create the new IEntity
            IEntity newEntity = new T();

            //adds the IEntity to the array
            _entityArray.Add(newEntity);

            //This calls the Initalize method of the newEntity
            newEntity.Initialize(_IDCounter, temptex, 0, 0, pAI);
            _IDCounter++;

            //returns the new entity 
            return newEntity;
        }




        //This method is used to remove entities form the entity array and then the game allowing them to be collected by the garbage collector
        public void Terminate(int pID)
        {
            //This will loop through the Entity array and find the entity which has the correct ID
            foreach (IEntity ie in _entityArray)
            {
                //this sets the temp entity to be the current entity being iterated on
                IEntity temp = ie;

                //this checks if the Id of the Entity maches the required ID
                if (temp.eID == pID)
                {
                    //rremoves the entity from the entity array
                    _entityArray.Remove(temp);

                    //sets the object to be null
                    temp = null;

                    break;
                }
            }
        }
    }
}
