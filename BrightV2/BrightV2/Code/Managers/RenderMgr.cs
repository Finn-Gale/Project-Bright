using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightV2.Code.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BrightV2.Code.Viewport;
namespace BrightV2.Code.Managers
{
    class RenderMgr : IRenderMgr
    {
        //IRenderMgr is responsable for renderign the light effects found on the sceen.
        //The Render Mgr will perform a render method for the lights and the game and then combine the two to give the appearnec of a lighted scene


        //Instance variables

        //DECLARE a ContentManager that the RenderMgr will use do load in content files formt he content folder, call it _mContent
        private ContentManager _mContent;

        //DECLARE a RenderTarget2d for the Lights layer of the Render, call it _lightTarget
        private RenderTarget2D _lightTarget;

        //DECLARE a RenderTarget2d for the Game layer of the Render, call it _gameTarget
        private RenderTarget2D _gameTarget;

        //DECLARE an Effects object to hold the Light Effects file, call it _lightEffect
        private Effect _lightEffect;

        //DECLARE a GraphicsDevice to render the Scene, call it _mGraphicsDev;
        private GraphicsDevice _mGraphicsDev;
        public RenderMgr(ContentManager pContent, GraphicsDevice pGraphicsDev)
        {
            //Initalise instance variables 

            _mContent = pContent;

            _mGraphicsDev = pGraphicsDev;

            //this effect uses a file that maipulates the colour of pixles by comparing the colour of two overlapping pixles
            _lightEffect = _mContent.Load<Effect>("lighteffect");

            //this render Target is a texture that is built of of other sprites, this render target holds all the light sprites
            _lightTarget = new RenderTarget2D(_mGraphicsDev, _mGraphicsDev.Viewport.Width, _mGraphicsDev.Viewport.Height);

            //this render taget holds the sprites for the games
            _gameTarget = new RenderTarget2D(_mGraphicsDev, _mGraphicsDev.Viewport.Width, _mGraphicsDev.Viewport.Height);
        }

        public void Render(List<IEntity> pScene, SpriteBatch mSprite, Camera pCam)
        {


           
            //ths sets the render target to the lights target
            _mGraphicsDev.SetRenderTarget(_lightTarget);
            _mGraphicsDev.Clear(Color.Black);
            mSprite.Begin(SpriteSortMode.Immediate, BlendState.Additive);


            foreach (IEntity tempEnt in pScene)
            {
                if (tempEnt is LightEntity)
                {
                    //if an entity is a light entity it is added to this render target
                    mSprite.Draw(tempEnt.mTexture, tempEnt.mPosition, null, Color.AntiqueWhite, 0f, Vector2.Zero, tempEnt.mScale, SpriteEffects.None, 0f);
                }
            }

            mSprite.End();


            //this targets the game target
            _mGraphicsDev.SetRenderTarget(_gameTarget);
            _mGraphicsDev.Clear(Color.DarkGray);
            mSprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            foreach (IEntity tempEnt in pScene)
            {
                if (tempEnt is GameEntity)
                {
                   
                    //any sprite that acts as a game object is added to the games target
                    mSprite.Draw(tempEnt.mTexture, tempEnt.mPosition, null, Color.White, 0f, Vector2.Zero, tempEnt.mScale, SpriteEffects.None, 0f);
                }
            }

            mSprite.End();

          
            _mGraphicsDev.SetRenderTarget(null);


            _mGraphicsDev.Clear(Color.Black);
            mSprite.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null, pCam.Transform);


            //this defines the parameters for the light effecst file,
            _lightEffect.Parameters["light"].SetValue(_lightTarget);

            //this calls the effect to apply its effect
            _lightEffect.CurrentTechnique.Passes[0].Apply();

            //this draws the final image to the scene
            mSprite.Draw(_gameTarget, Vector2.Zero, Color.White);



            mSprite.End();
        }
    }
}
