using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using BrightV2.Code.Viewport;
namespace BrightV2.Code
{
    interface IRenderMgr
    {
        //IRenderMgr is responsable for renderign the light effects found on the sceen.
        //The Render Mgr will perform a render method for the lights and the game and then combine the two to give the appearnec of a lighted scene

        void Render(List<IEntity> pScene, SpriteBatch mSprite, Camera pCam);
    }
}
