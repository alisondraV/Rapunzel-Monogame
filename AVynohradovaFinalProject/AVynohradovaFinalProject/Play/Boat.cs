using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AVynohradovaFinalProject
{
    /// <summary>
    /// Drawn on the PlayScene
    /// </summary>
    class Boat : DrawableGameComponent
    {
        private Texture2D boat;
        private Vector2 boatLocation;
        public static bool reset = false;

        /// <summary>
        /// Bounds of the boat, which are used so as to find out whether a light intersects with it
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                Rectangle rect = boat.Bounds;
                rect.Width -= 100;
                rect.Height = 2;
                rect.Location = boatLocation.ToPoint();
                rect.X += 60;
                rect.Y += (int)(boat.Height * 0.7);
                return rect;
            }
        }

        public Boat(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();
            spriteBatch.Begin();

            spriteBatch.Draw(boat, boatLocation, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            if (Game.Services.GetService<Boat>() == null)
            {
                Game.Services.AddService<Boat>(this);
            }
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (PlayScene.gameDone == false)
            {
                DrawOrder = int.MaxValue;
            }
            else
            {
                this.Visible = false;
            }

            if (reset)
            {
                boatLocation = new Vector2((GraphicsDevice.Viewport.Width - boat.Width) / 2,
                        GraphicsDevice.Viewport.Height - boat.Height);
                reset = false;
            }

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                boatLocation.X -= 3;
            }
            else if (ks.IsKeyDown(Keys.Right))
            {
                boatLocation.X += 3;
            }

            boatLocation.X = MathHelper.Clamp(boatLocation.X, 0, Game.GraphicsDevice.Viewport.Width - boat.Width);
            
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            boat = Game.Content.Load<Texture2D>("boat");
            boatLocation = new Vector2((GraphicsDevice.Viewport.Width - boat.Width) / 2,
                    GraphicsDevice.Viewport.Height - boat.Height);
            base.LoadContent();
        }
    }
}
