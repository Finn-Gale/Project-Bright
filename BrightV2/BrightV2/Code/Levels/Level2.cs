using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Entities.Lights;
using BrightV2.Code.Entities.Players;
using BrightV2.Code.Entities;
namespace BrightV2.Code.Levels
{
    class Level2 : ILevel
    {

        public Level2()
        {

        }

        public List<IEntity> Populate(IEntityMgr pEntityMgr)
        {
            List<IEntity> levelData = new List<IEntity>();
            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 0, 100, new string[] { "Follow" }));
            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 200, 800, new string[] { "Follow" }));
            levelData.Add(pEntityMgr.CreateEntity<May>("may", 0, 100, new string[] { "Gravity" }));
            levelData.Add(pEntityMgr.CreateEntity<Com>("com", 200, 800, new string[] { "Gravity" }));


            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 0, 200, new string[] {  })); 
           
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 400, 200, new string[] { }));
            

            levelData.Add(pEntityMgr.CreateEntity<Platform>("wall", 1000, 000, new string[] { }));

            levelData.Add(pEntityMgr.CreateEntity<Platform>("wall", 1000, 200, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("wall", 1000, 300, new string[] { }));


            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 200, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 400, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 600, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 800, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 840, 500, new string[] { }));
            //FLOOR
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 0, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 500, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1100, 1200, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1300, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1500, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", -515, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1600, 500, new string[] { }));
           
            return levelData;


        }
    }
}
