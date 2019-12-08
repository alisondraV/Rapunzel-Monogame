using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVynohradovaFinalProject
{
    /// <summary>
    /// Chines lanterns which is drawn on the PlayScene
    /// </summary>
    class Light : DrawableGameComponent
    {
        private Texture2D light;
        private Texture2D light2;
        
        SoundEffect soundEffect;

        private Vector2 position = Vector2.Zero;

        double timeSinceFlash = 0;
        const double LIGHT_FLASH = 0.1;
        const int MIN = 20;
        const int MAX = 80;

        bool flip = false;

        Vector2 position2;

        Random random = new Random();
        Color color;

        /// <summary>
        /// Bounds of the light, which are used so as to find out whether it intersects with the boat
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                Rectangle rect = light.Bounds;
                rect.Location = position.ToPoint();
                return rect;
            }
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
            position.Y += 2;

            position2 = new Vector2(position.X - (light2.Width - light.Width) / 2,
                                    position.Y - (light2.Height - light.Height) / 2);

            if (position.Y >= Game.GraphicsDevice.Viewport.Height + light.Height + 5)
            {
                PlayScene.points -= 5;
                LightManager.lights.Remove(this);
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
            soundEffect = Game.Content.Load<SoundEffect>("s1");
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
                position2,
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

        /// <summary>
        /// Occures when the light intersects with the boat
        /// </summary>
        public void HandleCollision()
        {
            soundEffect.Play();
            Game.Components.Remove(this);
        }
    }
}
