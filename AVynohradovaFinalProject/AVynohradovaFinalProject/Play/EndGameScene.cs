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
    class EndGameScene : GameScene
    {
        int score = 0;

        public EndGameScene(Game game, int score) : base(game)
        {
            this.score = score;
        }

        public override void Initialize()
        {
            this.GameComponents.Add(new PlayBackground(Game));
            this.GameComponents.Add(new UserScore(Game, score));
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    ((Game1)Game).HideAllScenes();
                    Game.Services.GetService<Menu>().Show();
                }
            }
            base.Update(gameTime);
        }
    }
}
