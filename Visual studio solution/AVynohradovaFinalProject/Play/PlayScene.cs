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
    /// <summary>
    /// The main scene, where the game occures
    /// </summary>
    public class PlayScene : GameScene
    {
        public static int points;

        const int GAME_TIME = 30;
        double timer = 0.0;
        public static bool gameDone = false;
        public static bool reset = false;

        public PlayScene(Game game) : base(game)
        {
        }
        
        public override void Initialize()
        {
            this.GameComponents.Add(new PlayBackground(Game));
            this.GameComponents.Add(new Boat(Game));
            this.GameComponents.Add(new LightManager(Game));
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                timer += gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= GAME_TIME)
                {
                    ClearBoard();
                    Game.Components.Add(new EndGameScene(Game, points));
                    points = 0;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    ClearBoard();

                    ((Game1)Game).HideAllScenes();
                    Game.Services.GetService<Menu>().Show();
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Clears the Game Components from the lights when the game is finished
        /// </summary>
        private void ClearBoard()
        {
            timer = 0;
            gameDone = true;

            int componentsN = Game.Components.Count;
            for (int i = 0; i < componentsN; i++)
            {
                if (Game.Components.ElementAt(i) is Light)
                {
                    Game.Components.Remove(Game.Components.ElementAt(i));
                    componentsN--;
                    i--;
                }
            }
        }
    }
}
