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
    /// The user's score, which is drawn on the EndGameScene
    /// </summary>
    class UserScore : DrawableGameComponent
    {
        int points;
        SpriteFont font;
        private string scoreHeader = "Your score:";
        private string score;
        Vector2 positionHeader;
        Vector2 positionScore;
        
        string fileName = "highScores.txt";

        public UserScore(Game game, int points) : base(game)
        {
            this.points = points;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();
            spriteBatch.Begin();

            spriteBatch.DrawString(font, scoreHeader, positionHeader, Color.White);
            spriteBatch.DrawString(font, score, positionScore, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            List<int> records = new List<int>();
            string line;
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        records.Add(int.Parse(line));
                    }
                }
                records.Add(points);
                records.Sort();
                records.Reverse();
                if (records.Count == 11)
                {
                    records.RemoveAt(10);
                }

                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (int record in records)
                    {
                        writer.WriteLine(record);
                    }
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    records.Add(points);
                    foreach (int record in records)
                    {
                        writer.WriteLine(record);
                    }
                }
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("highlightFont");
            score = points.ToString();
            positionHeader = new Vector2((Game.GraphicsDevice.Viewport.Width - font.MeasureString(scoreHeader).X) / 2,
                                    Game.GraphicsDevice.Viewport.Height / 2);
            positionScore = new Vector2((Game.GraphicsDevice.Viewport.Width - font.MeasureString(score).X) / 2,
                                    Game.GraphicsDevice.Viewport.Height / 2 + font.MeasureString(score).Y);

            base.LoadContent();
        }
    }
}
