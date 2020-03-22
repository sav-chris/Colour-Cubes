using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using PhysicsEngine;

namespace Physics_Demo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        PhysicsEngine.Environment physics;

        Camera camera;
        
        SpriteBatch spriteBatch;

        GameObject[] box;

        // The aspect ratio determines how to scale 3d to 2d projection.
        float aspectRatio;

        /*************************************************************************************************************************/

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /*************************************************************************************************************************/

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Camera Initialisation
            camera = new Camera();
            camera.ViewMatrix = Matrix.CreateLookAt(camera.CameraPosition, camera.CameraFocusOn, Vector3.Up);
            camera.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f),
                aspectRatio,
                1.0f,
                10000.0f);

            // Physics Initialisation
            PhysicsParameters paramaters = new PhysicsParameters();
            paramaters.Gravity = new Vector3(0.0f, -10.0f, 0.0f);
            paramaters.WindSpeed = new Vector3(0.0f, 0.0f, 0.0f);
            physics = new PhysicsEngine.Environment();
            physics.PhysicsParameters = paramaters;

            base.Initialize();
        }

        /*************************************************************************************************************************/

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Model boxModel = Content.Load<Model>(@"Models\Colour_Cube");
            Matrix[] boxTransforms = CommonFunctions.SetupEffectDefaults(boxModel, camera);
            ConvexSegment hull = PhysicsEngine.CommonFunctions.LoadConvexHull(new System.IO.StreamReader(@"..\..\..\Content\Hulls\QUTCube.hull"));

            box = new GameObject[GameConstants.numberOfObjects];
            for (int i = 0; i < box.Length; ++i)
            {
                box[i] = new GameObject(70.0f, hull, physics, boxModel, boxTransforms);
            }

            aspectRatio = (float)graphics.GraphicsDevice.Viewport.Width /
            (float)graphics.GraphicsDevice.Viewport.Height;
            graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullCounterClockwiseFace;
        }

        /*************************************************************************************************************************/

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            //Content can be unloaded here
        }

        /*************************************************************************************************************************/

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            physics.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camera.LookRight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camera.LookLeft();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                camera.LookUp();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                camera.LookDown();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                camera.MoveLeft();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                camera.MoveRight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                camera.MoveForward();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                camera.MoveBackward();
            }

            camera.UpdateCamera();
            base.Update(gameTime);
        }

        /*************************************************************************************************************************/

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw box
            foreach (GameObject gameObj in box)
            {
                gameObj.Draw(camera, aspectRatio);
            }

            base.Draw(gameTime);
        }

        /*************************************************************************************************************************/

    }
}
