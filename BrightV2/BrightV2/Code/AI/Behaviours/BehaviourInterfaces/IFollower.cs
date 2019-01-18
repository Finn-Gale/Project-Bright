using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace BrightV2.Code.AI.Behaviours.BehaviourInterfaces
{
    interface IFollower
    {
        //DECLARE a Vector 2 property for the Position of the targetm, call it TagPos

        Vector2 TagPos { get; }

        //DECLARE a Vector2 property for the IFollowersLocation, call it FolPos
        Vector2 FolPos { get; }

        //DECLARE a update possition method, call it UpdatePos 
        void UpdatePos(Vector2 pNewPos);
      
        //DECLARE a bool to identify if the follower has found a target, call it TagFound
        bool TagFound { get; }
    }
}
