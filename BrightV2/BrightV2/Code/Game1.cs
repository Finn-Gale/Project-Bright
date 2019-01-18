using BrightV2.Code.Managers;
using BrightV2.Code.Entities;
using BrightV2.Code.Entities.Players;
using BrightV2.Code.Entities.Lights;
using BrightV2.Code.AI;
using BrightV2.Code;
using BrightV2.Code.Input;
using BrightV2.Code.Viewport;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BrightV2.Code.Managers.Interfaces;
using System.Collections.Generic;
using BrightV2.Code.Levels;
namespace BrightV2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game, IDedicatedListener
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        //DECLARE a public static int variables for the height and with of the game window, call them 'ScreenHight' and 'ScreenWidth'

        public static int ScreenHeight;
        public static int ScreenWidth;


        //DECLARE a ISceneMgr tok manage the gamme scenes, call it '_mSceneMgr'
        private ISceneMgr _mSceneMgr;

        //DECLARE a IEntityMgr to Manage Entities, call it '_mEntityMgr'
        private IEntityMgr _mEntityMgr;

        //DECLARE a CollisionMGr to manage the collisions of the engine, call it '_mCollisionMgr'
        private ICollisionMgr _mCollisionMgr;

        //DECLARE an IAIMgr to manage the behaviours of the entity, call it '_mAIMgr'
        private IAIMgr _mAIMgr;

        //DECLARE an IInputMgr to manage the input in the game, call it '_mInputMgr'
        private IInputMgr _mInputMgr;

        //DECLARE an IMindBuilder to build behaviours, call it '_mMindBuilder'
        private IMindBuilder _mMindBuilder;

        //DECLARE a List to hold IEntities, call it '_mEntArray'
        private List<IEntity> _mEntArray;

        //DECLARE a  Camera for the game to be viewed through , call it '_mCamera'
        private Camera _mCamera;

        //DECLARE a IRenderMgr to manage the renderign of the scene, call it _mRenderMgr
        private IRenderMgr _mRenderMgr;

        //DECLARE a IViewpotMGr to manage the viewport of the game, call it _mViewMgr
        private IViewportMgr _mViewMgr;


        //DECLARE an ILevel to hold the level that will be loaded into the game, call it _mLevel
        private ILevel _mLevel;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //screen width and height

            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            //_mSceneMgr
            _mSceneMgr = new SceneMgr();

            //_mEntityMgr
            _mEntityMgr = new EntityMgr(Content);

            //_mEntArray
            _mEntArray = new List<IEntity>();

            //_mCollisionMgr
            _mCollisionMgr = new CollisionMgr();

            //_mAIMgr
            _mAIMgr = new AIMgr();

            //_mMindBuilder
            _mMindBuilder = new MindBuilder(_mAIMgr);

            //_mInputMgr
            _mInputMgr = new InputMgr();

            //_mRenderMgr
            _mRenderMgr = new RenderMgr(Content, GraphicsDevice);

            //_mViewMgr
            _mViewMgr = new ViewportMgr();

            //_mCamera
            _mCamera = new Camera();

            //_mLevel
            _mLevel = new Level2();
            base.Initialize();

            graphics.PreferredBackBufferHeight = ScreenHeight / 2;
            graphics.PreferredBackBufferWidth = ScreenWidth / 2;


            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //_mViewMgr
            _mViewMgr = new ViewportMgr();
            //_mInputMgr
            _mInputMgr = new InputMgr();

            //Add Dedicated listeners
            IDedicatedListener temporaryMgr = (IDedicatedListener)_mViewMgr;
            _mInputMgr.AddDedicatedListener(temporaryMgr);

            IDedicatedListener tempGame = (IDedicatedListener)this;
            _mInputMgr.AddDedicatedListener(tempGame);

            _mEntArray = _mLevel.Populate(_mEntityMgr);


            foreach (IEntity tempEnt in _mEntArray)
            {
                _mSceneMgr.Add(tempEnt);
                _mCollisionMgr.AddCollider(tempEnt);
                _mMindBuilder.BuildMind(tempEnt);
                _mInputMgr.AddInputListener(tempEnt);
                _mViewMgr.AddTarget(tempEnt);
            }

           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _mSceneMgr.Update();

            _mInputMgr.Update();

            
            _mAIMgr.Update();

            _mCollisionMgr.Check();

            _mCamera = _mViewMgr.Update();


            RemovalCheck();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here


            //this calls the render method if The RenderMgr
            _mRenderMgr.Render(_mSceneMgr.mScene, spriteBatch, _mCamera);


            base.Draw(gameTime);
        }

        //this method is resposnable for searching through the Entities and removing them if necessary
        protected void RemovalCheck()
        {
            //search through the entity array,
            foreach (IEntity tempEnt in _mEntArray)
            {
                //store the check value
                int checkval = tempEnt.eID;

                //if the entity requires a complete removal, remove it from all mgrs
                if (tempEnt.CompleteRemove)
                {
                    _mSceneMgr.Remove(checkval);
                    _mCollisionMgr.RemoveCollider(checkval);
                    _mAIMgr.Remove(tempEnt);
                    _mViewMgr.RemoveTarget(checkval);
                    if (tempEnt is IInputListener)
                    {
                        IInputListener tempinput = (IInputListener)tempEnt;
                        _mInputMgr.RemoveInputListener(tempinput.InputID);
                    }
                    _mEntArray.Remove(tempEnt);
                    break;
                }

                //remove form the scene includign other managers but not the main game
                if (tempEnt.SceneRemove)
                {
                    _mSceneMgr.Remove(checkval);

                    _mCollisionMgr.RemoveCollider(checkval);
                    _mAIMgr.Remove(tempEnt);

                    if (tempEnt is IInputListener)
                    {
                        IInputListener tempinput = (IInputListener)tempEnt;
                        _mInputMgr.RemoveInputListener(tempinput.InputID);
                    }
                }
            }
        }

        private void FullRemove()
        {
            while (_mEntArray.Count > 0)
            {
                foreach (IEntity tempEnt in _mEntArray)
                {
                    //store the check value
                    int checkval = tempEnt.eID;


                    _mSceneMgr.Remove(checkval);
                    _mCollisionMgr.RemoveCollider(checkval);
                    _mAIMgr.Remove(tempEnt);
                    _mViewMgr.RemoveTarget(checkval);
                    if (tempEnt is IInputListener)
                    {
                        IInputListener tempinput = (IInputListener)tempEnt;
                        _mInputMgr.RemoveInputListener(tempinput.InputID);
                    }
                    _mEntArray.Remove(tempEnt);
                    break;
                }
            }
        }

        public void InputEvent(string keyEvent)
        {
            switch(keyEvent)
            {
                case "1":
                    _mLevel = new Level1();

                    FullRemove();

                    LoadContent();
                    break;

                case "2":
                     _mLevel = new Level2();

                    FullRemove();

                    LoadContent();
                    break;

                case "3":
                    _mLevel = new Level3();
                    FullRemove();
                    LoadContent();
                    break;
            }


        }
    }
}
