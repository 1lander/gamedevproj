using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace speedrun
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D tBlock;
        private Texture2D tTrap;
        private Texture2D tCheckNorm;
        private Texture2D tCheckPow;
        private Texture2D tCheckFin;
        private Texture2D tDispenser;
        private Texture2D tProjectile;
        private Texture2D tHeroLeft;
        private Texture2D tHeroRight;
        Hero hero;
        double counter = 0;
        /*
         * space(0)
         * block(1) 
         * trap(2) 
         * checkpoint(3) 
         * powerup(4) 
         * finish(5) 
         * dispener(6)
         */
        private byte[,] level1Tile = new byte[,]
        {          
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,3,0,0,0,0,2,0,0,0,1,1,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };
        Level level1;
        Texture2D background;
        Texture2D background2;
        Camera2d camera;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            camera = new Camera2d(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tBlock = Content.Load<Texture2D>("Block");
            tCheckFin = Content.Load<Texture2D>("CheckFin");
            tCheckNorm = Content.Load<Texture2D>("CheckNorm");
            tCheckPow = Content.Load<Texture2D>("CheckPow");
            tDispenser = Content.Load<Texture2D>("Dispenser");
            tTrap = Content.Load<Texture2D>("Trap");
            tProjectile = Content.Load<Texture2D>("Projectile");
            background = Content.Load<Texture2D>("background");
            background2 = Content.Load<Texture2D>("background2");
            tHeroLeft = Content.Load<Texture2D>("walkLeft");
            tHeroRight = Content.Load<Texture2D>("walkRight");
            //(64,658)
            hero = new Hero(tHeroRight, new Vector2(64, 658),tHeroLeft);

            level1 = new Level(background2, tBlock,tTrap,tCheckNorm,tCheckPow,tCheckFin,tDispenser,tProjectile);
            level1.tileArray = level1Tile;
            level1.CreateWorld();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            hero.CheckCollision(level1.GetCollisionArray());

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState stateKey = Keyboard.GetState();
            camPos.X = hero.Position.X-200;        
            counter += gameTime.ElapsedGameTime.TotalSeconds;
            level1.Update(gameTime);
            hero.Update(gameTime);
            base.Update(gameTime);
        }

        Vector2 camPos = new Vector2();

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            var viewMatrix = camera.GetViewMatrix();
            camera.Position = camPos;
            spriteBatch.Begin(transformMatrix: viewMatrix);
            level1.DrawLevel(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
