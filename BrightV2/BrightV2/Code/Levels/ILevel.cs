using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightV2.Code.Levels
{
    interface ILevel
    {
        //DECLARE a list method call it, populate
        List<IEntity> Populate(IEntityMgr pEntityMgr);
    }
}
