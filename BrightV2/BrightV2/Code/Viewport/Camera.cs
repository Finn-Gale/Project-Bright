using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace BrightV2.Code.Viewport
{
    //Most of this code was taken from a youtube tutorial which can be found here https://www.youtube.com/watch?v=ceBCDKU_mNw
    class Camera
    {
        public Matrix Transform { get; private set; }

       
        public void Follow(IEntity target) //Need to put whatever we want camera to target here 
        {
            var position = Matrix.CreateTranslation
                (-target.mPosition.X - (target.mTexture.Width / 2),
                 -Game1.ScreenHeight / 2
                , 0);

            var offset = Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);

            Transform = position * offset;

        }

       
    }
}
