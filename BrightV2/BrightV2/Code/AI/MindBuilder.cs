using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Managers;
using BrightV2.Code.AI.Behaviours;
namespace BrightV2.Code.AI

{
    class MindBuilder : IMindBuilder
    {
        //DECLARE a IAIMgr that the mind builder will send I Behaviours to be managed, call it '_mAIMgr'
        private IAIMgr _mAIMgr;

        //DECLARE an Int that will be used to assing Behaviours with unique ID's, call it '_idCounter'
        private int _idCounter;


        //DECLARE a IAIFactory to create IBheaviours, call it '_mAIFactory'
        private IAIFactory _mAIFactory;
        public MindBuilder(IAIMgr pMgr)
        {
            //constructor code
            //initalise all instance variables
            _mAIMgr = pMgr;

            _mAIFactory = new AIFactory();

            _idCounter = 0;
        }

        public void BuildMind(IEntity pEntity)
        {
            //creates a string array to hold the desired behaviours of the Entity
            string[] entBehaviour = pEntity.mBehaviours;

            //for each of the strings in the array itterate through this loop
            foreach (string val in entBehaviour)
            {
                IBehaviour newBehaviour;
                //this switch case identifies which behaviours to create using the string value as a input
                switch (val)
                {
                    
                    case "Gravity":
                        //creates a beghaviour of type Gravity,
                         newBehaviour = _mAIFactory.CreateBehaviour<Gravity>();

                        //calls the build method
                        Build(newBehaviour, pEntity);
                        break;
                    case "Follow":
                        //creates a behaviour of type follow
                         newBehaviour = _mAIFactory.CreateBehaviour<Follow>();
                        Build(newBehaviour, pEntity);
                        break;


                    default:
                        
                        //if none of the cases mathc this message is displayed
                        Console.WriteLine("Behaviour {0} invalid", val);
                        break;

                }


            }
        }

        //this method takes in a Ibehaviour and an entity and performs the initalization logic so that it is not repeted
        private void Build(IBehaviour pBev, IEntity pEnt)
        {
            //the pBev is initalized
            pBev.Initalize(pEnt, _idCounter);

            //id cunter is increased
            _idCounter++;

            //the behaviour is added to the entity
            pEnt.AddBehaviour(pBev);

            //the behaviour is added to the AI manager
            _mAIMgr.AddBehaviour(pBev);

        }
    }
}
