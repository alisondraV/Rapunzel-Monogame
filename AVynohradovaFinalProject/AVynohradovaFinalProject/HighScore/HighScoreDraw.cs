using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AVynohradovaFinalProject
{
    /// <summary>
    /// The text from the file, drawn on the HighScoreScene
    /// </summary>
    class HighScoreDraw : DrawableGameComponent
    {
        Texture2D rapunzelTexture;
        Texture2D rapunzel;
        SpriteFont fontMain;
        SpriteFont fontHeader;
        private static string header;
        private static string text;

        public HighScoreDraw(Game game) : base(game)
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
                new Vector2(Game.GraphicsDevice.Viewport.Width - rapunzel.Width,
                (Game.GraphicsDevice.Viewport.Height - rapunzel.Height) / 2),
                Color.White);

            sb.DrawString(fontHeader,
                header,
                new Vector2(150, Game.GraphicsDevice.Viewport.Height / 8),
                Color.Maroon);

            sb.DrawString(fontMain,
                text,
                new Vector2(250, Game.GraphicsDevice.Viewport.Height / 4),
                Color.Purple);

            sb.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            UpdateScores();
            base.Initialize();
        }

        /// <summary>
        /// Reads the text from the file if it exists or shows the message
        /// </summary>
        public static void UpdateScores()
        {
            header = "Top 10 High Scores";
            string fileName = "highScores.txt";
            text = "";

            if (File.Exists(fileName))
            {
                string[] records = File.ReadAllLines(fileName);

                foreach (string record in records)
                {
                    text += $"{record}\n";
                }
            }
            else
            {
                text = "Be the first one\nto set the high score!";
            }
        }

        protected override void LoadContent()
        {
            rapunzel = Game.Content.Load<Texture2D>("highscore");
            fontMain = Game.Content.Load<SpriteFont>("regularFont");
            fontHeader = Game.Content.Load<SpriteFont>("highlightFont");
            rapunzelTexture = Game.Content.Load<Texture2D>("textura");
            base.LoadContent();
        }
    }
}
