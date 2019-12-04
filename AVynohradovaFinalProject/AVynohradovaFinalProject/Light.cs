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
    class Light : DrawableGameComponent
    {
        private Texture2D light;
        private Texture2D light2;

        private Vector2 position = Vector2.Zero;

        double timeSinceFlash = 0;
        const double LIGHT_FLASH = 0.1;
        const int MIN = 20;
        const int MAX = 80;

        bool flip = false;

        Random random = new Random();
        Color color;

        public Rectangle Bounds
        {
            get
            {
                Rectangle rect = light.Bounds;
                rect.Location = position.ToPoint();
                return rect;
            }
        }

        public Light(Game game) : base(game)
        {
            
        }

        public Light(Game game, Vector2 initPosition) : base(game)
        {
            position = initPosition;
        }

        public override void Update(GameTime gameTime)
        {
            int min = MIN;
            int max = MAX;
            int radius = 15;
            float opacity = random.Next(min, max) * 0.02f;
            
            timeSinceFlash += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceFlash >= LIGHT_FLASH)
            {
                timeSinceFlash = 0;
                color = Color.White * opacity;
                min += radius;
                max += radius;
                opacity += random.Next(min, max);

                if(min < MIN || max > MAX)
                {
                    radius = -radius;
                    flip = !flip;
                }
            }
            position.Y += 1;

            if (position.Y > Game.GraphicsDevice.Viewport.Height + light.Height + 10)
            {
                Game.Components.Remove(this);
            }

            base.Update(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            light = Game.Content.Load<Texture2D>("light");
            light2 = Game.Content.Load<Texture2D>("light2");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();

            sb.Draw(light,
                position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                1f,
                flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f);
            sb.Draw(light2,
                position,
                null,
                color,
                0f,
                Vector2.Zero,
                1f,
                flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f);

            sb.End();
            base.Draw(gameTime);
        }

        public void HandleCollision()
        {
            Game.Components.Remove(this);
        }
    }
}
