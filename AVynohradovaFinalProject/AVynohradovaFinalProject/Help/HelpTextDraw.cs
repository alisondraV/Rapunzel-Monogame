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
    class HelpTextDraw : DrawableGameComponent
    {
        Texture2D rapunzelTexture;
        Texture2D rapunzel;
        SpriteFont fontMain;
        SpriteFont fontHeader;
        private string header;
        private string text;

        public HelpTextDraw(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Thistle);
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            int colCount = Game.GraphicsDevice.Viewport.Width / rapunzelTexture.Width + 1;
            int rowCount = Game.GraphicsDevice.Viewport.Height / rapunzelTexture.Height + 1;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    sb.Draw(rapunzelTexture,
                        new Vector2(col * rapunzelTexture.Width, row * rapunzelTexture.Height),
                        Color.White * 0.4f);
                }
            }

            sb.Draw(rapunzel,
                new Vector2(Game.GraphicsDevice.Viewport.Width - rapunzel.Width, 0),
                Color.White);

            sb.DrawString(fontHeader,
                header,
                new Vector2(70, Game.GraphicsDevice.Viewport.Height / 8),
                Color.Black);

            sb.DrawString(fontMain,
                text,
                new Vector2(70, Game.GraphicsDevice.Viewport.Height / 4),
                Color.Maroon);

            sb.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            header = "Rapunzel's Light Game";
            text = "Hi! This game is all about launching\n and catching " +
                "chinese lanterns.\n\n By pressing \"right\" or \"left\" buttons\n" +
                " you can move the boat with Rapunzel and Flynn\n" +
                " so they can catch the falling lanterns.";
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            rapunzel = Game.Content.Load<Texture2D>("help");
            fontMain = Game.Content.Load<SpriteFont>("regularFont");
            fontHeader = Game.Content.Load<SpriteFont>("highlightFont");
            rapunzelTexture = Game.Content.Load<Texture2D>("textura");
            base.LoadContent();
        }
    }
}
