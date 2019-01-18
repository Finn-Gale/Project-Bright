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
    class Level3 :ILevel
    {

        public Level3()
        {

        }

        public List<IEntity> Populate(IEntityMgr pEntityMgr)
        {
            List<IEntity> levelData = new List<IEntity>();

            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 50, 400, new string[] {"Follow" }));
            levelData.Add(pEntityMgr.CreateEntity<Com>("com", 50, 500, new string[] {"Gravity" }));

            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 1400, 400, new string[] {"Follow" }));
            levelData.Add(pEntityMgr.CreateEntity<May>("may", 1400, 500, new string[] { "Gravity" }));

            levelData.Add(pEntityMgr.CreateEntity<Torch>("thing", 0, 0, new string[] { }));

            levelData.Add(pEntityMgr.CreateEntity<Torch>("hatman", 600, 400, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Torch>("floaty_thing", 500, 400, new string[] { }));

            //floor
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 0, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 500, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1000, 880, new string[] { }));
        
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1500, 880, new string[] { }));
           
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1600, 500, new string[] { }));
            return levelData;


        }
    }
}
