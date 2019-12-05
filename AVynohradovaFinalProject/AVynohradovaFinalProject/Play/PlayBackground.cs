using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVynohradovaFinalProject
{
    class PlayBackground : DrawableGameComponent
    {
        private Texture2D background;
        private Rectangle window;

        public PlayBackground(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();
            spriteBatch.Begin();

            spriteBatch.Draw(background, window, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            DrawOrder = 0;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            background = Game.Content.Load<Texture2D>("background");
            window = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.LoadContent();
        }
    }
}
