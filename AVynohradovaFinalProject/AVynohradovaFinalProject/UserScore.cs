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
    class UserScore : DrawableGameComponent
    {
        int points;
        SpriteFont font;
        private string scoreHeader = "Your score:";
        private string score;
        Vector2 positionHeader;
        Vector2 positionScore;

        public UserScore(Game game, int points) : base(game)
        {
            //if (Game.Services.GetService<UserScore>() == null)
            //{
            //    Game.Services.AddService<UserScore>(this);
            //}
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
