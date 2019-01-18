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
    class Level1 : ILevel
    {
        
        public Level1()
        {

        }

        public List<IEntity> Populate(IEntityMgr pEntityMgr)
        {
            List<IEntity> levelData = new List<IEntity>();
            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 0, 600, new string[] { "Follow" }));

            levelData.Add(pEntityMgr.CreateEntity<PlayerLight>("lightmask", 500, 600, new string[] { "Follow" }));
            levelData.Add(pEntityMgr.CreateEntity<May>("may", 0, 500, new string[] { "Gravity" }));
            levelData.Add(pEntityMgr.CreateEntity<Com>("com", 500, 500, new string[] { "Gravity" }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 0, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 500, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1000, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1000, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1500, 880, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", -515, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<RigidBlock>("black_square", 1600, 500, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Square>("square", 1300, 300, new string[] { "Gravity" }));
            levelData.Add(pEntityMgr.CreateEntity<Torch>("torch", 1250, -50, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 1350, 200, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 100, 300, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 400, 300, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Platform>("platform", 700, 300, new string[] { }));
            levelData.Add(pEntityMgr.CreateEntity<Pickup>("pickup", 700, 200, new string[] { }));
            return levelData;


        }
    }
}
