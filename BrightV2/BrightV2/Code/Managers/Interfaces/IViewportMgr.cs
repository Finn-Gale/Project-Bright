using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Viewport;
namespace BrightV2.Code.Managers.Interfaces
{
    interface IViewportMgr
    {



        void AddTarget(IEntity pEntity);

        Camera Update();

        void RemoveTarget(int pID);
    }
}
